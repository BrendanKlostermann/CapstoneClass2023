using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface ITeamMemberManager
    {
        int AddTeamMember(int team_id, int member_id, string description);
    }
}
