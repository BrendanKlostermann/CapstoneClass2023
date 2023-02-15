using System;
using System.Collections.Generic;
using System.Linq;
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
        public DataTable SelectAllGames()
        {
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
    }
}
