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
            const int source = 0;
            const int expectedResult = 2;
            int actualResult = 0;

            var rosterList = _gameRosterManager.RetrieveGameRoster(source);
        }
    }
}
