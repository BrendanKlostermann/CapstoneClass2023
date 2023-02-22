///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// GameRosterAccessor for processing GameRosterManager methods to the database. 
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
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class GameRosterAccessor : IGameRosterAccessor
    {
        public List<GameRoster> SelectGameRoster(int game_id)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Retrieves game roster based on provided game_id
            /// </summary>
            
            List<GameRoster> _rosterList = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_game_roster_by_game_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@game_id", SqlDbType.Int);

            cmd.Parameters["@game_id"].Value = game_id;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                _rosterList = new List<GameRoster>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GameRoster rosterEntry = new GameRoster();

                        rosterEntry.GameRosterID = reader.GetInt32(0);
                        rosterEntry.GameID = reader.GetInt32(1);
                        rosterEntry.MemberID = reader.GetInt32(2);
                        rosterEntry.Description = reader.GetString(3);
                        rosterEntry.TeamID = reader.GetInt32(4);
                        rosterEntry.TeamName = reader.GetString(5);
                        rosterEntry.FirstName = reader.GetString(6);
                        rosterEntry.LastName = reader.GetString(7);

                        _rosterList.Add(rosterEntry);
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return _rosterList;
        }
    }
}
