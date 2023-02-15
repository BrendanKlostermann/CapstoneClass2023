using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IGameRosterManager
    {
        List<GameRoster> RetrieveGameRoster(int game_id);
    }
}
