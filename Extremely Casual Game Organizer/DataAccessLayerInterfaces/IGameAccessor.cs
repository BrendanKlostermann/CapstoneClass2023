///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Interface for GameAccessor Class
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
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
