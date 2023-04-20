///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Interface for GameManager Class
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

namespace LogicLayerInterfaces
{
    public interface IGameManager
    {
        DataTable ViewAllGames();

        DataRow ViewGameDetails(int gameid);
        DataTable RetrieveTeamGameList(int team_id);
        List<Score> RetreiveScoresByGameID(int game_id);
        int AddGame(Game game, int member_id);
        int EditGame(Game game, int member_id);
        int RemoveGame(int game_id, int member_id);
        int AddScore(Score score);
        int EditGameScores(List<Score> scores);
        int ReplaceGameScore(Score score, int oldTeamID);

    }
}
