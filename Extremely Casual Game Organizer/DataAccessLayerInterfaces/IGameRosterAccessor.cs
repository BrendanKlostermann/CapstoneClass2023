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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IGameRosterAccessor
    {
        List<GameRoster> SelectGameRoster(int game_id);
        int InsertGameRosterMembers(List<GameRoster> members);
        int DeleteFromGameRoster(int game_id, int team_id);
    }
}
