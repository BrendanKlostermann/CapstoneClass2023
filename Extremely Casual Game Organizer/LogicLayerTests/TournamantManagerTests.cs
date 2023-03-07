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


    }

}
