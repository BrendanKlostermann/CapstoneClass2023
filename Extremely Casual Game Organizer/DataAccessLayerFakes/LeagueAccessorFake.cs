/// <summary>
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
            throw new NotImplementedException();
        }

        public List<League> SelectAllLeagues()
        {
            return _leagues;
        }

        public List<Team> SelectATeamByLeagueID(int leagueId)
        {
            throw new NotImplementedException();
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

        //// Elijah M. is currently working on this
        //public int UpdateLeagueActiveStatus(bool active)
        //{
        //    // DO SOMETHING WITH THIS
        //    throw new NotImplementedException();
        //}

        //// Elijah M. is currently working on this
        //public int UpdateLeagueRegistrationByLeagueIDByActive(League oldLeague, League newLeague)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues.
        /// 

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
    }
}
