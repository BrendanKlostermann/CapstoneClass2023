using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class LeagueRequest
    {
        public int RequestID { get; set; }
        public int LeagueID { get; set; }

        public int TeamID { get; set; }
        public string Status { get; set; }
    }
}
