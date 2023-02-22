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
        int AddTeamMember(int team_id, int member_id, string description);

        List<Member> SortIntoStarters(List<Member> members, int teamID, bool active);

        int RemoveAPlayerFromATeamByTeamIDAndMemberID(int teamID, int memberID);

        List<Member> GetAListOfAllMembersByTeamID(int teamID);

    }
}
