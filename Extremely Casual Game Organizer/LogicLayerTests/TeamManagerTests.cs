/// <summary>
/// Created By: Jacob Lindauer 
/// Date: 2023/20/02
/// 
/// Class to handle logic testing for team manager class.
/// </summary>
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
        /// <summary>
        /// Created By Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestRetrievingTeamByTeamID()
        {
            const int source = 1000;
            const int expectedResult = 1000;
            int actualResult = 0;

            actualResult =  _teamManager.RetrieveTeamByTeamID(source).TeamID;

            Assert.AreEqual(expectedResult, actualResult);
        }
        /// <summary>
        /// Created By Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestRetreivingTeamWithInvalidTeamID()
        {
            const int source = 2;
            int actualResult = 0;

            actualResult = _teamManager.RetrieveTeamByTeamID(source).TeamID;

        }
    }
}
