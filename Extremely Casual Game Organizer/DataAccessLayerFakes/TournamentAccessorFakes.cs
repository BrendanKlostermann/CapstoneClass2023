﻿/// Brendan Klostermann
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
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Constructor
        /// </summary>

        List<TournamentTeam> _tournamentTeams = new List<TournamentTeam>();
        List<TournamentTeamGame> _tournamentTeamsAndGames = new List<TournamentTeamGame>();
        List<TournamentGenerateGames> _tournamentGenerateGames = new List<TournamentGenerateGames>();

        public TournamentAccessorFakes()
        {
            _tournaments = new List<Tournament>();

            _tournamentTeams.Add(new TournamentTeam()
            {
                TournamentID = 100,
                TeamID = 1001
            });

            _tournamentTeamsAndGames.Add(new TournamentTeamGame()
            {
                TournamentID = 100,
                GameID = 1001,
                TeamID = 1001
            });

            _tournaments.Add(new Tournament()
            {
                Description = "This is a tournament of NBA PlayOffs",
                TournamentID = 100,
                MemberID = 1000,
                SportID = 1009,
                Active = true,
                Gender = true,
                Name = "NBA PlayOffs"
            });
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This method inserts a new Tournament into the database
        public int InsertTournament(Tournament tm)
        {
            // _tournaments = new List<Tournament>();
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



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Insert team to a tournament
        /// </summary>
        public int AddTeamToTournament(TournamentTeam tournamentTeam)
        {
            if (tournamentTeam.TeamID>0 && tournamentTeam.TournamentID>0)
            {
                _tournamentTeams.Add(tournamentTeam);
            }

            return _tournamentTeams.Count;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select All tournaments
        /// </summary>
        public List<Tournament> GetTournaments()
        {
            return _tournaments;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select tournament team by tournament_ID
        /// </summary>
        public List<TournamentTeam> GetTournamentTeamByID(int tournament_id)
        {
            var tournaments = _tournamentTeams.Where(b => b.TournamentID == tournament_id).ToList();

            if (tournaments == null)
            {
                throw new ApplicationException("Tournament not found.");
            }

            return tournaments;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove a team from tournament
        /// </summary>
        public int RemoveTeamToTournament(TournamentTeam tournamentTeam)
        {
            var team = _tournamentTeams.Where(b => b.TournamentID == tournamentTeam.TournamentID
                && b.TeamID == tournamentTeam.TeamID).ToList();

            if (team == null || team.Count <= 0)
            {
                return 0;
            }

            int num = _tournamentTeams.FindIndex(b => b.TournamentID == tournamentTeam.TournamentID
                && b.TeamID == tournamentTeam.TeamID);
            _tournamentTeams.Remove(_tournamentTeams[num]);
            return 1;
        }

        public int UpdateTournament(int memberid, Tournament tm)
        {
            int count = 0;
            foreach(Tournament tourn in _tournaments)
            {
                if(tourn.TournamentID == memberid)
                {
                    tourn.Description = tm.Description;
                    tourn.Gender = tm.Gender;
                    tourn.Name = tm.Name;
                    tourn.SportID = tm.SportID;
                    count++;
                }
            }
            return count;
        }

        public Tournament SelectTournamentByTournamentID(int id)
        {
            Tournament tournament = null;
            foreach(Tournament tourn in _tournaments)
            {
                if(tourn.TournamentID == id)
                {
                    tournament = tourn;
                    break;
                }
            }
            if(tournament == null)
            {
                return null;
            }
            return tournament;
        }

        public int DeactivateTournament(int memberid, int tournamentID)
        {
            int count = 0;
            foreach(Tournament tourn in _tournaments)
            {
                if(tourn.TournamentID == memberid)
                {
                    tourn.Active = false;
                    count++;
                }
            }
            return count;
		}
		
        public List<TournamentTeamGame> SelectTournamentTeamAndGame(int tournament_id)
        {
            var tournaments = _tournamentTeamsAndGames.Where(b => b.TournamentID == tournament_id).ToList();

            if (tournaments == null)
            {
                throw new ApplicationException("Tournament not found.");
            }

            return tournaments;
        }

        public int InsertTournamentGame(TournamentGenerateGames tournamentGenerateGames)
        {
            if (tournamentGenerateGames.TeamID_1 > 0 && tournamentGenerateGames.TournamentID > 0)
            {
                _tournamentGenerateGames.Add(tournamentGenerateGames);
            }

            return _tournamentGenerateGames.Count;
        }

        public int deleteTournamentGameGenerated(int tournament_id)
        {
            var team = _tournamentGenerateGames.Where(b => b.TournamentID == tournament_id).ToList();

            if (team == null || team.Count <= 0)
            {
                return 0;
            }

            int num = _tournamentGenerateGames.FindIndex(b => b.TournamentID == tournament_id);
            _tournamentGenerateGames.Remove(_tournamentGenerateGames[num]);
            return 1;
        }

        public Tournament SelectTournamentByID(int tournament_id)
        {
            Tournament returnTournament = null;

            foreach (Tournament tournament in _tournaments)
            {
                if (tournament.TournamentID == tournament_id)
                {
                    returnTournament = tournament;
                    break;

                }

            }
            return returnTournament;
        }

        public int ActivateTournament(int memberid, int tournamentID)
        {
            int count = 0;
            foreach (Tournament tourn in _tournaments)
            {
                if (tourn.TournamentID == memberid)
                {
                    tourn.Active = true;
                    count++;
                }
            }
            return count;
        }

        public List<TournamentRequest> SelectRequestsByTournamentID(int TournamentID)
        {
            throw new NotImplementedException();
        }

        public int UpdateTournamentRequest(int RequestID, string Status)
        {
            throw new NotImplementedException();
        }

        public int AddATournamentRequest(TournamentRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Toney Hale
        /// Created: 2023/04/11
        /// 
        /// fakes registation for open or closed
        /// </summary>
        public int openOrCloseTournamentRegistration(int tournament_id, bool active)
        {
            throw new NotImplementedException();
        }
    }
}
