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
using DataObjects;
using System.Collections.Generic;

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


        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Test that the number of teams is equal to expected.
        /// 
        /// <remarks>
        /// Alex Korte
        /// Updated: y1989/03/28
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        [TestMethod]
        public void TestRetreivingAllTeams()
        {

            const int actual = 30;
            int expectedResults = _teamManager.RetrieveAllTeams().Count;

            Assert.AreEqual(expectedResults, actual);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Insert a good team
        /// </summary>
        [TestMethod]
        public void AddTeamGood()
        {
            // Arrange
            Team team = new Team()
            {
                TeamID = 0147,
                TeamName = null, // Name can't be null
                MemberID = 1230,
                SportID = 1002,
                Gender = true
            };

            // Act
            int expectedResult = 0;
            int actualResult = _teamManager.AddTeam(team);

            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Insert a wrong team
        /// </summary>
        [TestMethod]
        public void AddTeamBad()
        {
            // Arrange
            Team team = new Team()
            {
                TeamID = 0147,
                TeamName = null,
                MemberID = 1230,
                SportID = 1009,
                Gender = true
            };

            // Act
            int expectedResult = 0;
            int actualResult = _teamManager.AddTeam(team);

            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// Select team with the existing team ID
        /// </summary>
        [TestMethod]
        public void getTeamByIDGood()
        {
            // Arrange
            int memberID = 1001;

            // Act
            int expectedResult = 1;
            List<TeamMemberAndSport> sports = _teamManager.getTeamByMemberID(memberID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select team with the unexisting team ID
        /// </summary>
        [TestMethod]
        public void getTeamByIDBad()
        {
            // Arrange
            int memberID = 001;

            // Act
            int expectedResult = 0;
            List<TeamMemberAndSport> sports = _teamManager.getTeamByMemberID(memberID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// Select existing team team
        /// </summary>
        [TestMethod]
        public void getTeamByNameGood()
        {
            // Arrange
            string name = "Lakers";
            int sportID = 1009;

            // Act
            int expectedResult = 1;
            List<TeamSport> sports = _teamManager.getTeamByTeamName(name, sportID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select the unexisting team
        /// </summary>
        [TestMethod]
        public void getTeamByNameBad()
        {
            // Arrange
            string name = "Lak"; // Wrong team 
            int sportID = 10045;

            // Act
            int expectedResult = 0;
            List<TeamSport> sports = _teamManager.getTeamByTeamName(name, sportID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Garion Opiola
        /// Created: 2023/03/21
        /// 
        /// Proper team deactivate
        /// </summary>
        [TestMethod]
        public void TestRemoveTeamGood()
        {
            // Arrange
            

            // Act
            int expectedResult = 1;
            int actualResult = _teamManager.RemoveOwnTeam(1001, 1230);

            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Garion Opiola
        /// Created: 2023/03/21
        /// 
        /// incorrect team decativate
        /// </summary
        [TestMethod]
        public void TestRemoveTeamBad()
        {
            // Arrange
            

            // Act
            int expectedResult = 0;
            int actualResult = _teamManager.RemoveOwnTeam(1001, 1231);

            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestSelectTeamOwner()
        {
            // Arrange
            var teamManager = new TeamManager();

            // Act
            int expectedResult = 100040;
            int actualResult = teamManager.SelectTeamOwner(1000);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
    
}
