
﻿/// <summary>
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


﻿using System;
using System.Collections.Generic;
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
        bool UpdateMemberPassword(int member_id, string password, string oldPassword);
        Member SelectMemberByEmail(string email);
        List<Member> SelectMemberByMemberFullName(string firstName, string lastName);
        List<Member> SelectMemberByMemberFirstName(string firstName);
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
    }
}
