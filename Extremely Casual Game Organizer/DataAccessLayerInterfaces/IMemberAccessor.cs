
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
        Member SelectAUserByID(int member_id);
        int SetUserToInactive(int member_id);
        bool UpdateMemberPassword(int member_id, string password, string oldPassword);
        Member SelectMemberByEmail(string email);
        List<Member> SelectMemberByMemberFullName(string firstName, string lastName);
        List<Member> SelectMemberByMemberFirstName(string firstName);
    }
}
