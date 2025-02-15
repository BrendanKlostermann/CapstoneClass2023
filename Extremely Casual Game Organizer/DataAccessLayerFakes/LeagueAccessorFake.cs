﻿/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is fake data for the League accessor
/// 
/// Updated By: Jacob Lindauer
/// Date: 2023/02/26
/// 
/// Added method for SelectLeaguesByTeamID()
/// Also added _leagueTeams in class variables and created list in consturctor.
/// 
/// </summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// A class of fakes, used to test the LeagueAccessor
/// methods
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class LeagueAccessorFake : ILeagueAccessor
    {
        List<League> _leagues = null;
        List<LeagueTeam> _leagueTeams = null;

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This constructor creates a list of fake data for the class to use.
        /// </summary>
        private List<League> fakeLeagues = new List<League>();
        public LeagueAccessorFake()
        {
            fakeLeagues.Add(new League()
            {
                LeagueID = 9999,
                SportID = 9999,
                LeagueDues = 5000.00m,
                Active = true,
                MemberID = 999999,
                Gender = false,
                Description = "A Magic The Gathering League",
                Name = "MTG League",
                MaxNumOfTeams = 65
            });
            fakeLeagues.Add(new League()
            {
                LeagueID = 9998,
                SportID = 9998,
                LeagueDues = 15634.26m,
                Active = true,
                MemberID = 123456,
                Gender = true,
                Description = "A soccer league",
                Name = "Soccer League",
                MaxNumOfTeams = 4
            });
            fakeLeagues.Add(new League()
            {
                LeagueID = 9997,
                SportID = 9997,
                LeagueDues = 0.00m,
                Active = false,
                MemberID = 123456,
                Gender = true,
                Description = "A football league",
                Name = "Football League",
                MaxNumOfTeams = 64
            });

            _leagues = new List<League>();
            League league1 = new League(100000, 100000, 12.34m, true, 100000, true, "test league 1", "test1", 8);
            _leagues.Add(league1);
            League league2 = new League(100001, 100001, 34.34m, false, 100020, true, "test league 2", "test2", 4);
            _leagues.Add(league2);
            League league3 = new League(100002, 100002, 132.34m, true, 123049, false, "test league 3", "test3", 2);
            _leagues.Add(league3);

            // Create list for League Team list
            _leagueTeams = new List<LeagueTeam>()
            {
                new LeagueTeam
                {
                    TeamID = 1000,
                    LeagueID = 100000
                },
                new LeagueTeam
                {
                    TeamID = 1000,
                    LeagueID = 100001
                },
                new LeagueTeam
                {
                    TeamID = 1001,
                    LeagueID = 100000
                }
            };
        }

        public int RemoveATeamFromALeague(int teamId, int leagueId)
        {
            int countControl = 0;
            for (int i = 0; i < _leagueTeams.Count; i++)
            {
                if (_leagueTeams[i].TeamID == teamId && _leagueTeams[i].LeagueID == leagueId)
                {
                    _leagueTeams.Remove(_leagueTeams[i]);
                    countControl++;
                }
            }
            return countControl;
        }

        public List<League> SelectAllLeagues()
        {
            return _leagues;
        }

        public List<Team> SelectATeamByLeagueID(int leagueId)
        {
            List<Team> teamsInLeague = new List<Team>();

            foreach (var team in _leagueTeams)
            {
                if (team.LeagueID == leagueId)
                {
                    teamsInLeague.Add(new Team() { TeamID = team.TeamID });
                }
            }
            return teamsInLeague;
        }

        public List<LeagueGridVM> SelectLeaguesForGrid()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Created by: Jacob Lindauer
        /// Date: 2023/26/02
        /// 
        /// Method to get the league ID's from the leagueTeam list and obtain a list of leagues from leaugeList for return result.
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public List<League> SelectLeaguesByTeamID(int team_id)
        {
            List<League> leagueList = new List<League>();

            // Need to get a league ID's the team is a member of and select those leagueID's
            var leagueTeams = _leagueTeams.Where(x => x.TeamID.Equals(team_id)).Select(x => x.LeagueID);

            // Take LeagueIDs and get League objects, add those to return list.
            foreach (var league in leagueTeams)
            {
                var leagueQuery = from row in _leagues.AsEnumerable() where row.LeagueID.Equals(league) select row;
                // Query should only return one result as leagueIDs are primary keys.
                leagueList.Add(leagueQuery.First());
            }

            if (leagueList.Count() == 0)
            {
                throw new ArgumentException("No leagues found for TeamdID");
            }
            return leagueList;
        }


        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects leagues by their active status.
        /// 
        public List<League> SelectLeagueByActiveStatus(bool active)
        {
            List<League> leagues = new List<League>();
            foreach (var league in fakeLeagues)
            {
                if (league.Active == true)
                {
                    leagues.Add(league);
                }
            }
            return leagues;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects a league by a LeagueID.
        /// 
        public League SelectLeagueByLeagueID(int LeagueID)
        {
            League selectedLeague = new League();
            foreach (var league in fakeLeagues)
            {
                if (league.LeagueID == LeagueID)
                {
                    selectedLeague = league;
                    break;
                }
            }
            return selectedLeague;
        }

        public int UpdateLeague(League oldLeague, League newLeague)
        {
            throw new NotImplementedException();
        }


        public List<League> SelectListOfLeagues()
        {
            return _leagues;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues by their current SportID.
        /// 
        public League SelectLeaguesBySportID(int SportID)
        {
            League selectedLeague = new League();
            foreach (var league in fakeLeagues)
            {
                if (league.LeagueID == SportID)
                {
                    selectedLeague = league;
                    break;
                }
            }
            return selectedLeague;
        }

        public int AddALeague(League league)
        {
            int count = _leagues.Count();
            League _league = new League()
            {
                LeagueID = league.LeagueID,
                SportID = league.SportID,
                LeagueDues = league.LeagueDues,
                Active = league.Active,
                MemberID = league.MemberID,
                Gender = league.Gender,
                Description = league.Description,
                Name = league.Name,
                MaxNumOfTeams = league.MaxNumOfTeams
            };
            _leagues.Add(league);
            if ((_leagues.Count() - 1) == count)
            {
                return league.LeagueID;
            }
            else
            {
                return 0;
            }
        }

        public int RemoveALeague(int LeagueID)
        {
            foreach (League league in _leagues)
            {
                if (league.LeagueID == LeagueID)
                {
                    fakeLeagues.Remove(league);
                    return 1;
                }
            }
            return 0;
        }

        public List<League> SelectLeaguesByMemberID(int MemberID)
        {
            List<League> leagues = new List<League>();
            foreach (League league in _leagues)
            {
                if (league.MemberID == MemberID)
                {
                    leagues.Add(league);
                }
            }
            return leagues;
        }

        public int ChangeLeagueRegistration(int LeagueID, bool OpenOrClose)
        {
            foreach (League league in _leagues)
            {
                if (league.LeagueID == LeagueID)
                {
                    league.Active = OpenOrClose;
                    return 1;
                }
            }
            return 0;
        }

        public int UpdateALeague(League league)
        {
            foreach (League _league in _leagues)
            {
                if (league.LeagueID == _league.LeagueID)
                {
                    _league.LeagueDues = league.LeagueDues;
                    _league.Active = league.Active;
                    _league.Gender = league.Gender;
                    _league.Description = league.Description;
                    _league.Name = league.Name;
                    _league.MaxNumOfTeams = league.MaxNumOfTeams;
                    return 1;
                }
            }
            return 0;
        }

        public List<LeagueRequest> SelectRequestsByLeagueID(int LeagueID)
        {
            throw new NotImplementedException();
        }

        public int UpdateRequestStatus(int RequestID, string Status)
        {
            throw new NotImplementedException();
        }

        public int AddARequest(LeagueRequest request)
        {
            throw new NotImplementedException();
        }

        public int AddTeamToLeague(int TeamID, int LeagueID)
        {
            throw new NotImplementedException();
        }
    }
}
