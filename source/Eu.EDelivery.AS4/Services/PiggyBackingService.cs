﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eu.EDelivery.AS4.Common;
using Eu.EDelivery.AS4.Entities;
using Eu.EDelivery.AS4.Model.Core;
using Eu.EDelivery.AS4.Repositories;
using Eu.EDelivery.AS4.Serialization;
using NLog;

namespace Eu.EDelivery.AS4.Services
{
    internal class PiggyBackingService
    {
        private readonly DatastoreContext _context;

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="PiggyBackingService"/> class.
        /// </summary>
        public PiggyBackingService(DatastoreContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
        }

        /// <summary>
        /// Selects the available <see cref="SignalMessage"/>s that are ready to be bundled (PiggyBacked) with the given <see cref="PullRequest"/>.
        /// </summary>
        /// <param name="pr">The <see cref="PullRequest"/> for which a selection of <see cref="SignalMessage"/>s are returned.</param>
        /// <param name="bodyStore">The body store at which the <see cref="SignalMessage"/>s are persisted.</param>
        /// <returns></returns>
        public async Task<IEnumerable<SignalMessage>> SelectToBePiggyBackedSignalMessagesAsync(PullRequest pr, IAS4MessageBodyStore bodyStore)
        {
            if (pr == null)
            {
                throw new ArgumentNullException(nameof(pr));
            }

            if (bodyStore == null)
            {
                throw new ArgumentNullException(nameof(bodyStore));
            }

            IQueryable<OutMessage> query =
                from outM in _context.OutMessages
                join inM in _context.InMessages
                    on outM.EbmsRefToMessageId
                    equals inM.EbmsMessageId
                where outM.Operation == Operation.ToBePiggyBacked
                      && inM.Mpc == pr.Mpc
                      && outM.EbmsMessageType != MessageType.UserMessage
                select outM;

            var signals = new Collection<SignalMessage>();
            foreach (OutMessage found in query)
            {
                found.Operation = Operation.Sending;
                await _context.SaveChangesAsync()
                         .ConfigureAwait(false);

                string location = found.MessageLocation;
                Stream body = await bodyStore.LoadMessageBodyAsync(location);
                AS4Message signal =
                    await SerializerProvider
                          .Default
                          .Get(found.ContentType)
                          .DeserializeAsync(body, found.ContentType, CancellationToken.None);

                
                if (signal.PrimaryMessageUnit is SignalMessage s)
                {
                    signals.Add(s);
                }
            }

            return signals.AsEnumerable();
        }

        /// <summary>
        /// Resets the PiggyBacked <see cref="SignalMessage"/>s back to its original <see cref="Operation.ToBePiggyBacked"/> state
        /// so it can be picked-up again by the next send-out <see cref="PullRequest"/>.
        /// </summary>
        /// <param name="signals">The <see cref="SignalMessage"/>s that should be resetted for PiggyBacking.</param>
        public void ResetToBePiggyBackedSignalMessages(IEnumerable<SignalMessage> signals)
        {
            if (signals == null)
            {
                throw new ArgumentNullException(nameof(signals));
            }

            IEnumerable<string> nonPrSignals =
                signals.Where(s => !(s is PullRequest))
                       .Select(s => s.MessageId);

            if (nonPrSignals.Any())
            {
                var repository = new DatastoreRepository(_context);
                repository.UpdateOutMessages(
                    m => nonPrSignals.Contains(m.EbmsMessageId),
                    m =>
                    {
                        Logger.Debug($"Update OutMessage SignalMessage {m.EbmsMessageId} with {{Operation=ToBePiggybacked}}");
                        m.Operation = Operation.ToBePiggyBacked;
                    });
            }
        }
    }
}
