/// <summary>
/// Brendan Klostermann & Elijah Morgan
/// Created: 2023/01/31 & Created: 2023/02/28
/// 
/// This is the test class for the LeagueManager method tests.
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using DataObjects;

namespace LogicLayerTests
{
    [TestClass]
    public class LeagueManagerTests
    {
        private LeagueManager _leagueManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _leagueManager = new LeagueManager(new LeagueAccessorFake());
        }


        /// Elijah & Brendan Klostermann
        /// Created: 2023/02/28 & 2023/02/20
        /// 
        /// Retrieves all active leagues.
        /// 
        [TestMethod]
        public void TestRetrieveLeagueByActiveReturnsCorrectList()
        {
            // arrange
            bool active = true;
            int expectedCount = 2;
            int actualCount = 0;

            // act
            actualCount = (_leagueManager.RetrieveLeagueByActiveStatus(active).Count);

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// retrieves all Leagues.
        /// 
        [TestMethod]
        public void TestRetrieveAllLeaguesReturnsCorrectList()
        {
            // arrange
            const int expectedCount = 3;
            int actualCount;

            // act
            actualCount = (_leagueManager.RetrieveAllLeagues()).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrievingListOfLeagues()
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

        [TestMethod]
        public void testAddingALeague()
        {
            var expected = 100004;
            League league = new League(100004, 100002, 300m, true, 123049, false, "test league 3", "test3", 2);
            var actual = _leagueManager.AddLeague(league);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testUpdatingALeague()
        {
            var expected = 300m;
            League league = new League(100002, 100002, 300m, true, 123049, false, "test league 3", "test3", 2);
            _leagueManager.UpdateALeague(league);
            List<League> leagues = _leagueManager.GetListOfLeagues();
            var actual = leagues[2].LeagueDues;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testDeleteALeague()
        {
            var expected = true;
            var actual = _leagueManager.RemoveLeague(100000);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testChangeLeagueRegistration()
        {
            var expected = true;
            var actual = _leagueManager.ChangeRegistration(100000, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRetrievingListOfLeaguesByMemberID()
        {
            const int source = 100000;
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _leagueManager.RetrieveLeagueListByMemberID(source).Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
