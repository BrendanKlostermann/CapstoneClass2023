/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Accessor class for Team. Contains methods to interact with database.
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
/// 
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
    public class TeamAccessor : ITeamAccessor
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a new team
        /// </summary>
        public int AddTeam(Team team)
        {
            // return object
            int rowsAffected = 0;

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            string commandText = @"sp_user_create_team";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@team_name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@gender", SqlDbType.Bit);
            cmd.Parameters.Add("@sport_id", SqlDbType.Int);
            cmd.Parameters.Add("@member_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@team_name"].Value = team.Name;
            cmd.Parameters["@gender"].Value = team.Gender;
            cmd.Parameters["@sport_id"].Value = team.SportID;
            cmd.Parameters["@member_id"].Value = team.MemberID;

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
                throw new ApplicationException("Cannot create the team");
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
        /// Get sport description
        /// </summary>
        public List<string> getSportName()
        {
            List<string> sports = new List<string>();

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_sports";

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
                        string sport_details = reader.GetInt32(0) + "," + reader.GetString(1);
                        sports.Add(sport_details);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sports;
        }
        
        
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all teams a user is into
        /// </summary>
        public List<TeamMemberAndSport> getTeamByMemberID(int member_id)
        {
            List<TeamMemberAndSport> teams = new List<TeamMemberAndSport>();

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_team_by_member_id";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@member_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@member_id"].Value = member_id;

            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    //var a = reader.FieldCount;
                    while (reader.Read())
                    {
                        TeamMemberAndSport _aTeam = new TeamMemberAndSport()
                        {
                            TeamID = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            Starter = reader.GetBoolean(2),
                            MemberID = reader.GetInt32(3),
                            TeamName = reader.GetString(4),
                            SportName = reader.GetString(6)
                        };

                        if (reader.IsDBNull(5) == false)
                        {
                            _aTeam.Gender = reader.GetBoolean(5);
                        }
                        else
                        {
                            _aTeam.Gender = null;
                        }
                        teams.Add(_aTeam);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teams;
        }
        
        
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Search a team by name
        /// </summary>
        public List<TeamSport> getTeamByTeamName(string teamName, int sport_id)
        {
            List<TeamSport> teams = new List<TeamSport>();

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_team_by_team_name";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@team_name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@sport_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@team_name"].Value = teamName;
            cmd.Parameters["@sport_id"].Value = sport_id;

            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                        //var a = reader.FieldCount;
                    while (reader.Read())
                    {
                        TeamSport _aTeam = new TeamSport()
                        {
                            TeamID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            SportID = reader.GetInt32(3)
                            //Description = reader.GetString(4)
                        };

                        if (reader.IsDBNull(2) == false)
                        {
                                _aTeam.Gender = reader.GetBoolean(2);
                        }
                        else
                        {
                            _aTeam.Gender = null;
                        }
                        if (reader.IsDBNull(2) == false)
                        {
                                _aTeam.Description = reader.GetString(4);
                        }
                        else
                        {
                            _aTeam.Description = null;
                        }
                            //if (teamName=="") _aTeam.Description = reader.GetString(4);
                            //else _aTeam.Description = reader.GetString(4);
                            teams.Add(_aTeam);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teams;
        }
    }
}
