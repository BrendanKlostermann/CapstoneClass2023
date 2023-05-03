/// <ILeagueAccessor>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This is the interface for league accessor, getting the links and manipulating them
/// 
/// Elijah Morgan
/// Created: 2023/02/28
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
﻿/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the interface for the league accessor class.
/// 
/// </summary>
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

        List<Team> SelectATeamByLeagueID(int leagueId);

        List<LeagueGridVM> SelectLeaguesForGrid();

        int RemoveATeamFromALeague(int teamId, int leagueId);

        List<League> SelectLeaguesByTeamID(int team_id);

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
        /// Elijah Morgan & Alex Korte
        /// Created: 2023/02/28
        /// 
        /// 
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

        int AddALeague(League league);
        int RemoveALeague(int LeagueID);
        List<League> SelectLeaguesByMemberID(int MemberID);
        int ChangeLeagueRegistration(int LeagueID, bool OpenOrClose);
        int UpdateALeague(League league);

        List<LeagueRequest> SelectRequestsByLeagueID(int LeagueID);
        int UpdateRequestStatus(int RequestID, string Status);
        int AddARequest(LeagueRequest request);
        int AddTeamToLeague(int TeamID, int LeagueID);

    }
}
