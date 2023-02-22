/// <LeagueAccessorTest>
/// Alex Korte
/// Created: 2023/02/05
/// 
/// </summary>
/// This class is used to test the league accessor methods
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayerFakes;
using LogicLayer;
using DataObjects;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class LeagueAccessorTest
    {
        private LeagueManager _lm = null;

        [TestInitialize]
        public void TestSetup()
        {
            _lm = new LeagueManager(new LeagueAccessorFake());
        }

        [TestMethod]
        public void testGettingAllLeagues()
        {
            var expected = 3;
            var actual = _lm.GetListOfLeagues();
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void getAllTeamsByLeagueID()
        {
            int leagueID = 1000;
            int expected = 1;
            int actual = _lm.GetAListOfTeamsByLeagueID(leagueID).Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void removeTeamFromLeague()
        {
            int leagueID = 1002;
            int teamID = 1003;
            int expected = 1;
            int actual = _lm.RemoveATeamFromALeagueByTeamIDAndLeagueID(teamID, leagueID);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeTeamFromLeagueInvalidInput()
        {
            int leagueID = 0;
            int teamID = 0;//1010 doesnt exist
            int expected = 1;
            int actual = _lm.RemoveATeamFromALeagueByTeamIDAndLeagueID(teamID, leagueID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void noListOfTeamsFound()
        {
            int leagueID = 0;
            int teamID = 0;//1010 doesnt exist
            int expected = 1;
            List<Team> actual = _lm.GetAListOfTeamsByLeagueID(leagueID);
        }
    }
}
