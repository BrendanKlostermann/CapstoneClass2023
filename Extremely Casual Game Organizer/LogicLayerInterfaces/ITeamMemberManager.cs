﻿/// <ITeamMemberManager>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to create the Interface for the team Member manager
/// it has 2 methods, get all members by team id
/// and get all teammembers from teamid and memberid
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{

    public interface ITeamMemberManager
    {

        List<Member> SortIntoStarters(List<Member> members, int teamID, bool active);

        int RemoveAPlayerFromATeamByTeamIDAndMemberID(int teamID, int memberID);


        int AddAPlayerToATeamByTeamIDAndMemberID(int teamID, int memberID);

        String MoveAPlayerToBenchOrStarter(int teamID, bool starter, int memberID);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/28/03
        /// 
        /// Method to retrieve roster by teamID
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        List<TeamMember> RetrieveTeamRosterByTeamID(int team_id);

    }
}
