using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using DataAccessLayer;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class TeamMemberManager : ITeamMemberManager
    {
        ITeamMemberAccessor _teamMemberAccessor = null;
        public TeamMemberManager()
        {
            _teamMemberAccessor = new TeamMemberAccessor();
        }
        public TeamMemberManager(ITeamMemberAccessor tma)
        {
            _teamMemberAccessor = tma;
        }
        public int AddTeamMember(int team_id, int member_id, string description)
        {
            int result = 0;

            try
            {
                result = _teamMemberAccessor.InsertTeamMember(team_id, member_id, description);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Team Member Addition Failed", ex);
            }

            return result;
        }
    }
}
