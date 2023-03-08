/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is used to send fake data to the logic layer to test the logic layer methods.
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class TournamentAccessorFakes : ITournamentAccessor
    {
        List<Tournament> _tournaments = null;
        List<TournamentVM> _tournamentVMs = null;


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This method inserts a new Tournament into the database
        public int InsertTournament(Tournament tm)
        {
            _tournaments = new List<Tournament>();
            _tournaments.Add(tm);

            return 1;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This method returns a list of fake data for selecting all tournaments
        public List<Tournament> SelectAllTournaments()
        {
            _tournaments = new List<Tournament>()
            {
            new Tournament
            {
                TournamentID = 1,
                SportID = 1,
                Gender = true,
                MemberID = 1,
                Name = "Test 1",
                Description = "This is a test",
                Active = true
            },
            new Tournament
            {
                TournamentID = 2,
                SportID = 4,
                Gender = true,
                MemberID = 2,
                Name = "Test 2",
                Description = "This is a test",
                Active = true
            },
            new Tournament
            {
                TournamentID = 3,
                SportID = 2,
                Gender = true,
                MemberID = 7,
                Name = "Test 3",
                Description = "This is a test",
                Active = true
            },
            new Tournament
            {
                TournamentID = 4,
                SportID = 12,
                Gender = false,
                MemberID = 1,
                Name = "Test 1",
                Description = "This is a test",
                Active = false
            }
            };


            return _tournaments;
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This method returns a list of fake data for selecting all tournamentVMs
        public List<TournamentVM> SelectAllTournamentVMs()
        {
            _tournamentVMs = new List<TournamentVM>()
            {
                new TournamentVM
                {
                    TournamentID = 1,
                    SportName = "Baseball",
                    Gender = "Undefined",
                    GenderBool = true,
                    CreatorName = "Dan",
                    Name = "Test 1",
                    Description = "Baseball tournament 1"
                },
                new TournamentVM
                {
                    TournamentID = 2,
                    SportName = "Basketball",
                    Gender = "Undefined",
                    GenderBool = true,
                    CreatorName = "Blake",
                    Name = "Test 2",
                    Description = "Basketball tournament 1"
                },
                new TournamentVM
                {
                    TournamentID = 3,
                    SportName = "Basketball",
                    Gender = "Undefined",
                    GenderBool = false,
                    CreatorName = "Dan",
                    Name = "Test 3",
                    Description = "Baseball tournament 1"
                },
                new TournamentVM
                {
                    TournamentID = 4,
                    SportName = "Soccer",
                    Gender = "Undefined",
                    GenderBool = false,
                    CreatorName = "Sam",
                    Name = "Test 4",
                    Description = "Soccer tournament 1"
                }
            };


            return _tournamentVMs;
        }
    }
}
