/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// I Team Manager
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data;

namespace LogicLayerInterfaces
{
    public interface ITeamManager
    {
        Team RetrieveTeamByTeamID(int team_id);

        List<Team> RetrieveAllTeams();
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a new team
        /// </summary>
        int AddTeam(Team team);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get sport description
        /// </summary>
        List<string> getSportName();


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Search a team by name
        /// </summary>
        List<TeamSport> getTeamByTeamName(string name, int sport_id);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all teams a user is into
        /// </summary>
        List<TeamMemberAndSport> getTeamByMemberID(int member_id); //Get team by member ID and details about the sport, gender and others.

        /// <summary>
        /// Garion Opiola
        /// Created: 2023/03/21
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// removes a team that's not in a league
        int RemoveOwnTeam(int teamID, int memberID);

        /// <summary>
        /// Nick Vroom
        /// Created: 2023/04/18
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Gets the team owner's member ID
        int SelectTeamOwner(int teamID);

        List<TeamRequest> RetrieveRequestByTeamID(int TeamID);

        bool UpdateTeamRequestStatus(int RequestID, string Status);

        bool CreateATeamRequest(int TeamID, int MemberID);
    }
}
