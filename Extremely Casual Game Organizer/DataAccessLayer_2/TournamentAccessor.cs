/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TournamentAccessor : ITournamentAccessor
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Insert a team to a tournament
        /// </summary>
        public int AddTeamToTournament(TournamentTeam tournamentTeam)
        {
            // return object
            int rowsAffected = 0;

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            string commandText = @"sp_insert_team_to_tournament";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@tournament_id", SqlDbType.Int);
            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@tournament_id"].Value = tournamentTeam.TournamentID;
            cmd.Parameters["@team_id"].Value = tournamentTeam.TeamID;

            try
            {
                // 8. open the connection
                conn.Open();

            // 9. Execute the command qnd capture the results
            // three basic execution modes:
            // .ExecuteReadet() returns row/column data (normal select statements)
            // .ExecuteNonQuery() returns Int32 rows affected (action statements (update/delete/insert))
            // .ExecuteScalar() returns a System.Object (aggregate queries)
            rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot add the team to the tournament");
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return rowsAffected;
        }
        
        
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all tournaments
        /// </summary>
        public List<Tournament> GetTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_tournament";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tournament tournament = new Tournament()
                        {
                            TournamentID = reader.GetInt32(0),
                            SportID = reader.GetInt32(1),
                            Gender = reader.GetBoolean(2),
                            MemberID = reader.GetInt32(3),
                            Name = reader.GetString(4),
                            Description = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        tournaments.Add(tournament);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tournaments;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all tournament team by tournamentID
        /// </summary>
        public List<TournamentTeam> GetTournamentTeamByID(int tournament_id)
        {
            List<TournamentTeam> tournaments = new List<TournamentTeam>();

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_tournament_team_by_tournament_id";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@tournament_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@tournament_id"].Value = tournament_id;

            //try
            //{
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TournamentTeam tournament = new TournamentTeam()
                        {
                            TournamentID = reader.GetInt32(0),
                            TeamID = reader.GetInt32(1)
                        };

                        tournaments.Add(tournament);
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return tournaments;
        }
        
        
        
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove a team from a tournament
        /// </summary>
        public int RemoveTeamToTournament(TournamentTeam tournamentTeam)
        {
            // return object
            int rowsAffected = 0;

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            string commandText = @"sp_delete_team_from_tournament";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@tournament_id", SqlDbType.Int);
            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@tournament_id"].Value = tournamentTeam.TournamentID;
            cmd.Parameters["@team_id"].Value = tournamentTeam.TeamID;

            try
            {
                // 8. open the connection
                conn.Open();

            // 9. Execute the command qnd capture the results
            // three basic execution modes:
            // .ExecuteReadet() returns row/column data (normal select statements)
            // .ExecuteNonQuery() returns Int32 rows affected (action statements (update/delete/insert))
            // .ExecuteScalar() returns a System.Object (aggregate queries)
            rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Delete Failed");
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return rowsAffected;
        }
    }
}
