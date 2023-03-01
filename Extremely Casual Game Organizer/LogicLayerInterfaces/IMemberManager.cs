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

﻿using System;
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

    }
}
