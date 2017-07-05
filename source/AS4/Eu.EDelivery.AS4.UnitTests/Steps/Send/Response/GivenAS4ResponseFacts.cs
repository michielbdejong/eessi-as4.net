﻿using System.Net;
using System.Threading;
using Eu.EDelivery.AS4.Model.Internal;
using Eu.EDelivery.AS4.Steps.Send.Response;
using Moq;
using Xunit;

namespace Eu.EDelivery.AS4.UnitTests.Steps.Send.Response
{
    /// <summary>
    /// Testing <see cref="AS4Response"/>
    /// </summary>
    public class GivenAS4ResponseFacts
    {
        [Fact(Skip="useless")]
        public void GetsRequestMessageFromAS4Response()
        {
            // Arranage
            var expectedRequest = new MessagingContext(as4Message: null, mode: MessagingContextMode.Unknown);

            // Act
            MessagingContext actualRequest = CreateAS4ResponseWith(messageRequest: expectedRequest).OriginalRequest;

            // Assert
            Assert.Equal(expectedRequest, actualRequest);
        }

        [Fact(Skip="WebResponse should never be null")]
        public void GetsInternalErrorStatus_IfInvalidHttpResponse()
        {
            Assert.Equal(HttpStatusCode.InternalServerError, CreateAS4ResponseWith(webResponse: null).StatusCode);
        }

        [Fact]
        public void GetsEmptyAS4MessageForEmptyHttpContentType()
        {
            // Arrange
            HttpWebResponse response = CreateWebResponseWithContentType(string.Empty);

            // Act
            var result = CreateAS4ResponseWith(webResponse: response).ReceivedAS4Message;

            // Assert
            Assert.True(result.IsEmpty);
        }

        [Fact]
        public void TestEmptyResponse()
        {
            // Arrange
            string expectedContentType = string.Empty;

            // Act
            HttpWebResponse actualResponse = CreateWebResponseWithContentType(expectedContentType);

            // Assert
            Assert.Equal(expectedContentType, actualResponse.ContentType);
        }

        private static HttpWebResponse CreateWebResponseWithContentType(string contentType)
        {
            var stubResponse = new Mock<HttpWebResponse>();
            stubResponse.Setup(r => r.ContentType).Returns(contentType);

            return stubResponse.Object;
        }

        private static AS4Response CreateAS4ResponseWith(HttpWebResponse webResponse = null, MessagingContext messageRequest = null)
        {
            return AS4Response.Create(
                requestMessage: messageRequest,
                webResponse: webResponse,
                cancellation: CancellationToken.None).Result;
        }
    }
}
