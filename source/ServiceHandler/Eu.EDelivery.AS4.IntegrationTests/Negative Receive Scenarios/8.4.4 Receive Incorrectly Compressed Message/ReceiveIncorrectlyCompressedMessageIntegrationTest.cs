using System;
using System.IO;
using System.Linq;
using Eu.EDelivery.AS4.Exceptions;
using Eu.EDelivery.AS4.IntegrationTests.Common;
using Eu.EDelivery.AS4.Model.Core;
using Xunit;

namespace Eu.EDelivery.AS4.IntegrationTests.Negative_Receive_Scenarios._8._4._4_Receive_Incorrectly_Compressed_Message
{
    /// <summary>
    /// Testing the Application with a invalid Compressed Message
    /// </summary>
    public class ReceiveIncorrectlyCompressedMessageIntegrationTest : IntegrationTestTemplate
    {
        private const string ContentType = "multipart/related; boundary=\"MIMEBoundary_58227ff3e3fc7f2a7373840dd22c75172d4362e9ce55d295\"; type=\"application/soap+xml\"; charset=\"utf-8\"";

        private readonly StubSender _sender;

        public ReceiveIncorrectlyCompressedMessageIntegrationTest()
        {
            this._sender = new StubSender();
        }

        [Fact]
        public async void ThenReceivingIncorrectlyCompressedMessageFails()
        {
            // Before
            base.StartApplication();
            base.CleanUpFiles(AS4FullInputPath);

            // Act
            string messageMissingMimeProperty = Properties.Resources.as4message_incorect_compressed;
            AS4Message as4Message = await this._sender
                .SendAsync(messageMissingMimeProperty, ContentType);

            // Assert
            AssertErrorMessage(as4Message);

            // After
            Console.WriteLine(@"Receive Compressed Message Incorrectly Compressed Integration Test succeeded!");
            base.StopApplication();
        }

        private void AssertErrorMessage(AS4Message as4Message)
        {
            var error = as4Message.PrimarySignalMessage as Error;
            Assert.NotNull(error);

            Assert.NotEmpty(error.Errors);
            AssertErrorCode(error);
        }

        private void AssertErrorCode(Error error)
        {
            string errorCode = error.Errors.FirstOrDefault().ErrorCode;
            Assert.Equal($"EBMS:{(int)ErrorCode.Ebms0303:0000}", errorCode);
        }
    }
}
