
/// <ITeamAccessor>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This is the interface for team accessor, getting the methods for manipulating teams
/// 
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Accessor for Team
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

namespace DataAccessLayerInterfaces
{
    public interface ITeamAccessor
    {

        int DeleteAMemberFromATeamByMemberIdAndTeamID(int memberId, int teamId); //returns number of rows affected

        TeamMember SelectAMembersInATeamWithTeamDetails(int memberID, int teamID);//getting a list of team details
		
        Team SelectTeamByTeamID(int team_id);

        List<Team> SelectAllTeams();


        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Use this to add a member to a team by memberID and TeamID
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        int AddMemberToTeamByTeamIDAndMemberID(int teamID, int memberID);

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Method to toggle someone to the bench or starter
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        int MoveAPlayerToBenchOrStarter(int teamID, bool starterOrBench, int memberID);



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a new team
        /// </summary>
        int AddTeam(Team team); // Add new team


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get sport description
        /// </summary>
        List<string> getSportName(); // Get sports descriptions


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Search a team by name
        /// </summary>
        List<TeamSport> getTeamByTeamName(string name, int sport_id); //Get team by team name


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all teams a user is into
        /// </summary>
        List<TeamMemberAndSport> getTeamByMemberID(int member_id); //Get team by member ID and details about the sport, gender and others.

    }
}
