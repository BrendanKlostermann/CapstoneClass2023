
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
    }
}
