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
        /// <summary>
        /// Create list of Members for data fakes
        /// </summary>
        /// 
        List<Member> _members = null;

        public MemberAccessorFake()
        {
            _members = new List<Member>()
            {
                new Member{
                    MemberID = 10000,
                    Email = "johns@company.com",
                    FirstName = "John",
                    FamilyName = "Smith",
                    Birthday =  new DateTime(2023, 01, 25),
                    PhoneNumber = "319-999-9999",
                    PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
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
                    PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
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
                    PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                    Gender = true,
                    Active = true,
                    Bio = "Yet Another Member bio"
                }
            };
        }

        public Member SelectMemberByEmail(string email)
        {
            Member returnMember = null;

            foreach (Member member in _members)
            {
                if (member.Email == email)
                {
                    returnMember = member;
                    break;
                }
            }

            return returnMember;
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
            /// 
            bool result = false;

            try
            {
                int memberID = member_id;
                string newPassword = password;
                string currentPassword = oldPassword;

                foreach(Member member in _members)
                {
                    if (member.MemberID == memberID && currentPassword == member.PasswordHash)
                    {
                        member.PasswordHash = newPassword;

                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
    }
}
