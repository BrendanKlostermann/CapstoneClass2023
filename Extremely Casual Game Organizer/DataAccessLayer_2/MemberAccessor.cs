/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class MemberAccessor: IMemberAccessor
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Adding a new user to the member table
        /// </summary>
        public int AddUser(Member member)
        {
            // return object
            int rowsAffected = 0;

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            string commandText = @"sp_insert_user_account";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@first_name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@family_name", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@gender", SqlDbType.Bit);
            cmd.Parameters.Add("@birthday", SqlDbType.DateTime, 100);
            cmd.Parameters.Add("@phone_number", SqlDbType.NVarChar, 15);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@passwordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@active", SqlDbType.Bit);
            //cmd.Parameters.Add("@bio", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@profile_photo", SqlDbType.Image, member.ProfilePhoto.Length);

            // parameter values
            cmd.Parameters["@first_name"].Value = member.FirstName;
            cmd.Parameters["@family_name"].Value = member.FamilyName;
            cmd.Parameters["@gender"].Value = member.Gender;
            cmd.Parameters["@birthday"].Value = member.Birthday;
            cmd.Parameters["@phone_number"].Value = member.PhoneNumber;
            cmd.Parameters["@email"].Value = member.Email;
            cmd.Parameters["@passwordHash"].Value = member.PasswordHash;
            cmd.Parameters["@active"].Value = member.Active;
            //cmd.Parameters["@bio"].Value = member.Bio;
            cmd.Parameters["@profile_photo"].Value = member.ProfilePhoto;


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
                throw new ApplicationException("Cannot create the user");
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
        /// Search for a member by first name, family name and/or email
        /// </summary>
        public List<Member> GetMemberByFirstNameFamilyNameAndEmail(string name)
        {
            List<Member> members = new List<Member>();

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_members_by_name";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100);

            // parameter values
            cmd.Parameters["@name"].Value = name;

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
                        Member member = new Member()
                        {
                            MemberID = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            FamilyName = reader.GetString(3),
                            Birthday = reader.GetDateTime(4),
                            PhoneNumber = reader.GetString(5),
                            Active = reader.GetBoolean(7)
                        };

                        if (reader.IsDBNull(6) == false) member.Gender = reader.GetBoolean(6);
                        else member.Gender = null;

                        if (reader.IsDBNull(8) == false) member.Bio = reader.GetString(8);
                        else member.Bio = null;

                        if (reader.IsDBNull(9) == false) member.ProfilePhoto = (byte[]) reader[9];
                        else member.ProfilePhoto = null;

                        members.Add(member);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return members;
        }
        

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Return all members
        /// </summary>
        public List<Member> GetListOfAllMembers()
        {
            List<Member> members = new List<Member>();

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_members_by_name";

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
                        Member member = new Member()
                        {
                            MemberID = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            FamilyName = reader.GetString(3),
                            Birthday = reader.GetDateTime(4),
                            PhoneNumber = reader.GetString(5),
                            Active = reader.GetBoolean(7)
                        };

                        if (reader.IsDBNull(6) == false) member.Gender = reader.GetBoolean(6);
                        else member.Gender = null;

                        if (reader.IsDBNull(8) == false) member.Bio = reader.GetString(8);
                        else member.Bio = null;

                        if (reader.IsDBNull(9) == false) member.ProfilePhoto = (byte[])reader[9];
                        else member.ProfilePhoto = null;

                        members.Add(member);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return members;
        }
        

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get a member by memberID
        /// </summary>
        public Member GetMemberByMemberID(int MemberID)
        {
            Member member = null;

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = "sp_select_member_by_id";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@member_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@member_id"].Value = MemberID;

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
                        member = new Member()
                        {
                            MemberID = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            FamilyName = reader.GetString(3),
                            Birthday = reader.GetDateTime(4),
                            PhoneNumber = reader.GetString(5),
                            Active = reader.GetBoolean(7)
                        };

                        if (reader.IsDBNull(6) == false) member.Gender = reader.GetBoolean(6);
                        else member.Gender = null;

                        if (reader.IsDBNull(8) == false) member.Bio = reader.GetString(8);
                        else member.Bio = null;

                        if (reader.IsDBNull(9) == false) member.ProfilePhoto = (byte[])reader[9];
                        else member.ProfilePhoto = null;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member;
        }
        

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update member bio
        /// </summary>
        public int UpdateUserBio(Member member)
        {
           // return object
           int rowsAffected = 0;

                // connection
                var conn = DBConnection.GetConnection();

                // command text
                string commandText = @"sp_update_user_bio";

                // command
                var cmd = new SqlCommand(commandText, conn);

                // command type
                cmd.CommandType = CommandType.StoredProcedure;

                // parameters
                cmd.Parameters.Add("@member_id", SqlDbType.Int);
                cmd.Parameters.Add("@bio", SqlDbType.NVarChar, 1000);

                // parameter values
                cmd.Parameters["@member_id"].Value = member.MemberID;
                cmd.Parameters["@bio"].Value = member.Bio;


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
                    throw new ApplicationException("Update Failed");
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
        /// Assign a profile picture to the member table
        /// </summary>
        public int UpdateProfilePicture(Member member)
        {
            // return object
            int rowsAffected = 0;

            // connection
            var conn = DBConnection.GetConnection();

            // command text
            string commandText = @"sp_update_user_profile_picture";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters.Add("@profile_photo", SqlDbType.Image, member.ProfilePhoto.Length);

            // parameter values
            cmd.Parameters["@member_id"].Value = member.MemberID;
            cmd.Parameters["@profile_photo"].Value = member.ProfilePhoto;


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
                throw new ApplicationException("Update Failed");
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
