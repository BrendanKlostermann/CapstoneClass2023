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
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class MemberManager : IMemberManager
    {

        private IMemberAccessor _memberAccessor = null;
        private MemberAccessorFake _fakeMemberAccessor = null;

        public MemberManager()
        {
            _memberAccessor = new MemberAccessor();
        }
        public MemberManager(IMemberAccessor ma)
        {
            _memberAccessor = ma;
        }

        public int EditUserToInactive(int member_id)
        {
            try
            {
                
                return _memberAccessor.SetUserToInactive(member_id);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Member not found.",ex);
            }
        }
    }
}
