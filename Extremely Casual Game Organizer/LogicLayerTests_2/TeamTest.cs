/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Team Test file
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataObjects;
using DataAccessLayerFakes;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class TeamTest
    {
        ITeamManager iTeamManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            // In order for this line to work you must have a Logic Layer Accessor setup to allow a DataAccessor Interface.
            // This will allow the unit test to route to your data fakes instead the actual database.

            iTeamManager = new TeamManager(new FakeTeamAccessor());
            //iTeamManager = new TeamManager();
        }

        [TestMethod]
        public void AddTeamGood()
        {
            // Arrange
            Team team = new Team()
            {
                TeamID = 0147,
                Name = null, // Name can't be null
                MemberID = 1230,
                SportID = 1002,
                Gender = true
            };

            // Act
            int expectedResult = 0;
            int actualResult = iTeamManager.AddTeam(team);

            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddTeamBad()
        {
            // Arrange
            Team team = new Team()
            {
                TeamID = 0147,
                Name = null,
                MemberID = 1230,
                SportID = 1009,
                Gender = true
            };

            // Act
            int expectedResult = 0;
            int actualResult = iTeamManager.AddTeam(team);

            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void getTeamByIDGood()
        {
            // Arrange
            int memberID = 1001;

            // Act
            int expectedResult = 1;
            List<TeamMemberAndSport> sports = iTeamManager.getTeamByMemberID(memberID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void getTeamByIDBad()
        {
            // Arrange
            int memberID = 001;

            // Act
            int expectedResult = 0;
            List<TeamMemberAndSport> sports = iTeamManager.getTeamByMemberID(memberID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void getTeamByNameGood()
        {
            // Arrange
            string name = "Lakers";
            int sportID = 1009;

            // Act
            int expectedResult = 1;
            List<TeamSport> sports = iTeamManager.getTeamByTeamName(name, sportID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void getTeamByNameBad()
        {
            // Arrange
            string name = "Lak";
            int sportID = 10045;

            // Act
            int expectedResult = 0;
            List<TeamSport> sports = iTeamManager.getTeamByTeamName(name, sportID);

            int actualResult = 0;
            if (sports != null) actualResult = sports.Count;
            // Test
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
