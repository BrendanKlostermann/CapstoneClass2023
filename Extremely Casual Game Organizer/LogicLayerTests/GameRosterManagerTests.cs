/// /// <summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Unit Testing for for GameRosterManager classes.
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using LogicLayer;
using System.Linq;

namespace LogicLayerTests
{
    [TestClass]
    public class GameRosterManagerTests
    {
        IGameRosterManager _gameRosterManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _gameRosterManager = new GameRosterManager(new GameRosterAccessorFake());
        }
        [TestMethod]
        public void TestRetreivingGameRosterList()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
            const int source = 1000;
            const int expectedResult = 2;
            int actualResult = 0;

            var rosterList = _gameRosterManager.RetrieveGameRoster(source);
            // Linq to get distinct team ID for roster list baesd on the game ID. Doing this to verify method pulled expected result.
            actualResult = rosterList.Select(x => x.TeamID).Distinct().Count();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvaidGameIDForRetrievingGameRosterList()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
            const int source = 0;
            const int expectedResult = 2;
            int actualResult = 0;

            var rosterList = _gameRosterManager.RetrieveGameRoster(source);
        }
    }
}
