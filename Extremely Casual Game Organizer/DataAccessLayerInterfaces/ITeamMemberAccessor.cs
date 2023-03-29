using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface ITeamMemberAccessor
    {
        int InsertTeamMember(int team_id, int member_id);
    }
}
