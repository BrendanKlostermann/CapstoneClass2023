using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IMemberManager
    {
        bool EditMemberPassword(int member_id, string oldPassword, string newPassword);
        string HashSha256(string source);
        Member RetrieveMemberByEmail(string email);
        List<Member> SearchMemberByFirstName(string firstName);
        List<Member> SearchMemberByFirstAndLastName(string fistName, string lastName);
    }
}
