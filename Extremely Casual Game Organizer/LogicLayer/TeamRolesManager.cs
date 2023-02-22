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
        private ITeamRoleAccessor teamRoleAccessor = null;

        public TeamRolesManager()
        {
            teamRoleAccessor = new DataAccessLayer.TeamRoleAccessor();
        }

        public TeamRolesManager(ITeamRoleAccessor playerAccessor)
        {
            teamRoleAccessor = playerAccessor;
        }


        public List<TeamRoles> RetrieveTeamRoles()
        {
            List<TeamRoles> teamRoles = null;

            try
            {
                teamRoles = teamRoleAccessor.SelectTeamRolesByMemberID();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return teamRoles;
        }
    }
}
