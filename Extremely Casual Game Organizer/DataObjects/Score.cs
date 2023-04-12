using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Score
    {
        public int TeamID { get; set; }
        public int GameID { get; set; }
        public decimal? TeamScore { get; set; }
    }
}
