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

﻿using System;
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
        public int DeleteAMemberFromATeamByMemberIdAndTeamID(int memberId, int teamId)
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
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = memberId;
            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamId;
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
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to select all members based on what team they are in
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Member> SelectAllmembersByTeamID(int teamId)
        {
            List<Member> allMembersOnATeam = new List<Member>();

            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_selecting_all_players_on_a_team_by_team_id";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values

            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamId;
            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        byte[] profile_picture = null;
                        long? fieldWidth = null;
                        Member tempMember = new Member();
                        tempMember.MemberID = reader.GetInt32(0);
                        tempMember.Email = reader.GetString(1);
                        tempMember.FirstName = reader.GetString(2);
                        tempMember.FamilyName = reader.GetString(3);
                        tempMember.Birthday = reader.GetDateTime(4);
                        tempMember.PhoneNumber = reader.GetString(5);
                        tempMember.Gender = reader.GetBoolean(6);
                        tempMember.Active = reader.GetBoolean(7);
                        tempMember.Bio = reader.GetString(8);


                        int columnIndex = 9;
                        try
                        {
                            fieldWidth = reader.GetBytes(columnIndex, 0, null, 0, Int32.MaxValue);
                        }
                        catch (Exception)
                        {
                            profile_picture = null;
                        }

                        if (profile_picture != null)
                        {
                            int width = (int)fieldWidth;
                            profile_picture = new byte[width];
                            reader.GetBytes(columnIndex, 0, profile_picture, 0, profile_picture.Length);
                        }

                        tempMember.PhotoMimeType = reader.IsDBNull(10) ? null : reader.GetString(10);

                        allMembersOnATeam.Add(tempMember);
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
			return allMembersOnATeam;
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
                        _teamMember.Description = reader.GetString(1);
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
    }
}
