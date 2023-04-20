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
        public int DeleteFromGameRoster(int game_id, int team_id)
        {
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_delete_game_roster_rows";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@team_id", team_id);
            cmd.Parameters.AddWithValue("@game_id", game_id);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Jacob Lindauer
        /// Created: 2023/13/04
        /// 
        /// Inserts a list of members into the game roster table
        /// 
        /// Updated By: Jacob Lindauer
        /// </summary>
        public int InsertGameRosterMembers(List<GameRoster> members)
        {
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_insert_game_roster_member";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters.Add("@description", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@game_id", SqlDbType.Int);

            foreach (var member in members)
            {
                cmd.Parameters["@member_id"].Value = member.MemberID;
                cmd.Parameters["@team_id"].Value = member.TeamID;
                if (member.Description == "")
                {
                    cmd.Parameters["@description"].Value = "";
                }
                else
                {
                    cmd.Parameters["@description"].Value = member.Description;
                }
                cmd.Parameters["@game_id"].Value = member.GameID;
                try
                {
                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        result += rows;
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                {
                    conn.Close();
                }
            }

            if (result == members.Count)
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Jacob Lindauer
        /// Created: 2023/02/10
        /// 
        /// Retrieves game roster based on provided game_id
        /// 
        /// Updated By: Jacob Lindauer
        /// </summary>
        public List<GameRoster> SelectGameRoster(int game_id)
        {
            
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
                        if (reader.IsDBNull(3))
                        {
                            rosterEntry.Description = "";

                        }
                        else
                        {
                            rosterEntry.Description = reader.GetString(3);
                        }
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
