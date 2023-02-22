/// <MemberObject>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to create the Member Object
/// 
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
        public string Password { get; set; }
        public bool? Gender { get; set; }
        public Boolean Active { get; set; }
        public string Bio { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string PhotoMimeType { get; set; }

        public Member()
        {

        }

        public Member(string name)
        {
            this.FirstName = name;
        }

        public Member(int memberId, string email, string firstName, string familyName
            , DateTime birthDay, string phoneNumber
            , bool? gender, bool active, string bio)
        {
            this.MemberID = memberId;
            this.Email = email;
            this.FamilyName = firstName;
            this.FamilyName = familyName;
            this.Birthday = birthDay;
            this.PhoneNumber = phoneNumber;
            this.Gender = gender;
            this.Active = active;
            this.Bio = bio;
        }
    }


}

