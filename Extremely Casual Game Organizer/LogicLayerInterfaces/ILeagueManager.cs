/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// An interface that manages the LeagueManager class
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

namespace LogicLayerInterfaces
{
    public interface ILeagueManager
    {
        List<League> RetrieveListOfLeagues();
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Retrieves a league by its active status
        /// </summary>
        ///
        List<League> RetrieveLeagueByActiveStatus(bool Active = true);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Retrieve a League by a leagueID
        /// </summary>
        ///
        League RetrieveLeagueByLeagueID(int LeagueID);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Retrieves all leagues
        /// </summary>
        ///
        List<League> RetrieveAllLeagues();
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// 
        /// </summary>
        ///
        // Elijah M. is currently working on this
        //bool EditLeagueRegistration(League OldLeague, League NewlLeague);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Edits a League
        /// </summary>
        ///
        bool EditLeague(League OldLeague, League NewlLeague);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Edits a league by its activity status
        /// </summary>
        ///
        // Elijah M. is currently working on this
        //bool EditLeagueActiveStatus(bool Active);
        /// <summary>
        /// Elijah Morgan
        /// Created: 2023/02/28
        /// 
        /// Retrieves leagues by sportID
        /// </summary>
        ///
        League RetrieveLeagueBySportID(int SportID);
    }
}
