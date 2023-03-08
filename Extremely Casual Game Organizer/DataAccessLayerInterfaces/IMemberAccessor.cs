
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
        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
        List<Member> SelectMemberByMemberFullName(string firstName, string lastName);
        /// <summary>
        /// Created By: Jacob Lindauer
        /// </summary>
        /// <returns></returns>
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

        int AuthenticateMember(string email, string password);
        List<string> SelectRolesByMemberID(int memberID);

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

    }
}
