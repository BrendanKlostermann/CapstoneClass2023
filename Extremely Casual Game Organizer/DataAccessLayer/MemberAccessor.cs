/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Accessor class for Member. Contains methods to interact with database.
/// </summary>
///
/// <remarks>
/// Updater Name: Jacob Lindauer
/// Updated: 2023/02/01
/// 
/// Added method for UpdateMemberPassword
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class MemberAccessor : IMemberAccessor
    {
        public Member SelectAUserByID(int memberID)
        {
            Member _member = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_member_by_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@member_id", SqlDbType.Int);

            cmd.Parameters["@member_id"].Value = memberID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    _member = new Member();

                    _member.MemberID = reader.GetInt32(0);
                    _member.Email = reader.GetString(1);
                    _member.FirstName = reader.GetString(2);
                    _member.FamilyName = reader.GetString(3);
                    _member.Birthday = reader.GetDateTime(4);

                    if (!reader.IsDBNull(5))
                    {
                        _member.PhoneNumber = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        _member.Gender = reader.GetBoolean(6);
                    }
                    _member.Active = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                    {
                        _member.Bio = reader.GetString(8);
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

            return _member;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method creates a database connection and runs the procedure
        /// sp_deactivate_member and sets the supplied member to inactive.
        /// </summary>
        public int SetUserToInactive(int member_id)
        {
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();
            var cmdText = "sp_deactivate_member";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = member_id;
            try
            {
                conn.Open();

                int count = cmd.ExecuteNonQuery();
                return count;

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

        public Member SelectMemberByEmail(string email)
        {
            Member member = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_member_by_email";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 254);

            cmd.Parameters["@email"].Value = email;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    member = new Member();

                    member.MemberID = reader.GetInt32(0);
                    member.Email = reader.GetString(1);
                    member.FirstName = reader.GetString(2);
                    member.FamilyName = reader.GetString(3);
                    member.Birthday = reader.GetDateTime(4);

                    if (!reader.IsDBNull(5))
                    {
                        member.PhoneNumber = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        member.Gender = reader.GetBoolean(6);
                    }
                    member.Active = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                    {
                        member.Bio = reader.GetString(8);
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

            return member;
        }



        public List<Member> SelectMemberByMemberFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public List<Member> SelectMemberByMemberFullName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Jacob Lindauer
        /// Created: 2023/02/10
        /// 
        /// Takes input parameters and executes stored procedure to update provided member password.
        /// </summary>
        public bool UpdateMemberPassword(int member_id, string password, string oldPassword)
        {

            bool result;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_reset_password";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@member_id", member_id);
            cmd.Parameters.AddWithValue("@new_password", password);
            cmd.Parameters.AddWithValue("@old_password", oldPassword);

            try
            {
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
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

            return result;
        }
        /// <summary>
        /// Michael Haring
        /// Created: 2023/02/14
        /// 
        /// </summary>
        /// DB Connection to run stored procedure for resetting password to default
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public int UpdatePasswordHashToDefault(int memberID, string passwordHashes)
        {
            int rows = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();
            var cmdText = "sp_reset_password_to_default";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@member_id", memberID);

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

        /// <ListOfMembers>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Method to get a list of members by their member id
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public List<Member> SelectAllMembersByMemberID(List<int> memberID)//list of team coaches
        {
            List<Member> _members = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_member_by_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@member_id", SqlDbType.Int);

            cmd.Parameters["@member_id"].Value = memberID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    Member _member = new Member();

                    _member.MemberID = reader.GetInt32(0);
                    _member.Email = reader.GetString(1);
                    _member.FirstName = reader.GetString(2);
                    _member.FamilyName = reader.GetString(3);
                    _member.Birthday = reader.GetDateTime(4);

                    if (!reader.IsDBNull(5))
                    {
                        _member.PhoneNumber = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        _member.Gender = reader.GetBoolean(6);
                    }
                    _member.Active = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                    {
                        _member.Bio = reader.GetString(8);
                    }
                    _members.Add(_member);
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

            return _members;
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
        public List<Member> SelectAllMembersByTeamID(int teamId)
        {
            List<Member> _members = new List<Member>();
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
                        try
                        {

                            if (reader.GetString(8) == null)
                            {
                                tempMember.Bio = "";
                            }
                            else
                            {
                                tempMember.Bio = reader.GetString(8);
                            }
                        }
                        catch (Exception)
                        {
                            tempMember.Bio = null;
                        }


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
                        _members.Add(tempMember);
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
            return _members;
        }


        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// Authenicating the member by email/password
        /// </summary>

        public int AuthenticateMember(string email, string passwordHash)
        {
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_authenticate_user";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 254);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {

                conn.Open();

                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;

        }

        public List<string> SelectRolesByMemberID(int memberID)
        {
            throw new NotImplementedException();
        }
    }
}
