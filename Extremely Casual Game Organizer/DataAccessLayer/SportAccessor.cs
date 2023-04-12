using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class SportAccessor : ISportAccessor
    {
        public List<Sport> SelectAllSports()
        {
            List<Sport> sportList = new List<Sport>();
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_sports";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                //process the results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sport sport = new Sport();
                        sport.SportId = reader.GetInt32(0);
                        sport.Description = reader.GetString(1);

                        sportList.Add(sport);
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
            return sportList;
        }

        /// <summary>
        /// Rith
        /// Data access method for selecting a specific sport by sport id
        /// </summary>
        public string SelectSportBySportID(int SportID)
        {
            string sportDescription = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_sports_description_by_sportID";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@sportID", SqlDbType.Int);
            cmd.Parameters["@sportID"].Value = SportID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sportDescription = reader.GetString(0);
                    }
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }
            return sportDescription;
        }
    }
}
