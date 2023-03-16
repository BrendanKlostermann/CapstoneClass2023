/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Member Manager
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MemberManager: IMemberManager
    {
        private IMemberAccessor _memberAccessor = null;

        public MemberManager()
        {
            _memberAccessor = new MemberAccessor();
        }
        public MemberManager(IMemberAccessor memberAccessor)
        {
            _memberAccessor = memberAccessor;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Add a new user
        /// </summary>
        public int AddUser(Member member) // Add new user
        {
            int requestedUser = 0;

            try
            {
                requestedUser = _memberAccessor.AddUser(member);
            }
            catch (Exception)
            {
                requestedUser = 0; ;
            }
            return requestedUser;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get member by memberID
        /// </summary>
        public Member GetMemberByMemberID(int MemberID)
        {
            Member member = null;
            try
            {
                member = _memberAccessor.GetMemberByMemberID(MemberID);
            }
            catch (Exception)
            {
                member = null;
            }
            return member;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get member by name
        /// </summary>
        public List<Member> GetMemberByName(string name)
        {
            List<Member> members = null;
            try
            {
                members = _memberAccessor.GetMemberByFirstNameFamilyNameAndEmail(name);
            }
            catch (Exception)
            {
                members = null;
            }
            return members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all members
        /// </summary>
        public List<Member> GetMembers()
        {
            List<Member> members = null;
            try
            {
                members = _memberAccessor.GetListOfAllMembers();
            }
            catch (Exception)
            {
                members = null;
            }
            return members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Hashing the password
        /// </summary>
        public string HashSha256(string source)
        {
            string result = "";

            // create a byte array
            byte[] data;

            // create a .NET hash provider object
            using (SHA256 sha256hasher = SHA256.Create())
            {
                // hash the input
                data = sha256hasher.ComputeHash(
                    Encoding.UTF8.GetBytes(source));
            }

            // create an output stringbuilder object
            var s = new StringBuilder();

            // loop through the hashed output making characters
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // convert the StringBuilder to a string
            result = s.ToString();

            return result.ToUpper();
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update profile picture for a member
        /// </summary>
        public int UpdateProfilePicture(Member member)
        {
            int requestedUser = 0;

            try
            {
                requestedUser = _memberAccessor.UpdateProfilePicture(member);
            }
            catch (Exception)
            {
                requestedUser = 0;
            }
            return requestedUser;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update member Bio
        /// </summary>
        public int UpdateUserBio(Member member)
        {
            int requestedUser = 0;

            try
            {
                requestedUser = _memberAccessor.UpdateUserBio(member);
            }
            catch (Exception)
            {
                requestedUser = 0; ;
            }
            return requestedUser;
        }
    }
}
