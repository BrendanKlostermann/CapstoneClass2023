
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
        public byte[] ProfilePicture { get; set; }
        public string PhotoMimeType { get; set; }
        public List<string> Roles { get; set; }

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Property for Member
        /// </summary>
        public string PasswordHash { get; set; }
        public byte[] ProfilePhoto { get; set; }



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
        }


        public Member(int mem_id, string email, string fName, string flName, DateTime bDay, string pNumber, bool gender, bool active, string bio)
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

