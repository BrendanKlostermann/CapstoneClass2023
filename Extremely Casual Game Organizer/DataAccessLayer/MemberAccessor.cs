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
            Member member = null;

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

                    if (reader.IsDBNull(9) == false) member.ProfilePhoto = (byte[])reader[9];
                    else member.ProfilePhoto = null;
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

                    if (reader.IsDBNull(9) == false) member.ProfilePhoto = (byte[])reader[9];
                    else member.ProfilePhoto = null;
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

                    if (reader.IsDBNull(9) == false) _member.ProfilePhoto = (byte[])reader[9];
                    else _member.ProfilePhoto = null;
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
                        if (reader.IsDBNull(5))
                        {
                            tempMember.PhoneNumber = "";
                        }
                        else
                        {
                            tempMember.PhoneNumber = reader.GetString(5);
                        }
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
        /// 
        /// Updated By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Parameters did not have correct names. Had to update these to reflect stored proc so method would return value with valid sign in.
        /// Method was also using ExecuteNonQuery when it should have been using ExecuteScalar
        /// </summary>
        public int AuthenticateMember(string email, string passwordHash)
        {
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_authenticate_user";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 254);
            cmd.Parameters.Add("@passwordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@passwordHash"].Value = passwordHash;

            try
            {

                conn.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());

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
        /// Created By: Jacob Lindauer
        /// Date: 2023/04/03
        /// 
        /// Method to get Games that the member is participating in to view in their calendar.
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public DataTable SelectGamesByMemberID(int member_id)
        {
            DataTable gameTable = new DataTable();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_member_games";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values

            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = member_id;

            // Need Data Adapter for DataTables
            var dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            try
            {
                conn.Open();

                dataAdapter.Fill(gameTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return gameTable;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/04/03
        /// 
        /// Method to get Tournament Games that the member is participating in to view in their calendar.
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public DataTable SelectTournamentGamesByMemberID(int member_id)
        {

            DataTable tgameTable = new DataTable();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_member_tournament_games";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values

            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = member_id;

            // Need Data Adapter for DataTables
            var dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            try
            {
                conn.Open();

                dataAdapter.Fill(tgameTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return tgameTable;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/04/03
        /// 
        /// Method to get Tournament Games that the member is participating in to view in their calendar.
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public DataTable SelectPracticesByMemberID(int member_id)
        {
            DataTable practiceTable = new DataTable();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_member_practices";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values

            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = member_id;

            // Need Data Adapter for DataTables
            var dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            try
            {
                conn.Open();

                dataAdapter.Fill(practiceTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return practiceTable;
        }

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Adding a new user to the member table
        /// </summary>
        public int AddUser(Member member)
        {
            // return object
            int addedMemberID = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = "sp_insert_user_account";

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
            if (member.Gender == null)
            {
                cmd.Parameters["@gender"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@gender"].Value = member.Gender;
            }
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
                addedMemberID = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Cannot create the user. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return addedMemberID;
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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
                            //PhoneNumber = reader.GetString(5),
                            Active = reader.GetBoolean(7)
                        };


                        if (reader.IsDBNull(5) == false) member.PhoneNumber = reader.GetString(5);
                        else member.PhoneNumber = null;

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
        /// Return all members
        /// </summary>
        public List<Member> GetListOfAllMembers()
        {
            List<Member> members = new List<Member>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
                            //PhoneNumber = reader.GetString(5),
                            Active = reader.GetBoolean(7)
                        };


                        if (reader.IsDBNull(5) == false) member.PhoneNumber = reader.GetString(5);
                        else member.PhoneNumber = null;

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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
                            Active = reader.GetBoolean(7)
                        };

                        if (reader.IsDBNull(5) == false) member.PhoneNumber = reader.GetString(5);
                        else member.PhoneNumber = "";

                        if (reader.IsDBNull(6) == false || reader.GetInt32(6) == 0) member.Gender = reader.GetBoolean(6);
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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

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
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed. "+ ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return rowsAffected;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Method takes in a member ID and obtains the members availabilty events from the database. 
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public DataTable SelectAvailabilityByMemberID(int member_id)
        {
            DataTable availabilityTable = new DataTable();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_member_availability";

            //create command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values

            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters["@member_id"].Value = member_id;

            // Need Data Adapter for DataTables
            var dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            try
            {
                conn.Open();

                dataAdapter.Fill(availabilityTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return availabilityTable;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/25
        /// 
        /// Method will insert values into the database for provided event.
        /// Will differ depeninding on the provided event type.
        /// </summary>
        /// <param name="insertEvent"></param>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public bool InsertCalendarEvent(CalendarEvent insertEvent, int member_id)
        {
            int rowsAffected;
            bool result = false;
            string[] dates = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            string commandText = "";

            if (insertEvent.Type == "Availability")
            {
                commandText = "sp_insert_member_availability";

                // Split date to get start and end dates
                dates = insertEvent.Date.Split(',');
            }

            var cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            if (insertEvent.Type == "Availability")
            {
                cmd.Parameters.Add("@member_id", SqlDbType.Int);
                cmd.Parameters.Add("@start_availability", SqlDbType.DateTime);
                cmd.Parameters.Add("@end_availability", SqlDbType.DateTime);
                cmd.Parameters.Add("@description", SqlDbType.NVarChar, 250);

                cmd.Parameters["@member_id"].Value = member_id;
                cmd.Parameters["@start_availability"].Value = Convert.ToDateTime(dates[0]);
                cmd.Parameters["@end_availability"].Value = Convert.ToDateTime(dates[1]);
                cmd.Parameters["@description"].Value = insertEvent.Description;
            }


            try
            {

                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return result = true;
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

            // return the result
            return result;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Method takes in a member ID and event object. Will update database with provided information 
        /// Setup this method to allow updates of any Calendar Event Type if needed for later
        /// </summary>
        public bool UpdateCalendarEvent(CalendarEvent updateEvent, int member_id)
        {
            int rowsAffected;
            bool result = false;
            string[] dates = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            string commandText = "";

            if (updateEvent.Type == "Availability")
            {
                commandText = "sp_update_member_availability";

                // Split date to get start and end dates
                dates = updateEvent.Date.Split(',');
            }

            var cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            if (updateEvent.Type == "Availability")
            {
                cmd.Parameters.Add("@member_id", SqlDbType.Int);
                cmd.Parameters.Add("@availability_id", SqlDbType.Int);
                cmd.Parameters.Add("@start_availability", SqlDbType.DateTime);
                cmd.Parameters.Add("@end_availability", SqlDbType.DateTime);
                cmd.Parameters.Add("@description", SqlDbType.NVarChar, 250);

                cmd.Parameters["@member_id"].Value = member_id;
                cmd.Parameters["@availability_id"].Value = updateEvent.EventID;
                cmd.Parameters["@start_availability"].Value = Convert.ToDateTime(dates[0]);
                cmd.Parameters["@end_availability"].Value = Convert.ToDateTime(dates[1]);
                cmd.Parameters["@description"].Value = updateEvent.Description;
            }


            try
            {

                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return result = true;
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

            // return the result
            return result;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Method takes in a member ID and event object. Will delete row from database with provided information.
        /// Setup this method to allow removals of any Calendar Event Type if needed for later
        /// </summary>
        public bool DeleteCalendarEvent(CalendarEvent deleteEvent, int member_id)
        {
            int rowsAffected;
            bool result = false;
            string[] dates = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            string commandText = "";

            if (deleteEvent.Type == "Availability")
            {
                commandText = "sp_delete_member_availability";
            }

            var cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            if (deleteEvent.Type == "Availability")
            {
                cmd.Parameters.Add("@member_id", SqlDbType.Int);
                cmd.Parameters.Add("@availability_id", SqlDbType.Int);

                cmd.Parameters["@member_id"].Value = member_id;
                cmd.Parameters["@availability_id"].Value = deleteEvent.EventID;
            }


            try
            {

                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return result = true;
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

            // return the result
            return result;
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/26
        /// searching for members by first, last or email
        /// </summary>
        public List<Member> SelectAListOfMembersByNameAndOrEmail(string firstName, string familyName, string email)
        {
            List<Member> _members = new List<Member>(); //get list of members
            //connection
            DBConnection connectionFactory = new DBConnection(); //for sp_select_members_by_name_and_or_email
            var conn = connectionFactory.GetDBConnection(); //for sp_select_members_by_name_and_or_email

            //command text
            var cmdText = "sp_select_members_by_name_and_or_email";

            //create command
            var cmd = new SqlCommand(cmdText, conn); //for sp_select_members_by_name_and_or_email

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Add paramaters //values

            cmd.Parameters.Add("@first_name", SqlDbType.NVarChar, 25);
            cmd.Parameters["@first_name"].Value = firstName;

            cmd.Parameters.Add("@family_name", SqlDbType.NVarChar, 25);
            cmd.Parameters["@family_name"].Value = familyName;

            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 254);
            cmd.Parameters["@email"].Value = email;
            try
            {
                conn.Open(); //for sp_select_members_by_name_and_or_email

                var reader = cmd.ExecuteReader(); //for sp_select_members_by_name_and_or_email
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
                        tempMember.PhoneNumber = reader.IsDBNull(5) ? null : reader.GetString(5);
                        tempMember.Gender = reader.IsDBNull(6) ? null : (bool?)reader.GetBoolean(6);
                        tempMember.Active = reader.GetBoolean(7);
                        try
                        {
                            tempMember.Bio = reader.IsDBNull(8) ? null : reader.GetString(8);
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

                        if (fieldWidth != null && fieldWidth > 0)
                        {
                            int width = (int)fieldWidth;
                            profile_picture = new byte[width];
                            reader.GetBytes(columnIndex, 0, profile_picture, 0, profile_picture.Length);
                        }

                        tempMember.ProfilePicture = profile_picture;

                        if (reader.FieldCount > 10 && !reader.IsDBNull(10))
                        {
                            tempMember.PhotoMimeType = reader.GetString(10);
                        }
                        else
                        {
                            tempMember.PhotoMimeType = null;
                        }

                        _members.Add(tempMember);


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; //for sp_select_members_by_name_and_or_email
            }
            finally
            {
                conn.Close(); //for sp_select_members_by_name_and_or_email
            }
            return _members;  //for sp_select_members_by_name_and_or_email
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/25
        /// 
        /// get a list of all members by first name, last or email
        /// </summary>
        public List<Member> SearchMembersByFirstNameLastNameOrEmail(string firstName, string lastName, string email)
        {
            List<Member> members = new List<Member>();//SearchMembersByFirstNameLastNameOrEmail

            // connection
            DBConnection connectionFactory = new DBConnection();//SearchMembersByFirstNameLastNameOrEmail
            var conn = connectionFactory.GetDBConnection();//SearchMembersByFirstNameLastNameOrEmail

            // command text
            var cmdText = "sp_select_members_by_name_and_or_email";//SearchMembersByFirstNameLastNameOrEmail

            // command
            var cmd = new SqlCommand(cmdText, conn);//SearchMembersByFirstNameLastNameOrEmail

            // command type
            cmd.CommandType = CommandType.StoredProcedure; //SearchMembersByFirstNameLastNameOrEmail

            cmd.Parameters.Add("@first_name", SqlDbType.NVarChar, 25);
            cmd.Parameters["@first_name"].Value = firstName;
            cmd.Parameters.Add("@family_name", SqlDbType.NVarChar, 25);
            cmd.Parameters["@family_name"].Value = lastName;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 254);
            cmd.Parameters["@email"].Value = email;

            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();//SearchMembersByFirstNameLastNameOrEmail

                if (reader.HasRows)
                {
                    while (reader.Read())//SearchMembersByFirstNameLastNameOrEmail
                    {
                        Member member = new Member();//SearchMembersByFirstNameLastNameOrEmail
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


                        members.Add(member);//SearchMembersByFirstNameLastNameOrEmail

                    }
                }
            }
            catch (Exception ex)//SearchMembersByFirstNameLastNameOrEmail
            {
                throw ex;//SearchMembersByFirstNameLastNameOrEmail
            }
            return members;//SearchMembersByFirstNameLastNameOrEmail
        }
    }
}
