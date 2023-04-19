///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Class file and Methods for processing the GameManager methods with the database.
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class GameAccessor : IGameAccessor
    {
        public int DeleteGame(Game game, int member_id)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Retrieves game list from stored procedure and stores results into a data table
            /// </summary>
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_deactivate_game";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@game_id", game.GameID);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public int InsertGame(Game game, int member_id)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAllGames()
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Retrieves game list from stored procedure and stores results into a data table
            /// </summary>
            DataTable returnTable = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_game_list";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            var dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            try
            {
                returnTable = new DataTable();

                conn.Open();

                dataAdapter.Fill(returnTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return returnTable;
        }

        public DataRow SelectGameDetails(int game_id)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 2023/02/10
            /// 
            /// Retrieves game details from stored procedure and stores results into a data row. SP should return only 1 row.
            /// </summary>
            DataRow returnRow;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_game_details_by_game_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@game_id", SqlDbType.Int);

            cmd.Parameters["@game_id"].Value = game_id;

            var dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            try
            {
                DataTable fillTable = new DataTable();
                conn.Open();

                dataAdapter.Fill(fillTable);

                if (fillTable.Rows.Count > 0)
                {
                    returnRow = fillTable.Rows[0];
                }
                else
                {
                    returnRow = null;
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
        /// Date: 2023/02/28
        /// 
        /// Method takes in team_id and gives List of current and previous games for team.
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public DataTable SelectGameListByTeamID(int team_id)
        {
            DataTable returnTable = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_game_list_by_team_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            cmd.Parameters["@team_id"].Value = team_id;

            var dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            try
            {
                returnTable = new DataTable();

                conn.Open();

                dataAdapter.Fill(returnTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return returnTable;
        }
        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/02/04
        /// 
        /// Method returns score list based on game id provided
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public List<Score> SelectScoreByGameID(int game_id)
        {
            List<Score> result = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_score_by_game_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@game_id", SqlDbType.Int);

            cmd.Parameters["@game_id"].Value = game_id;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                result = new List<Score>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Score addScore = new Score();
                        addScore.TeamID = reader.GetInt32(0);
                        if (reader.IsDBNull(1))
                        {
                            addScore.TeamScore = null;
                        }
                        else
                        {
                            addScore.TeamScore = reader.GetDecimal(1);
                        }
                        addScore.GameID = game_id;

                        result.Add(addScore);
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

            return result;
        }

        public Dictionary<string, string> SelectZipCodeInformation(int zip_code)
        {
            throw new NotImplementedException();
        }

        public int UpdateGame(Game game, int member_id)
        {
            throw new NotImplementedException();
        }
    }
}
