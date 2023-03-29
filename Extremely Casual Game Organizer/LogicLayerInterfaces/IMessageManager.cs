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

using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IMessageManager
    {


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Send a message to other members
        /// </summary>
        int AddMessage(Message message);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select all my messages and the messages of other user for me
        /// </summary>
        List<Message> GetMessages(int memberId, int otherMemberId);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get the list of all members I already send a message to
        /// </summary>
        List<Member> GetMembers(int memberId);
    }
}
