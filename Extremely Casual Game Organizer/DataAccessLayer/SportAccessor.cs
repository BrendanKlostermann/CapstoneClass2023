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
    }
}
