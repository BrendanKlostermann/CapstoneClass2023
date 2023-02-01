/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Interfaces for MemberManager classes.
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

namespace LogicLayerInterfaces
{
    public interface IMemberManager
    {
        int EditUserToInactive(int member_id);
    }
}
