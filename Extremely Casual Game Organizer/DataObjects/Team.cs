using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public bool? Gender { get; set; }
        public int SportID { get; set; }
    }
}
