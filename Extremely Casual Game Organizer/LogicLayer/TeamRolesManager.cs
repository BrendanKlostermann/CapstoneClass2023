/// <summary>
/// Garion Opiola
/// Created: 2023/01/31
/// 
/// Loagic for getTeamRoles
/// 
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;

namespace LogicLayer
{
    public class TeamRolesManager : ITeamRolesManager
    { 
        private ITeamRoleAccessor _teamRoleAccessor = null;

        public TeamRolesManager()
        {
            _teamRoleAccessor = new DataAccessLayer.TeamRoleAccessor();
        }

        public TeamRolesManager(ITeamRoleAccessor playerAccessor)
        {
            _teamRoleAccessor = playerAccessor;
        }

        public List<TeamRoles> RetrieveTeamRoles()
        {
            /// <summary>
            /// Garion Opiola
            /// Created: 2023/01/31
            /// 
            /// Logic for RetriveTeamRoles
            /// 
            /// </summary>
            List<TeamRoles> teamRoles = null;

            try
            {
                teamRoles = _teamRoleAccessor.SelectTeamRolesByMemberID();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return teamRoles;
        }


    }
}
