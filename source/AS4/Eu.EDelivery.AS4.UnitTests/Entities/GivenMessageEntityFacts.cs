﻿using System.IO;
using System.Threading.Tasks;
using Eu.EDelivery.AS4.Entities;
using Eu.EDelivery.AS4.Repositories;
using Eu.EDelivery.AS4.UnitTests.Repositories;
using Xunit;

namespace Eu.EDelivery.AS4.UnitTests.Entities
{
    /// <summary>
    /// Testing <see cref="MessageEntity"/>
    /// </summary>
    public class GivenMessageEntityFacts
    {
        public class Lock
        {
            [Fact]
            public void MessageEntityLocksInstanceByUpdatingOperation()
            {
                // Arrange
                var sut = new StubMessageEntity();
                const Operation expectedOperation = Operation.Sending;

                // Act
                sut.Lock(expectedOperation.ToString());

                // Assert
                Assert.Equal(Operation.Sending, sut.Operation);
            }

            [Fact]
            public void MessageEntityDoesntLockInstance_IfUpdateOperationIsNotApplicable()
            {
                // Arrange
                const Operation expectedOperation = Operation.Notified;
                var sut = new StubMessageEntity { Operation = expectedOperation };

                // Act
                sut.Lock(Operation.NotApplicable.ToString());

                // Assert
                Assert.Equal(expectedOperation, sut.Operation);
            }
        }

        public class RetrieveMessageBody
        {
            [Fact]
            public async Task MessageBodyReturnsNullStream_IfNoMessageLocationIsSpecified()
            {
                // Arrange
                var sut = new StubMessageEntity {MessageLocation = null};

                // Act
                using (Stream actualStream = await sut.RetrieveMessagesBody(store: null))
                {
                    // Assert
                    Assert.Null(actualStream);
                }
            }

            [Fact]
            public async Task MessageEntityCatchesInvalidMessageBodyRetrieval()
            {
                // Arrange
                var sut = new StubMessageEntity {MessageLocation = "ignored"};
                var stubProvider = new MessageBodyStore();
                stubProvider.Accept(condition: s => true, persister: new SaboteurMessageBodyRetriever());

                // Act
                using (Stream actualStream = await sut.RetrieveMessagesBody(stubProvider))
                {
                    // Assert
                    Assert.Null(actualStream);
                }
            }
        }

        private class StubMessageEntity : MessageEntity
        {
            public override string StatusString { get; set; }
        }
    }
}