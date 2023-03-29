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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{


    /// <summary>
    /// Heritier Otiom
    /// Created: 2023/01/31
    /// 
    /// Fake Message Accessor
    /// </summary>
    public class FakeMessageAccessor : IMessageAccessor
    {

        List<Message> _messages = null;
        private List<Member> _members = new List<Member>();



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Constructor
        /// </summary>
        public FakeMessageAccessor()
        {
            _messages = new List<Message>();

            _messages.Add(new Message()
            {
                MessageID = 123,
                UserIdSender = 1001,
                UserIdReceiver = 1002,
                Date = DateTime.Now,
                Important = false,
                MessageText = "Hello !"
            });

            _messages.Add(new Message()
            {
                MessageID = 124,
                UserIdSender = 1002,
                UserIdReceiver = 1003,
                Date = DateTime.Now,
                Important = false,
                MessageText = "How ar you !"
            });

            _members.Add(
                new Member()
                {
                    MemberID = 100,
                    FirstName = "Lebron",
                    FamilyName = "James",
                    Birthday = new DateTime(2000, 02, 24),
                    Bio = "",
                    PhoneNumber = "319-519-1234",
                    ProfilePhoto = null,
                    PasswordHash = "P@ssw0rd",
                    Email = "lebron@gmail.com",
                    Active = true,
                    Gender = true
                }
            );
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Send a message
        /// </summary>
        public int AddMessage(Message message)
        {
            if (message.MessageText != null && message.MessageText != "") return 1;
            else return 0;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select member by member_ID
        /// </summary>
        public List<Member> GetMembersByMemberID(int memberId)
        {
            var _member = _members.Where(b => b.MemberID == memberId).ToList();

            if (_member == null)
            {
                throw new ApplicationException("Member not found!");
            }
            int num = _members.FindIndex(b => b.MemberID == memberId);

            return _member;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select a conversation between one member with others
        /// </summary>
        public List<Message> GetMessagesByMemberIDSentToOtherMemberID(int memberId, int otherMemberId)
        {
            var messages = _messages.Where(b => b.UserIdSender == memberId ||
                                        b.UserIdReceiver == memberId ||
                                        b.UserIdReceiver == otherMemberId||
                                        b.UserIdSender == otherMemberId).ToList();
            if (_members == null)
            {
                throw new ApplicationException("Message not found!");
            }

            return messages;
        }
    }
}
