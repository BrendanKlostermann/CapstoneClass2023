/// /// <summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Unit Testing for for GameManager classes.
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
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
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
            const int expectedResult = 4;
            int actualResult = 0;

            DataTable dataTable = _gameManager.ViewAllGames();

            actualResult = dataTable.Rows.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void TestRetrievingGameDetailsByGameID()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
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
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
            const int source = 1;
            const int expectedResult = 1000;
            int actualResult = 0;

            var resultRow = _gameManager.ViewGameDetails(source);

            actualResult = Convert.ToInt32(resultRow[0]);

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Created By Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestRetrievingGameListWithValidTeamID()
        {
            const int source = 1001;
            const int expectedResult = 1;
            int actualResult = 0;

            var gameList = _gameManager.RetrieveTeamGameList(source);
            actualResult = gameList.Rows.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Created By Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestRetrievingGameListWithBadTeamID()
        {
            const int source = 1;
            int actualResult = 0;

            var gameList = _gameManager.RetrieveTeamGameList(source);
            actualResult = gameList.Rows.Count;

        }
    }
}
