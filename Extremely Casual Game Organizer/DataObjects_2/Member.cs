/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Member DataObject
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
using static System.Net.Mime.MediaTypeNames;

namespace DataObjects
{
    public class Member
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Property for Member
        /// </summary>
        public int MemberID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool? Gender { get; set; }
        public bool Active { get; set; }
        public string Bio { get; set; }
        public byte[] ProfilePhoto { get; set; }

    }
}
