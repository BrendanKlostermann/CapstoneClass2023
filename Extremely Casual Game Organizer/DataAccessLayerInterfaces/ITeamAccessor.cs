
﻿/// <ITeamAccessor>
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

﻿using System;
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
    }
}
