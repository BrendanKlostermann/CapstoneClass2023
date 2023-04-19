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
using System.Linq;

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

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestRetreivingGameScoresByGameID()
        {
            const int source = 1000;
            const decimal expectedResult = 10;
            decimal? actualResult = 0;

            var scoreList = _gameManager.RetreiveScoresByGameID(source);
            actualResult = (decimal?)scoreList.Where(x => x.TeamID == 1001).Select(s => s.TeamScore).First();

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorRetreivingGameScoresByGameID()
        {
            const int source = 1;
            const decimal expectedResult = 10;
            decimal? actualResult = 0;

            var scoreList = _gameManager.RetreiveScoresByGameID(source);
            actualResult = (decimal?)scoreList.Where(x => x.TeamID == 1001).Select(s => s.TeamScore).First();

        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestAddingGame()
        {
            Game game = new Game() { GameID = 1010, VenueID = 1001, DateAndTime = DateTime.Now, SportID = 1000};
            int member_id = 100000;
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _gameManager.AddGame(game, member_id);

            Assert.AreEqual(expectedResult, actualResult);

        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestEdittingGameByGameID()
        {
            Game game = new Game() { GameID = 1000, VenueID = 1001, DateAndTime = DateTime.Now, SportID = 1000 };
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _gameManager.EditGame(game, 100000);

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestRemovingGameByGameID()
        {
            Game game = new Game() { GameID = 1000, VenueID = 1001, DateAndTime = DateTime.Now, SportID = 1000 };
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _gameManager.RemoveGame(game, 100000);

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorAddingGame()
        {
            Game game = null;
            int member_id = 100000;
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _gameManager.AddGame(game, member_id);

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorEdittingGameWithInvalidGameID()
        {
            Game game = new Game() { GameID = 0, VenueID = 1001, DateAndTime = DateTime.Now, SportID = 1000 };
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _gameManager.RemoveGame(game, 100000);

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorRemovingGameWithInvalidGameID()
        {
            Game game = new Game() { GameID = 0, VenueID = 1001, DateAndTime = DateTime.Now, SportID = 1000 };
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _gameManager.RemoveGame(game, 100000);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
