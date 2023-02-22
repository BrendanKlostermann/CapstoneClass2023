using DataAccessFakes;
using System.Collections.Generic;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataObjects;
using System;

namespace LogicLayerTests
{
    [TestClass]
    public class TeamRolesManagerTests
    {
        private TeamRolesManager _teamRolesManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _teamRolesManager = new TeamRolesManager(new TeamRoleAccessorFakes());
        }

        [TestMethod]
        public void TestRetriveTeamRolesReturnCorrectList()
        {
            // Arragne
            int expectedResult = 2;
            int actualResult = 0;

            // Act
            var teamRoles = _teamRolesManager.RetrieveTeamRoles();
            actualResult = teamRoles.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
