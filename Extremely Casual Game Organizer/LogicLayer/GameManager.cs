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
    }
}
