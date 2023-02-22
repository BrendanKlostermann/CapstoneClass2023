/// <ITeamMemberManager>
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
        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// --GetAListOfAllmembersByTeamID returns a list of members based on team ID
        /// --RemoveAPlayerFromATeamByTeamIDAndMemberID removes someone based on their teamID and memberID
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        List<Member> GetAListOfAllMembersByTeamID(int teamID);

        int RemoveAPlayerFromATeamByTeamIDAndMemberID(int teamID, int memberID);

    }
}
