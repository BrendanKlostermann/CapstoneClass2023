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
    }
}
