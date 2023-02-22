///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Interface for GameRosterManager Class
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

namespace LogicLayerInterfaces
{
    public interface IGameRosterManager
    {
        List<GameRoster> RetrieveGameRoster(int game_id);
    }
}
