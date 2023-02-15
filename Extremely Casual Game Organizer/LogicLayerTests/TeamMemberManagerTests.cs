using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    [TestClass]
    public class TeamMemberManagerTests
    {
        ITeamMemberManager _teamMemberManager = null;
        [TestInitialize]
        public void TestSetup()
        {
            _teamMemberManager = new TeamMemberManager(new TeamMemberAccessorFake());
        }
        [TestMethod]
        public void TestInsertingMemberToTeamMember()
        {
            const int team_id = 1000;
            const int member_id = 1000;
            const string description = "New Member Role";
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _teamMemberManager.AddTeamMember(team_id, member_id, description);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
