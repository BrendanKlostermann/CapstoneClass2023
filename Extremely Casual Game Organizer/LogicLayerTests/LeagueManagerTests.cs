/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// This is the test class for the LeagueManager method tests.
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

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
    public class LeagueManagerTests
    {
        private LeagueManager _leagueManager = null;

        [TestInitialize]
        public void SetupTests()
        {
            _leagueManager = new LeagueManager(new LeagueAccessorFake());
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This test is to determine if the RetrieveListOfLeagues method
        /// returns the correct amount of items as layed out in the 
        /// fake data constructor.
        /// </summary>
        /// 
        [TestMethod]
        public void TestRetreivingListOfLeagues()
        {
            int expectedResult = 3;
            List<League> _leagues = _leagueManager.RetrieveListOfLeagues();
            int actualResult = _leagues.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/26/02
        /// </summary>
        [TestMethod]
        public void TestRetrievingListOfLeaguesByTeamID()
        {
            const int source = 1000;
            const int expectedResult = 2;
            int actualResult = 0;

            actualResult = _leagueManager.RetrieveLeagueListByTeamID(source).Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRetrievingListOfLeaguesByTeamIDWithInvalidTeamID()
        {
            const int source = 0;
            const int expectedResult = 2;
            int actualResult = 0;

            actualResult = _leagueManager.RetrieveLeagueListByTeamID(source).Count;
        }
    }
}
