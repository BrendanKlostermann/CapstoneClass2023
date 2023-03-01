using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface ITeamManager
    {
        Team RetrieveTeamByTeamID(int team_id);

        List<Team> RetrieveAllTeams();
    }
}
