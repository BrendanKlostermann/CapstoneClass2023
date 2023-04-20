///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Data Fakes for GameRosterAccessor and GameRosterManger Class Testing
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
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class GameRosterAccessorFake : IGameRosterAccessor
    {
        List<GameRoster> _gameRoster = null;
        public GameRosterAccessorFake()
        {   
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Constructor creates mock GameRoster List
            /// 
            /// </summary>
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
        }


        public List<GameRoster> SelectGameRoster(int game_id)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Query the list and retrieves results based on provided game_id.
            /// Sets results to a list and returns said list.
            /// 
            /// </summary>
            List<GameRoster> gameRoster = null;

            try
            {
                var query = from row in _gameRoster where row.GameID.Equals(game_id) select row;

                gameRoster = query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return gameRoster;
        }


        public int DeleteFromGameRoster(int game_id, int team_id)
        {
            int result = 0;
            int count = 0;
            foreach (var player in _gameRoster)
            {
                if (player.GameID == game_id && player.TeamID == team_id)
                {
                    _gameRoster.Remove(player);
                    count++;
                }
            }

            if (count > 0)
            {
                result = 1;
            }
            return result;
        }

        public int InsertGameRosterMembers(List<GameRoster> members)
        {
            int result = 0;
            int count = 0;
            foreach (var player in members)
            {
                _gameRoster.Add(player);
                count++;
            }

            if (count > 0 )
            {
                result = 1;
            }

            return result;
        }
    }
}
