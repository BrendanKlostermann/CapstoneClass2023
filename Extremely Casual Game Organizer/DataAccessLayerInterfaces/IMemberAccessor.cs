
/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Interface for MemberAccessor classes.
/// </summary>
///
/// <remarks>
/// Updater Name: Jacob Lindauer
/// Updated: 2023/02/10
/// 
/// Added Method for UpdateMemberPassword
/// </remarks>
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IMemberAccessor
    {
        /// <MemberAccessor>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Method to get a list of members by their member id
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        Member SelectAUserByID(int memberID);
        int SetUserToInactive(int member_id);
        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        bool UpdateMemberPassword(int member_id, string password, string oldPassword);
        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        Member SelectMemberByEmail(string email);
        int UpdatePasswordHashToDefault(int memberID, string passwordHashes);

        /// <MemberAccessor>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Method to get a list of members by their member id
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        List<Member> SelectAllMembersByMemberID(List<int> memberID);


        /// <MemberAccessor>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Method to get a list of members by their member id
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        List<Member> SelectAllMembersByTeamID(int memberID);

        int AuthenticateMember(string email, string password);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        DataTable SelectPracticesByMemberID(int member_id);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        DataTable SelectGamesByMemberID(int member_id);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        DataTable SelectTournamentGamesByMemberID(int member_id);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        DataTable SelectAvailabilityByMemberID(int member_id);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        bool InsertCalendarEvent(CalendarEvent insertEvent, int member_id);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        bool UpdateCalendarEvent(CalendarEvent updateEvent, int member_id);

        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        bool DeleteCalendarEvent(CalendarEvent deleteEvent, int member_id);

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

        //List<Member> SearchMemberByFirstAndLastName(string firstName, string lastName);


        List<Member> SelectAListOfMembersByNameAndOrEmail(string firstName, string lastName, string email);

        List<Member> SearchMembersByFirstNameLastNameOrEmail(String firstName, String lastName, String email);

    }
}
