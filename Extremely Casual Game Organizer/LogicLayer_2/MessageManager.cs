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

using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MessageManager : IMessageManager
    {
        private IMessageAccessor messageAccessor = null;

        public MessageManager()
        {
            messageAccessor = new MessageAccessor();
        }
        public MessageManager(IMessageAccessor messageManager)
        {
            messageAccessor = messageManager;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Send a message to other members
        /// </summary>
        public int AddMessage(Message message)
        {
            int requestedUser = 0;

            try
            {
                requestedUser = messageAccessor.AddMessage(message);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot send tthe message");
            }
            return requestedUser;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select a member by memberID
        /// </summary>
        public List<Member> GetMembers(int memberId)
        {
            List<Member> members = null;
            try
            {
                members = messageAccessor.GetMembersByMemberID(memberId);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot read members");
            }
            return members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Messages I sent to other members
        /// </summary>
        public List<Message> GetMessages(int memberId, int otherMemberId)
        {
            List<Message> messages = null;
            try
            {
                messages = messageAccessor.GetMessagesByMemberIDSentToOtherMemberID(memberId, otherMemberId);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot read messages");
            }
            return messages;
        }
    }
}
