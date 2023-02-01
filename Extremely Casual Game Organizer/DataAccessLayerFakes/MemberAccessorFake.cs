/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Fake Data used in place of real Data Accessor for Member.
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
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class MemberAccessorFake : IMemberAccessor
    {
        List<Member> _members = null;

        public MemberAccessorFake()
        {
            _members = new List<Member>();
            Member member1 = new Member(100000, "test1@gmai.com", "test1", "account", DateTime.Now, "3198273029", true, true, "this is a test account");
            _members.Add(member1);
            Member member2 = new Member(100001, "test2@gmai.com", "test2", "account", DateTime.Now, "3198273029", true, true, "this is a test account 2");
            _members.Add(member2);

        }


        public Member SelectAUserByID(int member_id)
        {
            foreach(Member mem in _members)
            {
                if(mem.member_id == member_id)
                {
                    return mem;
                }
            }
            throw new ApplicationException("No member was found with ID: " + member_id);

        }

        public int SetUserToInactive(int member_id)
        {
            int count = 0;
            foreach(Member mem in _members)
            {
                if (mem.member_id == member_id)
                {
                    mem.active = false;
                    count++;
                }
            }
            return count;
        }

        
    }
}
