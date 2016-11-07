﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eu.EDelivery.AS4.Builders.Core;
using Eu.EDelivery.AS4.Builders.Entities;
using Eu.EDelivery.AS4.Common;
using Eu.EDelivery.AS4.Entities;
using Eu.EDelivery.AS4.Exceptions;
using Eu.EDelivery.AS4.Model.Core;
using Eu.EDelivery.AS4.Model.Internal;
using Eu.EDelivery.AS4.Repositories;
using NLog;

namespace Eu.EDelivery.AS4.Steps.Submit
{
    /// <summary>
    /// Describes how the AS4 UserMessage is stored in the message store,
    /// in order to hand over to the Send Agents.
    /// </summary>
    public class StoreAS4MessageStep : IStep
    {
        private readonly IDatastoreRepository _repository;
        private readonly ILogger _logger;

        private InternalMessage _internalMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreAS4MessageStep"/> class
        /// </summary>
        public StoreAS4MessageStep()
        {
            this._repository = Registry.Instance.DatastoreRepository;
            this._logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreAS4MessageStep"/> class
        /// Creates a <see cref="StoreAS4MessageStep"/>
        /// with a given Data Store Context to use in this step.
        /// </summary>
        /// <param name="repository">
        /// </param>
        public StoreAS4MessageStep(IDatastoreRepository repository)
        {
            this._repository = repository;
            this._logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Store the <see cref="AS4Message" /> as OutMessage inside the DataStore
        /// </summary>
        /// <param name="internalMessage"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<StepResult> ExecuteAsync(InternalMessage internalMessage, CancellationToken token)
        {
            this._internalMessage = internalMessage;

            IEnumerable<MessageUnit> messageUnits = GetMessageUnits(internalMessage);
            await TryStoreOutMessagesAsync(messageUnits, token);

            return StepResult.Success(internalMessage);
        }

        private IEnumerable<MessageUnit> GetMessageUnits(InternalMessage internalMessage)
        {
            return internalMessage.AS4Message.SignalMessages
                .Cast<MessageUnit>()
                .Concat(internalMessage.AS4Message.UserMessages);
        }

        private async Task TryStoreOutMessagesAsync(IEnumerable<MessageUnit> messageUnits, CancellationToken token)
        {
            try
            {
                await StoreOutMessagesAsync(messageUnits, token);
            }
            catch (Exception exception)
            {
                throw ThrowAS4ExceptionWithInnerException(exception);
            }
        }

        private AS4Exception ThrowAS4ExceptionWithInnerException(Exception exception)
        {
            return new AS4ExceptionBuilder()
                .WithInnerException(exception)
                .WithSendingPMode(this._internalMessage.AS4Message.SendingPMode)
                .WithMessageIds(this._internalMessage.AS4Message.MessageIds)
                .WithDescription("Unable to store AS4 Messages")
                .Build();
        }

        private async Task StoreOutMessagesAsync(IEnumerable<MessageUnit> messageUnits, CancellationToken token)
        {
            foreach (MessageUnit messageUnit in messageUnits)
            {
                this._logger.Info($"[{messageUnit.MessageId}] Store AS4 Message");
                OutMessage outMessage = CreateOutMessage(messageUnit, token);
                await this._repository.InsertOutMessageAsync(outMessage);
            }
        }

        private OutMessage CreateOutMessage(MessageUnit messageUnit, CancellationToken cancellationToken)
        {
            OutMessage outMessage = new OutMessageBuilder()
                .WithEbmsMessageType(MessageType.UserMessage)
                .WithAS4Message(this._internalMessage.AS4Message)
                .WithEbmsMessageId(messageUnit.MessageId)
                .Build(cancellationToken);

            outMessage.EbmsRefToMessageId = messageUnit.RefToMessageId;
            outMessage.Operation = Operation.ToBeSent;

            return outMessage;
        }
    }
}