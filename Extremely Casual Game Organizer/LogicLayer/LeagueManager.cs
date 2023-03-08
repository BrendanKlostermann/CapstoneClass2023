/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// An manager class that is used to handle the 
/// League object
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class LeagueManager : ILeagueManager
    {
        private ILeagueAccessor _leagueAccessor = null;

        public LeagueManager()
        {
            _leagueAccessor = new LeagueAccessor();
        }

        public LeagueManager(ILeagueAccessor leagueAccessor)
        {
            _leagueAccessor = leagueAccessor;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Retrieves a list of active leagues.
        /// 
        /// <param name="active">a boolean set to true so that we can retrieve the active Leagues</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>All active Leagues</returns>
        public List<League> RetrieveLeagueByActiveStatus(bool active = true)
        {
            List<League> leagues = new List<League>();

            try
            {
                leagues = _leagueAccessor.SelectLeagueByActiveStatus(active);
            }
            catch (Exception)
            {
                throw;
            }

            return leagues;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects a League by a LeagueID.
        /// 
        /// <param name="leagueID">The LeagueID for the League we want</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>A league with a LeagueID matching the parameter's value</returns>
        public League RetrieveLeagueByLeagueID(int leagueID)
        {
            League league = new League();

            try
            {
                league = _leagueAccessor.SelectLeagueByLeagueID(leagueID);
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("Invalid league ID", up);
            }

            return league;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues.
        /// 
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>All Leagues</returns>
        public List<League> RetrieveAllLeagues()
        {
            List<League> leagues = new List<League>();

            try
            {
                leagues = _leagueAccessor.SelectAllLeagues();
            }
            catch (ApplicationException up)
            {
                throw new ApplicationException("Error, please try again later", up);
            }

            return leagues;
        }

        // Elijah M. is currently working on this
        ///// <summary>
        ///// Elijah
        ///// Created: 2023/02/28
        ///// 
        ///// Edits the registration status of the league.
        ///// 
        ///// <param name="oldLeague">A League that is passed to obtain the old data</param>
        ///// <param name="newLeague">A League that is passed input the new data</param>
        ///// <exception cref="SQLException">Data not found</exception>
        ///// <returns>An updated League</returns>
        //public bool EditLeagueRegistration(League oldLeague, League newleague)
        //{
        //    bool result = false;
        //    try
        //    {
        //        result = (1 == _leagueAccessor.UpdateLeagueRegistrationByLeagueIDByActive(oldLeague, newleague));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Edits a League.
        /// 
        /// <param name="oldLeague">A League that is passed to obtain the old data</param>
        /// <param name="newLeague">A League that is passed input the new data</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>An eddited League</returns>
        public bool EditLeague(League oldLeague, League newLeague)
        {
            bool result = false;
            try
            {
                result = (1 == _leagueAccessor.UpdateLeague(oldLeague, newLeague));
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("invalid ids", up);
            }
            // look into making an exception if dues is too high
            // look into exception if league name is too long
            // add an if statement for profanity filter
            return result;
        }

        // Elijah M. is currently working on this
        ///// <summary>
        ///// Elijah
        ///// Created: 2023/02/28
        ///// 
        ///// Edits the active status of the League.
        ///// 
        ///// <param name="active">a boolean set to true so that we can retrieve the active Leagues</param>
        ///// <exception cref="SQLException">Data not found</exception>
        ///// <returns>An updated League</returns>
        //public bool EditLeagueActiveStatus(bool active)
        //{
        //    bool result = false;
        //    try
        //    {
        //        //result = _leagueAccessor.UpdateLeagueActiveStatus(active);
        //        // make an if statement to check rows affected (1 row affected = true)
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}

        public List<League> RetrieveListOfLeagues()
        {
            List<League> leagueList = null;
            try
            {
                leagueList = _leagueAccessor.SelectListOfLeagues();
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed loading League list", ex);
            }

            return leagueList;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects a League with the associated SportID.
        /// 
        /// <param name="sportID">The SportID we are looking for from all Leagues</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>An list of League's with the wanted SportID</returns>
        public League RetrieveLeagueBySportID(int sportID)
        {
            League leagues = new League();

            try
            {
                leagues = _leagueAccessor.SelectLeaguesBySportID(sportID);
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("Sport ID is invalid", up);
            }

            return leagues;
        }
    }
}
