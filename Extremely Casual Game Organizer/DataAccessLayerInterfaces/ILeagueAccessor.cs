/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// An interface that manages the LeagueAccessor class
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

namespace DataAccessLayerInterfaces
{
    public interface ILeagueAccessor
    {
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Selects leagues by active status
        /// </summary>
        ///
        List<League> SelectLeagueByActiveStatus(bool active);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Selects a League by a leagueID
        /// </summary>
        ///
        League SelectLeagueByLeagueID(int leagueID);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Selects all current leagues
        /// </summary>
        ///
        List<League> SelectAllLeagues();
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// 
        /// </summary>
        ///
        // Elijah M. is currently working on this
        //int UpdateLeagueRegistrationByLeagueIDByActive(League oldLeague, League newLeague);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Updates a league with new information
        /// </summary>
        ///
        int UpdateLeague(League oldLeague, League newLeague);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Updates the active status of a league
        /// </summary>
        ///
        // Elijah M. is currently working on this
        //int UpdateLeagueActiveStatus(bool active);
        List<League> SelectListOfLeagues();
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues with a specified sportID
        /// </summary>
        ///
        League SelectLeaguesBySportID(int sportID);
    }
}
