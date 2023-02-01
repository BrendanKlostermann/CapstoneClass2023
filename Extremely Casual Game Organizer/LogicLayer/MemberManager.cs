/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Manager class for Member class. Contains methods for interacting with member objects.
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerFakes;
using DataAccessLayer;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class MemberManager : IMemberManager
    {
        public int EditUserToInactive(int member_id)
        {
            MemberAccessor memberAccessor = new MemberAccessor();
            return memberAccessor.SetUserToInactive(member_id);
        }
    }
}
