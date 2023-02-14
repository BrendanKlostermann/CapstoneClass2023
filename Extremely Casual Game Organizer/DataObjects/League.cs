using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class League
    {
        public int League_ID { get; set; }
        public int Sport_ID { get; set; }
        public decimal League_Dues { get; set;}
        public bool Active { get; set; }
        public int Member_id { get; set; }
        public bool? Gender { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Max_Num_Of_Teams { get; set; }



        public League(int leagueID, int sportID, decimal dues, bool gender, string description)
        {
            League_ID = leagueID;
            Sport_ID = sportID;
            League_Dues = dues;
            Gender = gender;
            Description = description;
        }

        public League()
        {

        }
    } 
}
