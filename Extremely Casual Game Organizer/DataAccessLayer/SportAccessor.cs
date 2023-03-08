using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class SportAccessor : ISportAccessor
    {
        public List<Sport> SelectAllSports()
        {
            {
                List<Sport> sports = new List<Sport>();

                var conn = new DBConnection().GetDBConnection();
                var cmdText = "sp_select_sports";
                var cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sports.Add(new Sport()
                            {
                                SportID = reader.GetInt32(0),
                                Description = reader.GetString(1),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return sports;
            }
        }
    }
}
