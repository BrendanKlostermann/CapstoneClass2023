/// <TeamMemberObject>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to create the TeamMember Object
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TeamMember
    {
        public int TeamID { get; set; }
        public string Description { get; set; }
        public Boolean Starter { get; set; }
        public int MemberID { get; set; }

        public TeamMember(int teamID, string description, int memberID)
        {
            this.TeamID = teamID;
            this.Description = description;
            this.MemberID = memberID;
        }

        public TeamMember()
        {

        }
    }
}
