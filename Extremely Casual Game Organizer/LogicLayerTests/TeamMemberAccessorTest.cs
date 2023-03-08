/// <TeamMemberccessorTest>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to test teammember accessors
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataObjects;
using DataAccessLayerFakes;

namespace LogicLayerTests
{
    [TestClass]
    public class TeamMemberAccessorTest
    {
        private TeamMemberManager _teamMemberManager = null;
        private MemberManager _memberManager = null;



        [TestInitialize]
        public void TestSetup()
        {
            _teamMemberManager = new TeamMemberManager(new TeamAccessorFake());
            _memberManager = new MemberManager(new MemberAccessorFake());
            

        }

        [TestMethod]
        public void TestGettingAllUsers()
        {
            var expected = 2;
            var team_id = 1000;
            var actual = _memberManager.GetAListOfMembersByTeamID(team_id);
            Assert.AreEqual(expected, actual.Count);
        }


        [TestMethod]
        public void TestRemovingAPlayerFromATeam()
        {
            var expected = 1;
            var team_id = 1000;
            var member_id = 100000;
            var actual = _teamMemberManager.RemoveAPlayerFromATeamByTeamIDAndMemberID(member_id, team_id);
            Assert.AreEqual(expected, actual);  
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemovingAPlayerFromATeamWithInvalidInput()
        {
            var expected = 1;
            var team_id = 10000;//one extra 0
            var member_id = 100000;
            var actual = _teamMemberManager.RemoveAPlayerFromATeamByTeamIDAndMemberID(member_id, team_id);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGettingANullOnGettingListOfMembers()
        {
            var expected = 1;
            var team_id = 0;// 0
            var actual = _memberManager.GetAListOfMembersByTeamID(team_id);
        }

        [TestMethod]
        public void DeleteAMemberFromATeamByMemberIdAndTeamID()
        {
            int expected = 1;
            int teamID = 1000;
            int memberID = 10001;
            int actual = _teamMemberManager.RemoveAPlayerFromATeamByTeamIDAndMemberID(teamID, memberID);

            Assert.AreEqual(expected, actual);
        }
    }
}
