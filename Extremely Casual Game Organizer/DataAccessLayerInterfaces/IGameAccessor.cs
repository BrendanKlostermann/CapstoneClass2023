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
        DataTable SelectGameListByTeamID(int team_id);
        List<Score> SelectScoreByGameID(int game_id);
        int InsertGame(Game game, int member_id);
        int UpdateGame(Game game, int member_id);
        int DeleteGame(int game_id, int member_id);
        int InsertScore(Score score);
        int UpdateScores(List<Score> scores);
        int ReplaceTeamScore(Score score, int oldTeamID);

    }
}
