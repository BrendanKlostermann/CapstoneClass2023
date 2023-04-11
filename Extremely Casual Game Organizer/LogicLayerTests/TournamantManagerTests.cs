/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is for testing the Tournament accessor class
/// 
/// </summary>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    
    [TestClass]
    public class TournamantManagerTests
    {
        ITournamentManager _tournamentManager;


        [TestInitialize]
        public void TestInitialize()
        {
            _tournamentManager = new TournamentManager(new TournamentAccessorFakes());
        }

        [TestMethod]
        public void TestRetrieveAllTournaments()
        {
            int actualResult = _tournamentManager.RetrieveAllTournamnets().Count;
            int expectedResult = 4;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetrieveAllTournamentVMs()
        {
            int actualResult = _tournamentManager.RetrieveAllTournamentVMs().Count;
            int expectedResult = 4;
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// Nick Vroom
        /// Created: 2023/04/10
        /// 
        /// This test method is for testing the SelectTournament method
        /// 
        /// </summary>
        /* [TestMethod]
        public void TestSelectTournament()
        {
            Tournament actualResult = _tournamentManager.SelectTournament(1);
            Tournament expectedResult = new Tournament
            {
                TournamentID = 1,
                SportName = "Baseball",
                Gender = "Undefined",
                GenderBool = true,
                CreatorName = "Dan",
                Name = "Test 1",
                Description = "Baseball tournament 1"
            };
            Assert.AreEqual(expectedResult.TournamentID, actualResult.TournamentID);
            Assert.AreEqual(expectedResult.SportName, actualResult.SportName);
        }*/


        [TestMethod]
        public void TestCreateTournamentSuccess()
        {
            Tournament tm = new Tournament()
            {
                TournamentID = 1,
                Gender = true,
                SportID = 2,
                MemberID = 11,
                Name = "Test",
                Description = "Test",
                Active = true
            };
            bool test = _tournamentManager.CreateTournament(tm);
            Assert.IsTrue(test);
        }

    }

}
