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
        bool UpdateMemberPassword(int member_id, string password, string oldPassword);
        Member SelectMemberByEmail(string email);

        List<Member> SelectMemberByMemberFullName(string firstName, string lastName);
        List<Member> SelectMemberByMemberFirstName(string firstName);
    }
}
