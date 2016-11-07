﻿using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Eu.EDelivery.AS4.Model.Core;
using Eu.EDelivery.AS4.Model.Internal;
using Eu.EDelivery.AS4.Model.Notify;
using Eu.EDelivery.AS4.Singletons;
using NLog;

namespace Eu.EDelivery.AS4.Steps.Notify
{
    /// <summary>
    /// Describes how an ebMS SignalMessage is created into a <see cref="NotifyMessage"/>
    /// </summary>
    public class CreateNotifyMessageStep : IStep
    {
        private readonly ILogger _logger;
        private InternalMessage _internalMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNotifyMessageStep"/> class. 
        /// Create a <see cref="IStep"/> implementation  to create a <see cref="NotifyMessage"/>
        /// </summary>
        public CreateNotifyMessageStep()
        {
            this._logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Starting creating a <see cref="NotifyMessage"/>
        /// </summary>
        /// <param name="internalMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<StepResult> ExecuteAsync(InternalMessage internalMessage, CancellationToken cancellationToken)
        {
            this._internalMessage = internalMessage;

            internalMessage.NotifyMessage = CreateNotifyMessage(internalMessage.AS4Message);
            internalMessage.NotifyMessage.StatusInfo.Any = GetOriginalSignalMessage(internalMessage.AS4Message);

            LogInformation(internalMessage);
            return StepResult.SuccessAsync(internalMessage);
        }

        private NotifyMessage CreateNotifyMessage(AS4Message as4Message)
        {
            return AS4Mapper.Map<NotifyMessage>(as4Message.PrimarySignalMessage);
        }

        private XmlElement[] GetOriginalSignalMessage(AS4Message as4Message)
        {
            if (as4Message.EnvelopeDocument == null) return new XmlElement[0];

            const string xpath = "//*[local-name()='SignalMessage']";
            XmlNode nodeSignature = as4Message.EnvelopeDocument.SelectSingleNode(xpath);

            return new[] {(XmlElement) nodeSignature};
        }

        private void LogInformation(InternalMessage internalMessage)
        {
            string type = GetNotifyMessageType(internalMessage);
            this._logger.Info($"{this._internalMessage.Prefix} Create a Notify Message from a {type}");
        }

        private string GetNotifyMessageType(InternalMessage internalMessage)
        {
            Status status = internalMessage.NotifyMessage.StatusInfo.Status;
            return status == Status.Delivered ? "Receipt" : status.ToString();
        }
    }
}