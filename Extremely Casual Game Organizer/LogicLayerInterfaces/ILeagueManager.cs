
﻿/// <ILeagueManager>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This is an interface that helps control leauges
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

﻿/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This is the interface class for the LeagueManager
/// 
/// </summary>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface ILeagueManager
    {
        /// <summary>

        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// -GetListOfLeagues will get a list of all Leagues (as objects)
        /// -GetAListOfTeamsByLeagueID gets a list of all teams that are in a specific  league
        /// -RemoveATeamFromALeagueByTeamAndLeagueID will remove a team from a specific league
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        List<League> GetListOfLeagues();

        List<Team> GetAListOfTeamsByLeagueID(int leagueID);

        int RemoveATeamFromALeagueByTeamIDAndLeagueID(int teamId, int leagueID);

        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method calls the LeagueAccessor method SelectListOfLeagues and returns it to the 
        /// presentation layer. 
        /// </summary>
        /// 
        /// <returns>List of League objects</returns>
        List<League> RetrieveListOfLeagues();
	}

}
