using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TeamRequest
    {
        public int TeamRequestID { get; set; }
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public string Status { get; set; }
    }
}
