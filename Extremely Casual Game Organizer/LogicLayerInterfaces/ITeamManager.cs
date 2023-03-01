using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data;

namespace LogicLayerInterfaces
{
    public interface ITeamManager
    {
        Team RetrieveTeamByTeamID(int team_id);
    }
}
