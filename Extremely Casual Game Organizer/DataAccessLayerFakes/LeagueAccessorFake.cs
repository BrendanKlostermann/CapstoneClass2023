/// <summary>
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
        private List<League> fakeLeagues = new List<League>();
        public LeagueAccessorFake()
        {
            _leagues = new List<League>();
            League league1 = new League(100000, 100000, 12.34m, true, 100000, true, "test league 1", "test1", 8);
            _leagues.Add(league1);
            League league2 = new League(100001, 100001, 34.34m, false, 100020, true, "test league 2", "test2", 4);
            _leagues.Add(league2);
            League league3 = new League(100002, 100002, 132.34m, true, 123049, false, "test league 3", "test3", 2);
            _leagues.Add(league3);

            fakeLeagues.Add(new League()
            {
                LeagueID = 9999,
                SportID = 9999,
                LeagueDues = 5000.00m,
                Active = true,
                MemberID = 999999,
                Gender = false,
                LeagueDescription = "A Magic The Gathering League",
                Name = "MTG League",
                MaxNumberOfTeams = 65
            });
            fakeLeagues.Add(new League()
            {
                LeagueID = 9998,
                SportID = 9998,
                LeagueDues = 15634.26m,
                Active = true,
                MemberID = 123456,
                Gender = true,
                LeagueDescription = "A soccer league",
                Name = "Soccer League",
                MaxNumberOfTeams = 4
            });
            fakeLeagues.Add(new League()
            {
                LeagueID = 9997,
                SportID = 9997,
                LeagueDues = 0.00m,
                Active = false,
                MemberID = 123456,
                Gender = true,
                LeagueDescription = "A football league",
                Name = "Football League",
                MaxNumberOfTeams = 64
            });
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues.
        /// 
        public List<League> SelectAllLeagues()
        {
            return fakeLeagues;
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
