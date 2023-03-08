/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// An accessor class that is used to handle the 
/// League object.
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

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

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// This method is used to select any current leagues in
        /// the DB by their active status.
        /// </summary>
        /// 
        /// <param name="active">This bool is used to select leagues by the active status
        /// provided (true = active // false = inactive)</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>List of Leagues</returns>	
        public List<League> SelectLeagueByActiveStatus(bool active)
        {
            List<League> leagues = new List<League>();

            var conn = new DBConnection().GetDBConnection();
            var cmdText = "sp_select_active_league_by_status";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@active", SqlDbType.Bit);
            cmd.Parameters["@active"].Value = active;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        leagues.Add(new League()
                        {
                            Active = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return leagues;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// This method selects a league by a parameter of leagueID and
        /// selects the assigned League.
        /// </summary>
        /// 
        /// <param name="leagueID">The LeagueID that is passed to find a
        /// Lague with the assigned LeagueID</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>A single league</returns>
        public League SelectLeagueByLeagueID(int leagueID)
        {
            League leagues = new League();

            var conn = new DBConnection().GetDBConnection();
            var cmdText = "sp_select_league_by_league_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@league_id", SqlDbType.Int);
            cmd.Parameters["@league_id"].Value = leagueID;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        leagues = new League()
                        {
                            LeagueID = reader.GetInt32(0),
                            SportID = reader.GetInt32(1),
                            LeagueDues = reader.GetDecimal(2),
                            Active = reader.GetBoolean(3),
                            MemberID = reader.GetInt32(4),
                            Gender = reader.GetBoolean(5),
                            LeagueDescription = reader.GetString(6),
                            Name = reader.GetString(7),
                            MaxNumberOfTeams = reader.GetInt32(8)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return leagues;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues within the database.
        /// </summary>
        /// 
        /// <param name="active">This bool is used to select leagues by the active status
        /// provided (true = active // false = inactive)</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>List of Leagues</returns>
        public List<League> SelectAllLeagues()
        {
            List<League> leagues = new List<League>();

            var conn = new DBConnection().GetDBConnection();
            var cmdText = "sp_select_all_leagues";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                // get a data reader
                var reader = cmd.ExecuteReader();

                //process the results
                leagues.Add(new League()
                {
                    LeagueID = reader.GetInt32(0),
                    SportID = reader.GetInt32(1),
                    LeagueDues = reader.GetDecimal(2),
                    Active = reader.GetBoolean(3),
                    MemberID = reader.GetInt32(4),
                    Gender = reader.GetBoolean(5),
                    LeagueDescription = reader.GetString(6),
                    Name = reader.GetString(7),
                    MaxNumberOfTeams = reader.GetInt32(8)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return leagues;
        }

        ///// <summary>
        ///// Elijah
        ///// Created: 2023/02/28
        ///// 
        ///// Selects a League by a LeagueID and updates the current active
        ///// status.
        ///// </summary>
        ///// 
        ///// <param name="oldLeague">A League that is passed to obtain the old data</param>
        ///// <param name="newLeague">A League that is passed input the new data</param>
        ///// <exception cref="SQLException">Data not found</exception>
        ///// <returns>A single league</returns>
        //public int UpdateLeagueRegistrationByLeagueIDByActive(League oldLeague, League newLeague)
        //{
        //    // doesnt need any parameters just leagueID and changing 1 to 0 or vice versa

        //    int rows = 0;

        //    var conn = new DBConnection().GetDBConnection();
        //    var cmdText = "sp_update_league_registration_by_league_id_by_active";
        //    var cmd = new SqlCommand(cmdText, conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@league_id", oldLeague.LeagueID);
        //    cmd.Parameters.AddWithValue("@sport_id", oldLeague.SportID);
        //    cmd.Parameters.AddWithValue("@legal_dues", oldLeague.LeagueDues);
        //    cmd.Parameters.AddWithValue("@active", oldLeague.Active);
        //    cmd.Parameters.AddWithValue("@member_id", oldLeague.MemberID);
        //    cmd.Parameters.AddWithValue("@gender", oldLeague.Gender);
        //    cmd.Parameters.AddWithValue("@description", oldLeague.LeagueDescription);
        //    cmd.Parameters.AddWithValue("@name", oldLeague.Name);

        //    cmd.Parameters.Add("@NewActive", SqlDbType.Bit);
        //    cmd.Parameters["@NewActive"].Value = newLeague.Active;

        //    try
        //    {
        //        conn.Open();
        //        rows = cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return rows;
        //}

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Updates a leagues with data that is inserted in the pgAddEditLeague page.
        /// </summary>
        /// 
        /// <param name="oldLeague">A League that is passed to obtain the old data</param>
        /// <param name="newLeague">A League that is passed input the new data</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>A single updated League</returns>
        public int UpdateLeague(League oldLeague, League newLeague)
        {
            int rows = 0;
            var conn = new DBConnection().GetDBConnection();
            var cmdText = "sp_update_league";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@league_id", oldLeague.LeagueID);

            cmd.Parameters.Add("@newLeague_dues", SqlDbType.Money);
            cmd.Parameters["@newLeague_dues"].Value = newLeague.LeagueDues;

            cmd.Parameters.Add("@newActive", SqlDbType.Int);
            cmd.Parameters["@newActive"].Value = newLeague.Active;

            if (newLeague.Gender != null)
            {
                cmd.Parameters.AddWithValue("@newGender", newLeague.Gender);
            }
            else
            {
                cmd.Parameters.Add("@newGender", SqlDbType.Bit);
                cmd.Parameters["@newGender"].Value = DBNull.Value;
            }

            cmd.Parameters.Add("@newDescription", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@newDescription"].Value = newLeague.LeagueDescription;

            cmd.Parameters.Add("@newName", SqlDbType.NVarChar, 250);
            cmd.Parameters["@newName"].Value = newLeague.Name;

            cmd.Parameters.Add("@newMax_num_of_teams", SqlDbType.Int);
            cmd.Parameters["@newMax_num_of_teams"].Value = newLeague.MaxNumberOfTeams;

            try
            {
                try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return rows;
            }
            catch (Exception ex)
            {
                newLeague = oldLeague;
                throw new ApplicationException("Could not find data", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //Elijah M. is currently working on this
        ///// <summary>
        ///// Elijah
        ///// Created: 2023/02/28
        ///// 
        ///// Updates a league's active status with the League object that is 
        ///// selected by the datLeague list.
        ///// 
        ///// <param name="active">What the new active status will become</param>
        ///// <exception cref="SQLException">Data not found</exception>
        ///// <returns>A single updated League</returns>
        //public int UpdateLeagueActiveStatus(bool active) // use int LeagueID to call a leagueID

        //// use an int for the row count then return the integer and 
        //// then use the logic layer to determine wether its true of false
        //{
        //    // make stored procedure for this
        //    var conn = new DBConnection().GetDBConnection();
        //    var cmdText = "";
        //    var cmd = new SqlCommand(cmdText, conn);
        //    int count = 0;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.Add("@active", SqlDbType.Bit);
        //    cmd.Parameters["@active"].Value = active;

        //    try
        //    {
        //        conn.Open();
        //        count = cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Could not find data", ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return count;
        //}

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects a list of every League object.
        /// 
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>Every current League in the database</returns>
        public List<League> SelectListOfLeagues()
        {
            List<League> _leagues = new List<League>();//list of leagues i want to return

            League league = null;//initial league
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

                        league = new League();//new league made by reader

                        league.LeagueID = reader.GetInt32(0);
                        league.SportID = reader.GetInt32(1);
                        league.LeagueDues = reader.GetDecimal(2);
                        league.Active = reader.GetBoolean(3);
                        league.MemberID = reader.GetInt32(4);
                        if (!reader.IsDBNull(5))
                        {
                            league.Gender = reader.GetBoolean(5);
                        }
                        league.LeagueDescription = reader.GetString(6);
                        league.Name = reader.GetString(7);
                        league.MaxNumberOfTeams = reader.GetInt32(8);

                        _leagues.Add(league);//added temp league to league list
                    }
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return _leagues;//return list of leagues
        }

        // Elijah M. is currently working on this
        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues with a specified sportID.
        /// 
        /// <param name="sportID">What SportID we are wanting to seach by</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>Leagues that all use the same SportID</returns>
        public League SelectLeaguesBySportID(int sportID)
        {
            League leagues = new League();

            var conn = new DBConnection().GetDBConnection();
            var cmdText = "sp_select_leagues_by_sport_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sport_id", SqlDbType.Int);
            cmd.Parameters["@sport_id"].Value = sportID;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        leagues = new League()
                        {
                            LeagueID = reader.GetInt32(0),
                            SportID = reader.GetInt32(1),
                            LeagueDues = reader.GetDecimal(2),
                            Active = reader.GetBoolean(3),
                            MemberID = reader.GetInt32(4),
                            Gender = reader.GetBoolean(5),
                            LeagueDescription = reader.GetString(6),
                            Name = reader.GetString(7),
                            MaxNumberOfTeams = reader.GetInt32(8)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return leagues;
        }
    }
}