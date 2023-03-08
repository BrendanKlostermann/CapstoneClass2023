/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// A class that runs tests for the league layer
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

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
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
        public void TestRetreivingListOfLeagues()
        {
            int expectedResult = 3;
            List<League> _leagues = _leagueManager.RetrieveListOfLeagues();
            int actualResult = _leagues.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
