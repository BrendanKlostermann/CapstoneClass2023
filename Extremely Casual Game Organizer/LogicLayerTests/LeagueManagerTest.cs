using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataObjects;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using LogicLayer;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class LeagueManagerTest
    {
        private LeagueManager _leagueManager = null;

        [TestInitialize]
        public void SetupTests()
        {
            _leagueManager = new LeagueManager(new LeagueAccessorFake());
        }

        [TestMethod]
        public void TestMethod1()
        {
            int expectedResult = 3;
            List<League> _leagues = _leagueManager.RetrieveListOfLeagues();
            int actualResult = _leagues.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
