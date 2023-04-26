using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TournamentRequest
    {
        public int TournamentRequestID { get; set; }
        public int TournamentID { get; set; }
        public int TeamID { get; set; }
        public string Status { get; set; }
    }
}
