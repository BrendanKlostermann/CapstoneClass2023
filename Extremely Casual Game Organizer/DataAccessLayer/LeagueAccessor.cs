/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class contains the data access methods for the League object.
/// 
/// </summary>

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
    public class LeagueAccessor : ILeagueAccessor
    {
        List<League> _leagues;

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method creates a database connection and selects a list of all leagues in the database.
        /// </summary>
        ///
        /// <exception cref="Exception">Select fails or database could not be found</exception>
        /// <returns>List of League objects</returns>
        public List<League> SelectListOfLeagues()
        {
            _leagues = new List<League>();

            League league = null;
            DBConnection connectionFacorty = new DBConnection();
            var conn = connectionFacorty.GetDBConnection();

            var cmdText = "sp_select_all_leagues";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                // get a data reader
                var reader = cmd.ExecuteReader();

                //process the results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        league = new League();

                        league.LeagueID = reader.GetInt32(0);
                        league.SportID = reader.GetInt32(1);
                        league.LeagueDues = reader.GetDecimal(2);
                        league.Active = reader.GetBoolean(3);
                        league.MemberID = reader.GetInt32(4);
                        if (!reader.IsDBNull(5))
                        {
                            league.Gender = reader.GetBoolean(5);
                        }
                        league.Description = reader.GetString(6);
                        league.Name = reader.GetString(7);
                        league.MaxNumOfTeams = reader.GetInt32(8);

                        _leagues.Add(league);
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
            return _leagues;
        }
    }
}
