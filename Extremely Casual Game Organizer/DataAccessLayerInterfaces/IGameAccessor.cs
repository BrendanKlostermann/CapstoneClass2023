using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IGameAccessor
    {
        DataTable SelectAllGames();
        DataRow SelectGameDetails(int game_id);
    }
}
