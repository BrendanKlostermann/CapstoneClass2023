/// <ILeagueManager>
/// Alex Korte & Elijah Morgan
/// Created: 2023/01/24 & 2023/02/28
/// 
/// </summary>
/// This is an interface that helps control leauges
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

/// <summary>
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

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/26/02
        /// </summary>
        List<League> RetrieveLeagueListByTeamID(int team_id);

        List<LeagueGridVM> RetrieveListOfLeaguesForGrid();

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
        int AddLeague(League league);

        bool RemoveLeague(int LeagueID);

        List<League> RetrieveLeagueListByMemberID(int MemberID);

        bool ChangeRegistration(int LeagueID, bool OpenOrClose);

        bool UpdateALeague(League league);

        List<LeagueRequest> RetrieveRequestsByLeagueID(int LeagueID);
        bool UpdateRequestStatus(int RequestID, string Status);
        bool AddRequest(LeagueRequest request);
        bool AddTeamToLeague(int TeamID, int LeagueID);

        List<Team> RetrieveNotRequestedTeams(int MemberID, int LeagueID);

        List<LeagueRequestVM> RetrieveLeagueRequestVMs(List<LeagueRequest> LeagueRequests);
    }
}
