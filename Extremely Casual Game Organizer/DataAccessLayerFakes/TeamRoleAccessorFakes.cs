/// <summary>
/// Garion Opiola
/// Created: 2023/01/31
/// 
/// Fake Data used in place of real Data Accessor for TeamRoles.
/// </summary>

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
        List<TeamRoles> _teamRoles = new List<TeamRoles>();

        public TeamRoleAccessorFakes()
        {
            _teamRoles.Add(new TeamRoles
            {
                MemberID = 999998,
                TeamID = 9998,
                TeamRoleTypeID = "Pitcher"
            });

            _teamRoles.Add(new TeamRoles
            {
                MemberID = 999999,
                TeamID = 9999,
                TeamRoleTypeID = "Catcher"
            });
        }

        public List<TeamRoles> SelectTeamRolesByMemberID()
        {
            return _teamRoles.ToList();
        }
    }
}
