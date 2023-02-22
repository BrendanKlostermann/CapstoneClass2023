/// <LeagueManager>
/// Alex Korte
/// Created: 2023/02/05
/// 
/// </summary>
/// This class Used to create the league manager,, getting a list of all
/// leagues, teams on leagues, and remove a team from a league
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
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

        public LeagueManager(ILeagueAccessor la)
        {
            _leagueAccessor = la;
        }



        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to get a list of teams in a specific league through leagueID
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Team> GetAListOfTeamsByLeagueID(int leagueID)
        {
            try
            {
                List<Team> _returnedList = _leagueAccessor.SelectATeamByLeagueID(leagueID);
                if(_returnedList == null || _returnedList.Count == 0)
                {
                    throw new ArgumentException("There was no data to load");
                }
                else
                {
                    return _returnedList;
                }
            }
            catch (ApplicationException up)
            {
                throw new ApplicationException("Failed to populate list", up);
            }
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to get a list of all leagues (as objects)
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<League> GetListOfLeagues()
        {
            try
            {
                return _leagueAccessor.SelectAllLeagues();
            }catch(ApplicationException up)
            {
                throw new ApplicationException("List failed to populate", up);
            }
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to remove a specific team from a specific league
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int RemoveATeamFromALeagueByTeamIDAndLeagueID(int teamID, int leagueID)
        {
            int results = 0;
            try
            {
                results = _leagueAccessor.RemoveATeamFromALeague(teamID, leagueID);
                if(results == 0)
                {
                    throw new ArgumentException("Invalid input error");
                }
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("Invalid input error", up);
            }
            catch (ApplicationException up)
            {
                throw up;
            }
            return results;
        }
    }
}
