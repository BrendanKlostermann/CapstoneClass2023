using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    [TestClass]
    public class TeamManagerTests
    {
        ITeamManager _teamManager = null;
        
        [TestInitialize]
        public void TestSetup()
        {
            _teamManager = new TeamManager(new TeamAccessorFake());
        }
        [TestMethod]
        public void TestRetrievingTeamByTeamID()
        {
            const int source = 1000;
            const int expectedResult = 1000;
            int actualResult = 0;

            actualResult =  _teamManager.RetrieveTeamByTeamID(source).TeamID;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestRetreivingTeamWithInvalidTeamID()
        {
            const int source = 2;
            const int expectedResult = 1000;
            int actualResult = 0;

            actualResult = _teamManager.RetrieveTeamByTeamID(source).TeamID;

        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Test that the number of teams is equal to expected.
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        [TestMethod]
        public void TestRetreivingAllTeams()
        {

            const int actual = 15;
            int expectedResults = _teamManager.RetrieveAllTeams().Count;

            Assert.AreEqual(expectedResults, actual);
        }
    }
}
