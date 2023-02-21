/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Accessor class for Member. Contains methods to interact with database.
/// </summary>


﻿using System;
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
        public Member SelectAUserByID(int member_id)
        {
            throw new NotImplementedException();
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

        public bool UpdateMemberPassword(int member_id, string password, string oldPassword)
        {
            bool result;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_reset_password";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
    }
}
