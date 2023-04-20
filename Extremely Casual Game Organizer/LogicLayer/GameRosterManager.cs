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

        public bool AddGameRosterMembers(List<GameRoster> members)
        {
            bool result = false;
            try
            {
                int count = _gameRosterAccessor.InsertGameRosterMembers(members);

                if (count == 0)
                {
                    throw new ApplicationException("Not all members added to game");
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error adding members", ex);
            }

            return result;
        }

        public int RemoveFromGameRoster(int team_id, int game_id)
        {
            int result = 0;

            try
            {
                result = _gameRosterAccessor.DeleteFromGameRoster(game_id, team_id);

                if (result == 0)
                {
                    throw new ApplicationException("Roster Members Not Removed");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error removing game roster members", ex);
            }

            return result;
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
