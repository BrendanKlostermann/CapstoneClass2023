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

namespace DataObjects
{
    public class Message
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Property for Message
        /// </summary>
        public int MessageID { get; set; }
        public int UserIdSender { get; set; }
        public int UserIdReceiver { get; set; }
        public DateTime Date { get; set; }
        public bool Important { get; set; }
        public string MessageText { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string Photo { get; set; }


    }
}
