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
    public class MessageAccessor : IMessageAccessor
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Send a message to other members
        /// </summary>
        public int AddMessage(Message message)
        {
            // return object
            int rowsAffected = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = @"sp_create_message";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@user_id_sender", SqlDbType.Int);
            cmd.Parameters.Add("@user_id_reciever", SqlDbType.Int);
            cmd.Parameters.Add("@date_and_time", SqlDbType.DateTime);
            cmd.Parameters.Add("@important", SqlDbType.Bit);
            cmd.Parameters.Add("@message", SqlDbType.NVarChar, 100);

            // parameter values
            cmd.Parameters["@user_id_sender"].Value = message.UserIdSender;
            cmd.Parameters["@user_id_reciever"].Value = message.UserIdReceiver;
            cmd.Parameters["@date_and_time"].Value = message.Date;
            cmd.Parameters["@important"].Value = message.Important;
            cmd.Parameters["@message"].Value = message.MessageText;

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
                throw new ApplicationException("Cannot send the message");
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
        /// Get the list of all members I already send a message to
        /// </summary>
        public List<Member> GetMembersByMemberID(int memberId)
        {
            List<Member> members = new List<Member>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            var cmdText = "sp_select_people_I_texted_by_user_id";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@member_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@member_id"].Value = memberId;

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
                        if (reader.GetInt32(0)!= memberId)
                        {
                            Member member = new Member()
                            {
                                MemberID = reader.GetInt32(0),
                                Email = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                FamilyName = reader.GetString(3)
                                //ProfilePhoto = reader.GetS   tring(4)
                            };

                            if (reader.IsDBNull(4) == false) member.ProfilePhoto = (byte[])reader[4];
                            else member.ProfilePhoto = null;
                            members.Add(member);
                        }

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
        /// Select all my messages and the messages of other user for me
        /// </summary>
        public List<Message> GetMessagesByMemberIDSentToOtherMemberID(int memberId, int otherMemberId)
        {
            List<Message> messages= new List<Message>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            var cmdText = "sp_select_messages_by_user_id";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@member_id", SqlDbType.Int);
            cmd.Parameters.Add("@otherMemberId", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@member_id"].Value = memberId;
            cmd.Parameters["@otherMemberId"].Value = otherMemberId;

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
                        Message message = new Message()
                        {
                            MessageID = reader.GetInt32(0),
                            UserIdSender = reader.GetInt32(1),
                            UserIdReceiver = reader.GetInt32(2),
                            Date = reader.GetDateTime(3),
                            Important = reader.GetBoolean(4),
                            MessageText = reader.GetString(5)
                        };

                        messages.Add(message);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messages;
        }
    }
}
