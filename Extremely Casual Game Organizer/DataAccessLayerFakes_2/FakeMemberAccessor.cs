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
    /// Member Accessor
    /// </summary>
    public class FakeMemberAccessor : IMemberAccessor
    {
        private List<Member> _members = new List<Member>();
        private DateTime adulttxtBirthday = new DateTime(2005, 01, 01);

        private List<Member> testingMembers = new List<Member>();


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Constructor
        /// </summary>
        public FakeMemberAccessor()
        {
            _members.Add(
                new Member()
                {
                    MemberID = 123,
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

            _members.Add(
                new Member()
                {
                    MemberID = 124,
                    FirstName = "Steph",
                    FamilyName = "Curry",
                    Birthday = new DateTime(2005, 01, 20),
                    Bio = "",
                    PhoneNumber = "319-519-4567",
                    ProfilePhoto = null,
                    PasswordHash = "P@ssw0rd",
                    Email = "steph@gmail.com",
                    Active = true,
                    Gender = true
                }
            );
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a user
        /// </summary>
        public int AddUser(Member member)
        {
            try
            {
                if (member.Email == null || member.Email == ""
                    || member.Email.Length < 6 || !(member.Email.Contains("@"))
                    || !(member.Email.Contains("@"))
                    || member.FirstName == null || member.FirstName == ""
                    || member.FamilyName == "" || member.FirstName == ""
                    || member.Birthday.Year > adulttxtBirthday.Year
                    || member.PhoneNumber.Length < 10
                   )
                {
                    return 0;
                }
                else
                {
                    _members.Add(member);
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select all members
        /// </summary>
        public List<Member> GetListOfAllMembers()
        {
            return _members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Member either by first name, family name or email
        /// </summary>
        public List<Member> GetMemberByFirstNameFamilyNameAndEmail(string name)
        {
            var members = _members.Where(b => b.FirstName == name ||
                                        b.FamilyName== name ||
                                        b.Email == name).ToList();
            if (members == null)
            {
                throw new ApplicationException("Member not found.");
            }
            return members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Member by member_ID
        /// </summary>
        public Member GetMemberByMemberID(int MemberID)
        {
            var member = _members.Where(b => b.MemberID == MemberID).ToList();

            if (member == null)
            {
                throw new ApplicationException("Member not found");
            }
            int num = _members.FindIndex(b => b.MemberID == MemberID);
            
            return _member[num];
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update profile picture of a member
        /// </summary>
        public int UpdateProfilePicture(Member member)
        {
            var member = _members.Where(b => b.MemberID == member.MemberID).ToList();

            if (member == null)
            {
                throw new ApplicationException("Update Failed.");
            }

            int num = _members.FindIndex(b => b.MemberID == member.MemberID);

            _members[num].ProfilePhoto = member.ProfilePhoto;


            return 1;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update bio of a member
        /// </summary>
        public int UpdateUserBio(Member member)
        {
            var member = _members.Where(b => b.MemberID == member.MemberID).ToList();

            if (member == null)
            {
                throw new ApplicationException("Update Failed.");
            }

            int num = _members.FindIndex(b => b.MemberID == member.MemberID);

            _members[num].Bio = member.Bio;


            return 1;
        }
    }
}
