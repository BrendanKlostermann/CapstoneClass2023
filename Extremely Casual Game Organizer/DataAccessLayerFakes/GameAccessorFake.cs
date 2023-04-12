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
        List<Sport> _sportList = null;

        public GameAccessorFake()
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Constructor creates mock data tables columns and rows for unit testing.
            /// </summary>
            /// 

            _gameList = new DataTable();
            _gameList.Columns.Add("game_id", typeof(int));
            _gameList.Columns.Add("sport_id", typeof(int));
            _gameList.Columns.Add("venue_id", typeof(int));
            _gameList.Columns.Add("Date and Time", typeof(DateTime));
            _gameList.Columns.Add("member_id", typeof(int));
            _gameList.Columns.Add("active", typeof(bool));

            _gameList.Rows.Add(1000, 1001, 1000, new DateTime(2023, 12, 01), 100000, true);
            _gameList.Rows.Add(1001, 1002, 1001, new DateTime(2023, 12, 01), 100001, true);
            _gameList.Rows.Add(1002, 1000, 1000, new DateTime(2023, 02, 04), 100000, true);
            _gameList.Rows.Add(1003, 1003, 1001, new DateTime(2023, 06, 03), 100001, true);

            _sportList = new List<Sport>()
            {
                new Sport()
                {
                    SportId = 1000,
                    Description = "Basketball"
                },
                new Sport()
                {
                    SportId = 1001,
                    Description = "Baseball"
                },
                new Sport()
                {
                    SportId = 1002,
                    Description = "Football"
                },
                new Sport()
                {
                    SportId = 1003,
                    Description = "Soccer"
                }
            };

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

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Data fake method for removing game from game table.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public int DeleteGame(Game game, int member_id)
        {
            int result = 0;

            try
            {
                // Select game to delete. Result should return only 1 row
                var deleteGame = _gameList.AsEnumerable().Where(x => Convert.ToInt32(x[0]) == game.GameID);

                // Count list before removal
                int preRemoval = _gameList.Rows.Count;

                // Remove
                _gameList.Rows.Remove(deleteGame.First());

                // Count list after
                int postRemoval = _gameList.Rows.Count;

                // return results based on rows affected.
                result = preRemoval - postRemoval;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
         }

        public int InsertGame(Game game, int member_id)
        {
            int result = 0;

            try
            {
                int preCount = _gameList.Rows.Count;
                _gameList.Rows.Add(game.GameID, game.SportID, game.VenueID, game.DateAndTime, member_id, true);

                int postCount = _gameList.Rows.Count;

                result = postCount - preCount;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
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
            gameList.Columns.Add("member_id", typeof(int));
            gameList.Columns.Add("active", typeof(bool));

            try
            {
                // Get roster data for teamID
                // Should return multiple if team is in multiple games.
                var rosterSearch = _gameRoster.AsEnumerable().Where(x => x.TeamID == team_id);

                // Get game for rosterID to determine if team is participating in a game. Multiple results in rosterSearch
                foreach (var game in rosterSearch.GroupBy(x => x.GameID))
                {
                    var gameSearch = from row in _gameList.AsEnumerable() where row[0].Equals(game.Key) where row[5].Equals(true) select row;
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

        public Dictionary<string, string> SelectZipCodeInformation(int zip_code)
        {
            throw new NotImplementedException();
        }

        public int UpdateGame(Game game, int member_id)
        {
            int result = 0;

            try
            {
                var updateRow = _gameList.AsEnumerable().Where(x => x[0].Equals(game.GameID)).First();

                // Update Row
                foreach (var row in _gameList.AsEnumerable())
                {
                    if (row[0].Equals(game.GameID))
                    {
                        row[1] = game.SportID;
                        row[2] = game.VenueID;
                        row[3] = game.DateAndTime;
                        row[4] = updateRow[4];
                        row[5] = updateRow[5];
                    }
                }

                // Check if new row exists
                var rowUpdated = from row
                                 in _gameList.AsEnumerable()
                                 where row[0].Equals(game.GameID)
                                 where row[1].Equals(game.SportID)
                                 where row[2].Equals(game.VenueID)
                                 where row[3].Equals(game.DateAndTime)
                                 select row;

                if (rowUpdated.Count() == 1)
                {
                    result = 1;
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
    }
}
