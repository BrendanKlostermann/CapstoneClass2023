    /// <summary>
    /// Brendan Klostermann
    /// Created: 2023/01/31
    /// 
    /// Member class used to hold Member data.
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Gender { get; set; }
        public bool Active { get; set; }
        public string Bio { get; set; }

        public Member(int mem_id,string email, string fName, string flName, DateTime bDay, string pNumber, bool gender, bool active, string bio)
        {
            this.MemberID = mem_id;
            this.Email = email;
            this.FirstName = fName;
            this.FamilyName = flName;
            this.Birthday = bDay;
            this.PhoneNumber = pNumber;
            this.Gender = gender;
            this.Active = active;
            this.Bio = bio;
        }
        public Member()
        {

        }
    }
}
