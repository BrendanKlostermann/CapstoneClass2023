/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the TournamentAccessor class, used to move data to and from the database.
/// 
/// </summary>

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

    
    public class TournamentAccessor : ITournamentAccessor
    {
        List<Tournament> _tournaments;
        List<TournamentVM> _tournamentVMs;


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This Method will take in a tournament object and insert its values into the database as a row
        public int InsertTournament(Tournament tm)
        {
            int count = 0;


            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_insert_tournament";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@sportid", SqlDbType.Int);
            cmd.Parameters["@sportid"].Value = tm.SportID;

            cmd.Parameters.Add("@gender", SqlDbType.Bit);
            cmd.Parameters["@gender"].Value = tm.Gender;

            cmd.Parameters.Add("@memberid", SqlDbType.Int);
            cmd.Parameters["@memberid"].Value = tm.MemberID;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 250);
            cmd.Parameters["@name"].Value = tm.Name;

            cmd.Parameters.Add("@description", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@description"].Value = tm.Description;

            try
            {
                conn.Open();

                count = cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return count;

        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This Method interacts with the database to return rows from the tournament table
        /// to be converted into Tournament DataObjects
        public List<Tournament> SelectAllTournaments()
        {
            _tournaments = new List<Tournament>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_tournaments";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Tournament tournament = new Tournament();
                        tournament.TournamentID = reader.GetInt32(0);
                        tournament.SportID = reader.GetInt32(1);
                        if (!reader.IsDBNull(2))
                        {
                            tournament.Gender = reader.GetBoolean(2);
                        }
                        tournament.MemberID = reader.GetInt32(3);
                        tournament.Name = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                        {
                            tournament.Description = reader.GetString(5);
                        }
                        tournament.Active = reader.GetBoolean(6);

                        _tournaments.Add(tournament);
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

            return _tournaments;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This Method interacts with the database to return rows from the tournament table
        /// to be converted into TournamentVM DataObjects usefull for the presentation layer.
        public List<TournamentVM> SelectAllTournamentVMs()
        {
            MemberAccessor memberAccessor = new MemberAccessor();
            LeagueAccessor leagueAccessor = new LeagueAccessor();

            _tournamentVMs = new List<TournamentVM>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_tournaments";

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
                        TournamentVM tournament = new TournamentVM();
                        tournament.TournamentID = reader.GetInt32(0);
                        tournament.SportName = leagueAccessor.SelectSportDescriptionByID(reader.GetInt32(1));
                        if (!reader.IsDBNull(2))
                        {
                            tournament.GenderBool = reader.GetBoolean(2);
                        }
                        tournament.Gender = "NB";
                        tournament.CreatorName = memberAccessor.SelectAUserByID(reader.GetInt32(3)).FirstName;
                        tournament.Name = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                        {
                            tournament.Description = reader.GetString(5);
                        }

                        _tournamentVMs.Add(tournament);
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

            return _tournamentVMs;
        }
    }
}
