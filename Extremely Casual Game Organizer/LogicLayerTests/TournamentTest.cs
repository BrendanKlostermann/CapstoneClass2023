/// <summary>
/// Heritier Otiom
/// Created: 2023/03/07
/// 
/// </summary>
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
    public class TournamentTest
    {

        private ITournamentManager _tournamentManager = null;
        [TestInitialize]
        public void TestSetup()
        {
            // In order for this line to work you must have a Logic Layer Accessor setup to allow a DataAccessor Interface.
            // This will allow the unit test to route to your data fakes instead the actual database.

            _tournamentManager = new TournamentManager(new TournamentAccessorFakes());
        }

        [TestMethod]
        public void AddTeamToTournamentGood()
        {
            //Arrange
            TournamentTeam tournamentTeam = new TournamentTeam()
            {
                TournamentID = 105,
                TeamID = 1001
            };

            //Act
            const int expectedResult = 2;
            int actualResult = _tournamentManager.AddTeamToTournament(tournamentTeam);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddTeamToTournamentBad()
        {
            //Arrange
            TournamentTeam tournamentTeam = new TournamentTeam()
            {
                TournamentID = 0, // Bad TournamentID
                TeamID = 0 // Bad TeamID
            };

            //Act
            const int expectedResult = 1;
            int actualResult = _tournamentManager.AddTeamToTournament(tournamentTeam);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        //me worked on this
        [TestMethod]
        public void RemoveTeamToTournamentGood()
        {
            //Arrange
            TournamentTeam tournamentTeam = new TournamentTeam()
            {
                TournamentID = 100,
                TeamID = 1001
            };

            //Act
            const int expectedResult = 1;
            int actualResult = _tournamentManager.RemoveTeamToTournament(tournamentTeam);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void RemoveTeamToTournamentBad()
        {
            //Arrange
            TournamentTeam tournamentTeam = new TournamentTeam()
            {
                TournamentID = 1002, // Bad tournament
                TeamID = 1001
            };

            //Act
            const int expectedResult = 0;
            int actualResult = _tournamentManager.RemoveTeamToTournament(tournamentTeam);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetTournamentTeamByIDGood()
        {
            //Arrange
            TournamentTeam tournamentTeam = new TournamentTeam()
            {
                TournamentID = 100,
                TeamID = 1001
            };

            //Act
            const int expectedResult = 1;
            List<TournamentTeam> TournamentTeams = _tournamentManager.GetTournamentTeamByID(tournamentTeam.TournamentID);

            int actualResult = 0;
            if (TournamentTeams.Count > 0) actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetTournamentTeamByIDBad()
        {
            //Arrange
            TournamentTeam tournamentTeam = new TournamentTeam()
            {
                TournamentID = 1004, // Bad tournament
                TeamID = 1001
            };

            //Act
            const int expectedResult = 0;
            List<TournamentTeam> TournamentTeams = _tournamentManager.GetTournamentTeamByID(tournamentTeam.TournamentID);

            int actualResult = 0;
            if (TournamentTeams.Count > 0) actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void CreateTournamentTestByCount()
        {
            List<Tournament> tournaments = _tournamentManager.RetrieveAllTournamnets();
            Tournament tourn = new Tournament()
            {
                TournamentID = 100100,
                Name = "Test 100",
                Description = "Test tourn",
                Gender = true,
                SportID = 100000,
                MemberID = 100001
            };
            tournaments.Add(tourn);
            Assert.AreEqual(5, tournaments.Count);
        }
        [TestMethod]
        public void DeactivateTournamentTestByCount()
        {
            List<Tournament> tournaments = _tournamentManager.GetTournaments();
            int count = 0;
            foreach(Tournament tourn in tournaments)
            {
                if(tourn.TournamentID == 100)
                {
                    _tournamentManager.DeleteTournament(tourn.MemberID, tourn.TournamentID);
                    count++;
                }
            }

            Assert.AreEqual(1, count);
        }
        [TestMethod]
        public void UpdateTouurnamentTestByCount()
        {
            List <Tournament> tournaments = _tournamentManager.RetrieveAllTournamnets();
            int count = 0;
            Tournament tournament = new Tournament()
            {
                TournamentID = 1,
                Name = "Test 100",
                Description = "Test 100 description",
                SportID = 100,
                MemberID = 100,
                Gender = true
            };
            foreach (Tournament tourn in tournaments)
            {
                if(tourn.TournamentID == tournament.TournamentID)
                {
                    if(_tournamentManager.EditTournament(tourn.MemberID, tournament))
                    {
                        count++;
                    }
                }
            }
            Assert.AreEqual(1, count);
        }
    }
}
