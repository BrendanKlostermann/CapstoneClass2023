/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the TournamentAccessor class, used to move data to and from the database.
/// 
/// </summary>

/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
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
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// This Method will create a tournament object based off of the id given to it.
        public Tournament SelectTournamentByTournamentID(int id)
        {
            Tournament tournament = new Tournament();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_tournament_by_tournamentid";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@tournamentid", SqlDbType.Int);
            cmd.Parameters["@tournamentid"].Value = id;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

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
                }
                return tournament;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/29
        /// 
        /// </summary>
        /// This method takes in a memberID and tournamentID and runs the stored procedure to deactivate the tournament.
        public int DeactivateTournament(int memberid, int tournamentID)
        {
            int count = 0;


            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_deactivate_tournament";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@memberid", SqlDbType.Int);
            cmd.Parameters["@memberid"].Value = memberid;

            cmd.Parameters.Add("@tournamentid", SqlDbType.Int);
            cmd.Parameters["@tournamentid"].Value = tournamentID;

            try
            {
                conn.Open();

                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
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
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// This Method will take in a tournament object and update the tournament in the database returning
        /// the row count
        public int UpdateTournament(int memberid, Tournament tm)
        {
            int count = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_update_tournament";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@tournamentID", SqlDbType.Int);
            cmd.Parameters["@tournamentID"].Value = tm.TournamentID;

            cmd.Parameters.Add("@sportid", SqlDbType.Int);
            cmd.Parameters["@sportid"].Value = tm.SportID;

            cmd.Parameters.Add("@gender", SqlDbType.Bit);
            if(tm.Gender == null)
            {
                cmd.Parameters["@gender"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@gender"].Value = tm.Gender;
            }

            cmd.Parameters.Add("@memberid", SqlDbType.Int);
            cmd.Parameters["@memberid"].Value = tm.MemberID;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 250);
            cmd.Parameters["@name"].Value = tm.Name;

            cmd.Parameters.Add("@description", SqlDbType.NVarChar, 1000);
            cmd.Parameters["@description"].Value = tm.Description;

            cmd.Parameters.Add("@editorID", SqlDbType.Int);
            cmd.Parameters["@editorID"].Value = memberid;

            try
            {
                conn.Open();

                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
                            //Gender = reader.GetBoolean(2),
                            MemberID = reader.GetInt32(3),
                            Name = reader.GetString(4),
                            Description = reader.GetString(5),
                            Active = reader.GetBoolean(6)
                        };

                        if (reader.IsDBNull(2) == false) tournament.Gender = reader.GetBoolean(2);
                        else tournament.Gender = null;

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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
                        TournamentTeam tournament = new TournamentTeam()
                        {
                            TournamentID = reader.GetInt32(0),
                            TeamID = reader.GetInt32(1)
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
        /// Remove a team from a tournament
        /// </summary>
        public int RemoveTeamToTournament(TournamentTeam tournamentTeam)
        {
            // return object
            int rowsAffected = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select tournament team games
        /// </summary>
        public List<TournamentTeamGame> SelectTournamentTeamAndGame(int tournament_id)
        {
            List<TournamentTeamGame> tournaments = new List<TournamentTeamGame>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            var cmdText = "sp_select_tournament_games";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@tournament_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@tournament_id"].Value = tournament_id;

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
                        TournamentTeamGame tournament = new TournamentTeamGame()
                        {
                            TournamentID = reader.GetInt32(0),
                            GameID = reader.GetInt32(1),
                            TeamID = reader.GetInt32(2)
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
        /// Insert tournament game
        /// </summary>
        public int InsertTournamentGame(TournamentGenerateGames tournamentGenerateGames)
        {
            // return object
            int rowsAffected = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = @"sp_generate_tournament_team";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@tournament_id", SqlDbType.Int);

            cmd.Parameters.Add("@team_id_1", SqlDbType.Int);
            cmd.Parameters.Add("@team_id_2", SqlDbType.Int);
            cmd.Parameters.Add("@member_id", SqlDbType.Int);

            cmd.Parameters.Add("@content", SqlDbType.NVarChar, 1000);

            cmd.Parameters.Add("@group", SqlDbType.Bit);

            // parameter values
            cmd.Parameters["@tournament_id"].Value = tournamentGenerateGames.TournamentID;

            cmd.Parameters["@team_id_1"].Value = tournamentGenerateGames.TeamID_1;
            cmd.Parameters["@team_id_2"].Value = tournamentGenerateGames.TeamID_2;
            cmd.Parameters["@member_id"].Value = tournamentGenerateGames.MemberID;

            cmd.Parameters["@content"].Value = tournamentGenerateGames.Content;

            cmd.Parameters["@group"].Value = tournamentGenerateGames.IsAGroup;

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
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed. "+ex.Message);
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
        /// delete all tournament games
        /// </summary>
        public int deleteTournamentGameGenerated(int tournament_id)
        {
            // return object
            int rowsAffected = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = @"sp_delete_generate_tournament_team";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@tournament_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@tournament_id"].Value = tournament_id;

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
                rowsAffected = 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Delete Failed. "+ ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return rowsAffected;
        }

        //returns a Tournament Object by taking in the parameter tournament_id
        public Tournament SelectTournamentByID(int tournament_id)
        {
            Tournament returnedTournament = new Tournament();
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();
            var cmdText = "sp_select_tournament_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //tournament_id is an identity
            cmd.Parameters.Add("@tournament_id", SqlDbType.Int);
            cmd.Parameters["@tournament_id"].Value = tournament_id;
            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();
                // process the results
                if (reader.HasRows)
                {
                    reader.Read();
                    returnedTournament.TournamentID = reader.GetInt32(0);
                    returnedTournament.SportID = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                    {
                        returnedTournament.Gender = reader.GetBoolean(2);
                    }
                    else
                    {
                        returnedTournament.Gender = null;
                    }
                    returnedTournament.MemberID = reader.GetInt32(3);
                    returnedTournament.Name = reader.GetString(4);
                    returnedTournament.Description = reader.GetString(5);
                    returnedTournament.Active = reader.GetBoolean(6);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close the connection
                conn.Close();
            }

            return returnedTournament;
        }

        // Heritier Otiom
        //return a Tournament Object by taking in the parameter tournament_id
        public int ActivateTournament(int memberid, int tournamentID)
        {
            int count = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_activate_tournament";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@memberid", SqlDbType.Int);
            cmd.Parameters["@memberid"].Value = memberid;

            cmd.Parameters.Add("@tournamentid", SqlDbType.Int);
            cmd.Parameters["@tournamentid"].Value = tournamentID;

            try
            {
                conn.Open();

                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }


    }
}
