///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// GameManager Class Methods. Handles logic for GameRosterAccessor Class Methods
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
using LogicLayerInterfaces;
using DataObjects;
using DataAccessLayerFakes;
using DataAccessLayer;
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class GameRosterManager : IGameRosterManager
    {
        private IGameRosterAccessor _gameRosterAccessor = null;
        private GameRosterAccessorFake _fakeGameAccessor = null;

        public GameRosterManager()
        {
            _gameRosterAccessor = new GameRosterAccessor();
        }
        public GameRosterManager(IGameRosterAccessor grm)
        {
            _gameRosterAccessor = grm;
        }

        public List<GameRoster> RetrieveGameRoster(int game_id)
        {
            List<GameRoster> rosterList = null;

            try
            {
                rosterList = _gameRosterAccessor.SelectGameRoster(game_id);

                if(rosterList == null || rosterList.Count == 0)
                {
                    throw new ArgumentException("Roster not found with provided GameID");
                }
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid GameID", ae);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failure Retrieving Game Roster.", ex);
            }

            return rosterList;
        }
    }
}
