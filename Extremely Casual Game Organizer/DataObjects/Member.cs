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
        public string PasswordHash { get; set; }
        public bool? Gender { get; set; }
        public bool Active { get; set; }
        public string Bio { get; set; }
    }
}
