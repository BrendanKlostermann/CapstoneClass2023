using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TeamMember
    {
        public int TeamID { get; set; }
        public string Description { get; set; }
        public bool Starter { get; set; }
        public int MemberID { get; set; }
    }
}
