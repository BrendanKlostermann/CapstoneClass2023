/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Accessor for Member
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IMemberAccessor
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Adding a new user to the member table
        /// </summary>
        int AddUser(Member member); // Add new User


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Return all members
        /// </summary>
        List<Member> GetListOfAllMembers();


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Search for a member by first name, family name and/or email
        /// </summary>
        List<Member> GetMemberByFirstNameFamilyNameAndEmail(string name);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get a member by memberID
        /// </summary>
        Member GetMemberByMemberID(int MemberID);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update member bio
        /// </summary>
        int UpdateUserBio(Member member);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Assign a profile picture to the member table
        /// </summary>
        int UpdateProfilePicture(Member member);
    }
}
