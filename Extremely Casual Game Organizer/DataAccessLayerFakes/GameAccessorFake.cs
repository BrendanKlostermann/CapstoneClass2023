///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Data Fakes for GameAccessor and GameManger Class Testing
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
using DataAccessLayerInterfaces;
using System.Data;

namespace DataAccessLayerFakes
{
    public class GameAccessorFake : IGameAccessor
    {
        DataTable _gameList = null;
        DataTable _gameDetails = null;
        public GameAccessorFake()
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Constructor creates mock data tables columns and rows for unit testing.
            /// </summary>
            _gameList = new DataTable();
            _gameList.Columns.Add("game_id", typeof(int));
            _gameList.Columns.Add("Teams", typeof(string));
            _gameList.Columns.Add("Location", typeof(string));
            _gameList.Columns.Add("Date and Time", typeof(DateTime));

            _gameList.Rows.Add("1000", "TheMediocreTeam VS TheWorstTeam", "Kyles House", new DateTime(2023, 12, 01));
            _gameList.Rows.Add("1001", "TheBestTeam VS TheOkayTeam ", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 12, 01));
            _gameList.Rows.Add("1002", "TheBestTeam VS TheMediocreTeam ", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 02, 04));
            _gameList.Rows.Add("1003", "TheBestTeam VS TheOkayTeam ", "1251 Main St SW, Cedar Rapids IA, 52401", new DateTime(2023, 06, 03));

            _gameDetails = new DataTable();
            _gameDetails.Columns.Add("game_id", typeof(int));
            _gameDetails.Columns.Add("location", typeof(string));
            _gameDetails.Columns.Add("date_and_time", typeof(DateTime));
            _gameDetails.Columns.Add("sport", typeof(string));

            _gameDetails.Rows.Add("1000", "Kyles House", new DateTime(2023, 12, 01), "Flippy Cup");
            _gameDetails.Rows.Add("1001", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 12, 01), "Table Tennis");
        }

        public DataTable SelectAllGames()
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Returns game list
            /// </summary>
            return _gameList;
        }

        public DataRow SelectGameDetails(int game_id)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Query's the data table for provided game_id and returns the row data for selected value.
            /// </summary>
            DataRow returnRow = null;

            try
            {
                var query = from game in _gameDetails.AsEnumerable() where game["game_id"].Equals(game_id) select game;

                if (query.Count() > 0)
                {
                    returnRow = query.First();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return returnRow;
        }
    }
}
