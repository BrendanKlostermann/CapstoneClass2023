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
        public int member_id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string family_name { get; set; }
        public DateTime birthday { get; set; }
        public string phone_number { get; set; }
        public bool? gender { get; set; }
        public bool active { get; set; }
        public string bio { get; set; }

        public Member(int mem_id,string email, string fName, string flName, DateTime bDay, string pNumber, bool gender, bool active, string bio)
        {
            this.member_id = mem_id;
            this.email = email;
            this.first_name = fName;
            this.family_name = flName;
            this.birthday = bDay;
            this.phone_number = pNumber;
            this.gender = gender;
            this.active = active;
            this.bio = bio;
        }

    }
}
