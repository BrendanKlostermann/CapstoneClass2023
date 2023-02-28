/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Fake Data used in place of real Data Accessor for Member.
/// </summary>
///
/// <remarks>
/// Updater Name: Jacob Lindauer
/// Updated: 2023/02/10
/// 
/// Added method for UpdateMemberPassword
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class MemberAccessorFake : IMemberAccessor
    {
        List<Member> _members = null;
        private List<string> passwordHashes = new List<string>();

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This constructor creates a list of fake members.
        /// </summary>
        public MemberAccessorFake()
        {
            /// <summary> 
            /// Jacob LIndauer
            /// Created 2023/02/10
            /// 
            /// Constructor creates mock members for MemberManager Unit Testing. 
            /// </summary>
            _members = new List<Member>()
            {
                new Member{
                    MemberID = 10000,
                    Email = "johns@company.com",
                    FirstName = "John",
                    FamilyName = "Smith",
                    Birthday =  new DateTime(2023, 01, 25),
                    PhoneNumber = "319-999-9999",
                    Gender = true,
                    Active = true,
                    Bio = "Member bio"
                },

                new Member{
                    MemberID = 10001,
                    Email = "Narkk@company.com",
                    FirstName = "Mark",
                    FamilyName = "Johnson",
                    Birthday =  new DateTime(2022, 02, 12),
                    PhoneNumber = "319-888-8888",
                    Gender = true,
                    Active = false,
                    Bio = "Another Member bio"
                },

                new Member{
                    MemberID = 10002,
                    Email = "KevinW@company.com",
                    FirstName = "Kevin",
                    FamilyName = "Waters",
                    Birthday =  new DateTime(2020, 08, 10),
                    PhoneNumber = "319-777-7777",
                    Gender = true,
                    Active = true,
                    Bio = "Yet Another Member bio"
                }
            };
        }



        public Member SelectAUserByID(int member_id)
        {
            foreach (Member mem in _members)
            {
                if (mem.MemberID == member_id)
                {
                    return mem;
                }
            }
            throw new ApplicationException("No member was found with ID: " + member_id);

        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method loops through the member list for a matching MemberID and if it finds one it
        /// sets the member's active state to false.
        /// </summary>
        /// <returns> int count of rows effected </returns>
        public int SetUserToInactive(int member_id)
        {
            int count = 0;
            foreach (Member mem in _members)
            {
                if (mem.MemberID == member_id)
                {
                    mem.Active = false;
                    count++;
                }
            }
            return count;
        }




        public List<Member> SelectMemberByMemberFirstName(string firstName)
        {
            List<Member> results = new List<Member>();

            try
            {
                var memberSearch = from user in _members where user.FirstName.Equals(firstName) select new Member { FirstName = user.FirstName, FamilyName = user.FamilyName, MemberID = user.MemberID };

                results = memberSearch.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return results;
        }

        public List<Member> SelectMemberByMemberFullName(string firstName, string lastName)
        {
            List<Member> results = new List<Member>();

            try
            {
                var memberSearch = from user in _members where user.FirstName.Equals(firstName) where user.FamilyName.Equals(lastName) select new Member { FirstName = user.FirstName, FamilyName = user.FamilyName, MemberID = user.MemberID };

                results = memberSearch.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return results;
        }

        public bool UpdateMemberPassword(int member_id, string password, string oldPassword)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created 01/24/2022
            /// 
            /// Accessor fake for unit testing resetting the password.
            /// Method to Update Passord should take in both old and new password. Verify memberID and that old input password = old password
            /// </summary>
            /// <param name="member_id"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            /// PLEASE REVISIT JACOB
            ////////////////////////////////////////bool result = false;

            ////////////////////////////////////////try
            ////////////////////////////////////////{
            ////////////////////////////////////////    int memberID = member_id;
            ////////////////////////////////////////    string newPassword = password;
            ////////////////////////////////////////    string currentPassword = oldPassword;

            ////////////////////////////////////////    foreach(Member member in _members)
            ////////////////////////////////////////    {
            ////////////////////////////////////////        if (member.MemberID == memberID && currentPassword == member.PasswordHash)
            ////////////////////////////////////////        {
            ////////////////////////////////////////            member.PasswordHash = newPassword;

            ////////////////////////////////////////            result = true;
            ////////////////////////////////////////        }
            ////////////////////////////////////////    }
            ////////////////////////////////////////}
            ////////////////////////////////////////catch (Exception ex)
            ////////////////////////////////////////{

            ////////////////////////////////////////    throw ex;
            ////////////////////////////////////////}

            ////////////////////////////////////////return result;
            return false;
        }
        /// <summary>
        /// Michael Haring
        /// Created: 2023/02/14
        /// 
        /// </summary>
        /// Fake data to test updating member password hash to default
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public int UpdatePasswordHashToDefault(int memberID, string passwordHash)
        {
            ////////    int rows = 0;
            ////////    var member = _members.Where(b => b.MemberID == memberID).First();

            ////////    if (member == null)
            ////////    {
            ////////        // employee not found
            ////////        throw new ApplicationException("Bad member id.");
            ////////    }


            ////////    member.PasswordHash = passwordHash;

            ////////    if (member.PasswordHash == "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e")
            ////////    {
            ////////        rows = 1;
            ////////    }
            ////////    return rows;
            return 1;
        }


        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// fakes for authenticating a member
        /// </summary>
        public int AuthenticateMember(string email, string passwordHash)
        {
            int result = 0;

            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].Email == email && passwordHashes[i] == passwordHash)
                {
                    result++;
                }
            }

            return result;
        }

                /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// Fakes for selecting a member
        /// </summary>

        public Member SelectMemberByEmail(string email)
        {
            Member member = null;

            foreach (var fakeMember in _members)
            {
                if (fakeMember.Email == email)
                {
                   member = fakeMember;
                    break;
                }
            }

            if (member == null)
            {
                throw new ApplicationException("User not found.");
            }
            return member;
        }

        public List<string> SelectRolesByMemberID(int memberID)
        {
            throw new NotImplementedException();
        }
    }
}
