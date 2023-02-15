using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class TeamMemberAccessor : ITeamMemberAccessor
    {
        public int InsertTeamMember(int team_id, int member_id, string description)
        {
            throw new NotImplementedException();
        }
    }
}
