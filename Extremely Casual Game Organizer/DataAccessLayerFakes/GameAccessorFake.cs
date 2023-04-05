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
        List<GameRoster> _gameRoster = null;
        List<Score> _scoreList = null;

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
            _gameList.Columns.Add("Sport", typeof(string));
            _gameList.Columns.Add("Location", typeof(string));
            _gameList.Columns.Add("Date and Time", typeof(DateTime));

            _gameList.Rows.Add(1000, "Backetball", "Kyles House", new DateTime(2023, 12, 01));
            _gameList.Rows.Add(1001, "BaseBall", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 12, 01));
            _gameList.Rows.Add(1002, "Basketball", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 02, 04));
            _gameList.Rows.Add(1003, "Baseball", "1251 Main St SW, Cedar Rapids IA, 52401", new DateTime(2023, 06, 03));

            _gameDetails = new DataTable();
            _gameDetails.Columns.Add("game_id", typeof(int));
            _gameDetails.Columns.Add("location", typeof(string));
            _gameDetails.Columns.Add("date_and_time", typeof(DateTime));
            _gameDetails.Columns.Add("sport", typeof(string));

            _gameDetails.Rows.Add("1000", "Kyles House", new DateTime(2023, 12, 01), "Flippy Cup");
            _gameDetails.Rows.Add("1001", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 12, 01), "Table Tennis");

            // Create GameRoster List
            _gameRoster = new List<GameRoster>()
            {
                new GameRoster
                { GameID = 1000, TeamID = 1001, MemberID = 100000, Description = "Home Team", GameRosterID = 10, TeamName = "TheFirstTeam", FirstName = "Adam", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1001, MemberID = 100001, Description = "Home Team", GameRosterID = 11, TeamName = "TheFirstTeam", FirstName = "Brad", LastName = "Smith" },
                 new GameRoster
                { GameID = 1000, TeamID = 1001, MemberID = 100002, Description = "Home Team", GameRosterID = 12, TeamName = "TheFirstTeam", FirstName = "Charles", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1002, MemberID = 100003, Description = "Away Team", GameRosterID = 13, TeamName = "TheSecondTeam", FirstName = "Dave", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1002, MemberID = 100004, Description = "Away Team", GameRosterID = 14, TeamName = "TheSecondTeam", FirstName = "Edward", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1002, MemberID = 100005, Description = "Away Team", GameRosterID = 15, TeamName = "TheSecondTeam", FirstName = "Frank", LastName = "Smith" },
            };

            _scoreList = new List<Score>()
            {
                new Score {GameID = 1000, TeamID = 1001, TeamScore = 10},
                new Score {GameID = 1000, TeamID = 1002, TeamScore = 20},
                new Score {GameID = 1001, TeamID = 1003, TeamScore = 15},
                new Score {GameID = 1001, TeamID = 1004, TeamScore = 12},
            };
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

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date 2023/25/02
        /// 
        /// Method should return game list if the team is participating in game.
        /// Need to determine what GameRoster objects the TeamID is found and get the Game object based on the return result.
        /// Add that data to the data table and send that back with the result
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public DataTable SelectGameListByTeamID(int team_id)
        {
            DataTable gameList = new DataTable();
            // Setup return table columns
            gameList.Columns.Add("game_id", typeof(int));
            gameList.Columns.Add("Teams", typeof(string));
            gameList.Columns.Add("Location", typeof(string));
            gameList.Columns.Add("Date and Time", typeof(DateTime));

            try
            {
                // Get roster data for teamID
                // Should return multiple if team is in multiple games.
                var rosterSearch = _gameRoster.AsEnumerable().Where(x => x.TeamID == team_id);

                // Get game for rosterID to determine if team is participating in a game. Multiple results in rosterSearch
                foreach (var game in rosterSearch.GroupBy(x => x.GameID))
                {
                    var gameSearch = from row in _gameList.AsEnumerable() where row[0].Equals(game.Key) select row;
                    gameList.Rows.Add(gameSearch.First().ItemArray); // gameSearch should only return 1 result
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return gameList;
        }

        public List<Score> SelectScoreByGameID(int game_id)
        {
            List<Score> returnList = null;
            try
            {
                returnList = _scoreList.Where(x => x.GameID == game_id).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return returnList;
        }
    }
}
