/// <TeamAccessor>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to access the database in relation to teams and team members
/// 
/// Updater Jacob
/// Updated: 2023/02/21
/// </remarks>

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class TeamAccessor : ITeamAccessor
    {
        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to delete a member form a team based on memberID and TeamID
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int DeleteAMemberFromATeamByMemberIdAndTeamID(int teamID, int memberID)
        {
            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_remove_a_player_from_team_by_member_id";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values
            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamID;
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = memberID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteNonQuery();
                return reader;
            }catch(Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to delete a member form a team based on memberID and TeamID
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed
        public Team SelectTeamByTeamID(int team_id)
        {
            Team team = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_team_by_team_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            cmd.Parameters["@team_id"].Value = team_id;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                team = new Team();

                if (reader.HasRows)
                {
                    reader.Read();

                    team.TeamID = reader.GetInt32(0);
                    team.TeamName = reader.GetString(1);
                    if (reader.IsDBNull(2))
                    {
                        team.Gender = null;
                    }
                    else
                    {
                        team.Gender = reader.GetBoolean(2);
                    }
                    team.SportID = reader.GetInt32(3);
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
            return team;
        }


        /// <summary>
        /// Nick Vroom
        /// Created: 2023/04/18
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Takes in the team and returns the ID of which member owns it
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed
        public int SelectOwnerIDByTeamID(int team_id)
        {
            int ownerID = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_owner_by_team_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            cmd.Parameters["@team_id"].Value = team_id;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    ownerID = reader.GetInt32(0);
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
            return ownerID;
        }



        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method that selects a member in a team and their details (starter or bench)
        /// returns an object (teamMember)
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public TeamMember SelectAMembersInATeamWithTeamDetails(int memberID, int teamID)
        {
            TeamMember _teamMember = null;
            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_team_members_by_member_id_and_team_id";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = memberID;

            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _teamMember = new TeamMember();
                        _teamMember.TeamID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                        {
                            _teamMember.Description = reader.GetString(1);
                        }
                        else
                        {
                            _teamMember.Description = null;
                        }

                        _teamMember.Starter = reader.GetBoolean(2);
                        _teamMember.MemberID = reader.GetInt32(3);
                        return _teamMember;
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
            return _teamMember;
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to select all teams
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Team> SelectAllTeams()
        {

            List<Team> teams = new List<Team>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_teams";

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
                        
                        Team team = new Team();
                        team.TeamID = reader.GetInt32(0);
                        team.TeamName = reader.GetString(1);
                        if (reader.IsDBNull(2))
                        {
                            team.Gender = null;
                        }
                        else
                        {
                            team.Gender = reader.GetBoolean(2);
                        }
                        team.SportID = reader.GetInt32(3);
                        team.MemberID = reader.GetInt32(4);
                        //if (reader.IsDBNull(5))
                        //{
                        //    team.Description = null;
                        //}
                        //else
                        //{
                        //    team.Description = reader.GetString(5);
                        //} // Script does not return Desc (JDL)
                        teams.Add(team);
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
            return teams;
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Method that will add a player to a team by memberID and TeamID
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int AddMemberToTeamByTeamIDAndMemberID(int teamID, int memberID)
        {
            int rowcount = 0;
            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = "sp_add_member_to_team_by_member_id_and_team_id";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamID;

            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = memberID;

            try
            {
                conn.Open();
                rowcount = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("error with database");
            }
            finally
            {
                conn.Close();
            }
            return rowcount;
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Method to move someone from starter to bench or other way around
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int MoveAPlayerToBenchOrStarter(int teamID, bool starterOrBench, int memberID)
        {
            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_update_teamMember_to_bench_or_starter";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values
            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamID;
            cmd.Parameters.Add("@starter", SqlDbType.Bit);
            cmd.Parameters["@starter"].Value = starterOrBench;
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = memberID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteNonQuery();
                return reader;
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }
        }

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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
            cmd.Parameters["@team_name"].Value = team.TeamName;
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
            catch (Exception ex)
            {
                throw new ApplicationException("Cannot create the team "+ ex.Message);
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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
        /// /// Updated By: Garion Opiola
        /// Date: 2023/03/28
        /// Added Active bit
        /// 
        /// Get all teams a user is into
        /// </summary>
        public List<TeamMemberAndSport> getTeamByMemberID(int member_id)
        {
            List<TeamMemberAndSport> teams = new List<TeamMemberAndSport>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
                            SportName = reader.GetString(6),
                            Active = reader.GetBoolean(7)
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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/28/03
        /// 
        /// Method returns team roster for provided ID.
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public List<TeamMember> SelectTeamMembersByTeamID(int team_id)
        {
            List<TeamMember> teamMembers = new List<TeamMember>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            var cmdText = "sp_select_team_members_by_team_id";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@team_id"].Value = team_id;

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
                        TeamMember addMember = new TeamMember();
                        addMember.Description = reader.GetString(0);
                        addMember.Starter = reader.GetBoolean(1);
                        addMember.MemberID = reader.GetInt32(2);
                        addMember.TeamID = team_id;

                        teamMembers.Add(addMember);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamMembers;
        }

        /// <summary>
        /// Garion Opiola
        /// Created: 2023/03/21
        /// 
        /// A method that Deactivates a team the user made
        /// </summary>
        public int DeactivateOwnTeam(int teamID, int memberID)
        {
            int rows = 0;
            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_deactivate_own_team";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values
            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamID;
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = memberID;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
    }
}
