using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Practice
    {
        public int PracticeID { get; set; }
        public string Location { get; set; }
        public int TeamID { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
    }
}
