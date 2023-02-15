using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using LogicLayerInterfaces;
using LogicLayer;
using DataObjects;
using DataAccessLayerFakes;

namespace LogicLayerTests
{
    [TestClass]
    public class GameManagerTests
    {
        IGameManager _gameManager = null;
        [TestInitialize]
        public void TestSetup()
        {
            _gameManager = new GameManager(new GameAccessorFake());
        }
        [TestMethod]
        public void TestRetrievingGameList()
        {
            const int expectedResult = 4;
            int actualResult = 0;

            DataTable dataTable = _gameManager.ViewAllGames();

            actualResult = dataTable.Rows.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void TestRetrievingGameDetailsByGameID()
        {
            const int source = 1000;
            const int expectedResult = 1000;
            int actualResult = 0;

            var resultRow = _gameManager.ViewGameDetails(source);

            actualResult = Convert.ToInt32(resultRow[0]);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRetrievingGameDetailsWithInvlaidGameID()
        {
            const int source = 1;
            const int expectedResult = 1000;
            int actualResult = 0;

            var resultRow = _gameManager.ViewGameDetails(source);

            actualResult = Convert.ToInt32(resultRow[0]);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
