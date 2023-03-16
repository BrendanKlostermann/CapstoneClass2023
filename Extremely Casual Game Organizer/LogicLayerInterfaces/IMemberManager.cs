/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Interfaces for MemberManager classes.
/// </summary>
///
/// <remarks>
/// Updater Name: Jacob Lindauer
/// Updated: 2023/02/15
/// 
/// Added Edit MemberPassword and HashSha256 Interface Methods.
/// Added LoginMember - Toney Hale
/// </remarks>
/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// I Member Manager
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
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IMemberManager
    {
        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method calls the MemberAccessor method SetUserToInactive
        /// </summary>
        /// 
        /// <returns> int count of rows effected </returns>
        int EditUserToInactive(int member_id);
        bool EditMemberPassword(int member_id, string oldPassword, string newPassword);
        string HashSha256(string source);
        Member RetrieveMemberByEmail(string email);
        List<Member> SearchMemberByFirstName(string firstName);
        List<Member> SearchMemberByFirstAndLastName(string fistName, string lastName);
        bool ResetPasswordToDefault(int memberID);



        /// <TeamObject>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Method to get a list of members by member ID (used to get coaches)
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        List<Member> RetrieveMembersByMemberID(List<int> memberID);
        List<Member> GetAListOfMembersByTeamID(int teamID);

        Member LoginMember(string email, string password);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        List<CalendarEvent> RetreiveMemberSchedule(int member_id);
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Adding a new user to the member table
        /// </summary>
        int AddUser(Member member);


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


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Return all members
        /// </summary>
        List<Member> GetMembers();


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Search for a member by first name, family name and/or email
        /// </summary>
        List<Member> GetMemberByName(string name);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get a member by memberID
        /// </summary>
        Member GetMemberByMemberID(int MemberID);
    }
}
