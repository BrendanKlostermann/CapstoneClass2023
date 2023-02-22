using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    public class TeamRoleAccessorFakes : ITeamRoleAccessor
    {
        List<TeamRoles> teamRoles = new List<TeamRoles>();

        public TeamRoleAccessorFakes()
        {
            teamRoles.Add(new TeamRoles
            {
                memberID = 999998,
                teamID = 9998,
                teamRoleTypeID = "Pitcher"
            });

            teamRoles.Add(new TeamRoles
            {
                memberID = 999999,
                teamID = 9999,
                teamRoleTypeID = "Catcher"
            });
        }

        public List<TeamRoles> SelectTeamRolesByMemberID()
        {
            return teamRoles.ToList();
        }

        public int UpdateTeamRole(int memberID, string teamRoleType)
        {
            throw new NotImplementedException();
        }
    }
}
