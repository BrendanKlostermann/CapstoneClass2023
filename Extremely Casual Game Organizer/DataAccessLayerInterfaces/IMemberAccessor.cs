/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Interface for MemberAccessor classes.
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

namespace DataAccessLayerInterfaces
{
    public interface IMemberAccessor
    {
        Member SelectAUserByID(int member_id);
        int SetUserToInactive(int member_id);
    }
}
