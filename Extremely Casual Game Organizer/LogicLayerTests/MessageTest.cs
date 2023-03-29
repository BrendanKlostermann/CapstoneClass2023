/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>

using System;
using LogicLayer;
using DataObjects;
using DataAccessLayerFakes;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class MessageTest
    {

        IMessageManager iMessageManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            iMessageManager = new MessageManager(new FakeMessageAccessor());
        }

        [TestMethod]
        public void SendMessageGood()
        {
            //Arrange
            Message message = new Message()
            {
                MessageID = 123,
                UserIdSender = 1001,
                UserIdReceiver = 1002,
                Date = DateTime.Now,
                Important = false,
                MessageText = "Hello"
            };

            //Act
            const int expectedResult = 1;
            int actualResult = iMessageManager.AddMessage(message);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SendMessageBad()
        {
            //Arrange
            Message message = new Message()
            {
                MessageID = 123,
                UserIdSender = 1001,
                UserIdReceiver = 1002,
                Date = DateTime.Now,
                Important = false,
                MessageText = ""
            };

            //Act
            const int expectedResult = 0;
            int actualResult = iMessageManager.AddMessage(message);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetMessagesGood()
        {
            //Arrange
            Message message = new Message()
            {
                MessageID = 1001,
                UserIdSender = 1001,
                UserIdReceiver = 1002,
                Date = DateTime.Now,
                Important = false,
                MessageText = "Hello"
            };

            //Act
            const int expectedResult = 1;
            List<Message> messages = iMessageManager.GetMessages(message.UserIdSender, message.UserIdReceiver);

            int actualResult = 0;
            if (messages.Count > 0) actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetMessagesBad()
        {
            //Arrange
            Message message = new Message()
            {
                MessageID = 1001,
                UserIdSender = 1004,
                UserIdReceiver = 1007,
                Date = DateTime.Now,
                Important = false,
                MessageText = "Hello"
            };

            //Act
            const int expectedResult = 0;
            List<Message> messages = iMessageManager.GetMessages(message.UserIdSender, message.UserIdReceiver);

            int actualResult = 0;
            if (messages.Count > 0) actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
