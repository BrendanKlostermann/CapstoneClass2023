///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// GameManager Class Methods. Handles logic for GameAccessor Class Methods
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
using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using DataObjects;
using LogicLayerInterfaces;
using System.Data;

namespace LogicLayer
{
    public class GameManager : IGameManager
    {
        IGameAccessor _gameAccessor = null;
        GameAccessorFake _gameAccessorFake = null;
        public GameManager()
        {
            _gameAccessor = new GameAccessor();
        }
        public GameManager(IGameAccessor ga)
        {
            _gameAccessor = ga;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method adds game top game table
        /// </summary>
        /// <returns></returns>
        public int AddGame(Game game, int member_id)
        {
            int result = 0;

            try
            {

                result = _gameAccessor.InsertGame(game, member_id);

                if (result == 0)
                {
                    throw new ApplicationException("Game not added");
                }

            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Adding Game", ex);
            }

            return result;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method edits game in game table
        /// </summary>
        /// <returns></returns>
        public int EditGame(Game game, int member_id)
        {
            int result = 0;

            try
            {
                result = _gameAccessor.UpdateGame(game, member_id);


                if (result == 0)
                {
                    throw new ApplicationException("Game not updated");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Updating Game", ex);
            }

            return result;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method add score to score table
        /// </summary>
        /// <returns></returns>
        public int AddScore(Score score)
        {
            int result = 0;

            try
            {
                result = _gameAccessor.InsertScore(score);

                if (result == 0)
                {
                    throw new ApplicationException("Score not added");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error adding score", ex);
            }

            return result;
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method Removed game from game table
        /// </summary>
        /// <returns></returns>
        public int RemoveGame(int game_id, int member_id)
        {
            int result = 0;

            try
            {
                result = _gameAccessor.DeleteGame(game_id, member_id);


                if (result == 0)
                {
                    throw new ApplicationException("Game not removed");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Removing Game", ex);
            }

            return result;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/04
        /// 
        /// Method retrieves score list by game ID.
        /// Null values are expected so there is no need to check for null values. 
        /// </summary>
        /// <param name="game_id"></param>
        /// <returns></returns>
        public List<Score> RetreiveScoresByGameID(int game_id)
        {
            List<Score> scoreList = null;
            try
            {
                scoreList = _gameAccessor.SelectScoreByGameID(game_id);

                if (scoreList.Count == 0 || scoreList == null)
                {
                    throw new ApplicationException("Scores not found for provided game_id");
                }

            }
            catch (ApplicationException ae)
            {
                throw new ApplicationException("Error retreiving game score", ae);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error retrieving game score", ex);
            }
            return scoreList;
        }

        /// <summary>
        ///  Created By: Jacob Lindauer
        ///  Date: 2023/25/02
        ///  
        /// Method retrieves game list by TeamID from data accessor and returns the list if teamID is not valid.
        /// </summary>
        /// <returns></returns>
        public DataTable RetrieveTeamGameList(int team_id)
        {
            DataTable gameList = null;

            try
            {
                gameList = _gameAccessor.SelectGameListByTeamID(team_id);

            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed loading game list", ex);
            }

            return gameList;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method edits game scores for game
        /// </summary>
        /// <returns></returns>
        public int EditGameScores(List<Score> scores)
        {
            int result = 0;

            try
            {
                result = _gameAccessor.UpdateScores(scores);
                if (result == 0)
                {
                    throw new ApplicationException("Scores not updated");
                }
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Error updating scores", ex);
            }

            return result;
        }

        /// <summary>
        ///  Created By: Jacob Lindauer
        ///  Date: 2023/25/02
        ///  
        /// Method retrieves game list from data accessor and returns the list if data is valid
        /// </summary>
        /// <returns></returns>
        public DataTable ViewAllGames()
        {
            DataTable gameList = null;

            try
            {

                gameList = _gameAccessor.SelectAllGames();

                if (gameList.Columns.Count == 0)
                {
                    throw new ApplicationException("No Data Found");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Loading Game List", ex);
            }

            return gameList;
        }

        /// <summary>
        ///  Created By: Jacob Lindauer
        ///  Date: 2023/25/02
        ///  
        /// Method retrieves game data from data accessor and returns the game details as a data row.
        /// </summary>
        /// <returns></returns>
        public DataRow ViewGameDetails(int gameid)
        {
            DataRow returnRow = null;

            try
            {
                returnRow = _gameAccessor.SelectGameDetails(gameid);

                if (returnRow == null)
                {
                    throw new ArgumentException("Inavlid game_id");
                }
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Search has failed", ae);
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Search has failed", ex);
            }

            return returnRow;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method replaces game scores if team needs to be updated
        /// </summary>
        /// <returns></returns>
        public int ReplaceGameScore(Score score, int oldTeamID)
        {
            int result = 0;

            try
            {
                result = _gameAccessor.ReplaceTeamScore(score, oldTeamID);

                if (result == 0)
                {
                    throw new ApplicationException("Team not repalced for score");
                }
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Error Updating Team for Score", ex);
            }

            return result;
        }
    }
}
