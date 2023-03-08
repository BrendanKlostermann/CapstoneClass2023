/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// A data object representing a League of sports
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class League
    {
        public int LeagueID { get; set; }
        public int SportID { get; set; }
        public decimal LeagueDues { get; set;}
        public bool Active { get; set; }
        public int MemberID { get; set; }
        public bool? Gender { get; set; }
        public string LeagueDescription { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfTeams { get; set; }


        public League(int league_id, int sport_id, decimal league_dues, bool active, int member_id, bool gender, string description, string name, int max)
        {
            LeagueID = league_id;
            SportID = sport_id;
            LeagueDues = league_dues;
            Active = active;
            MemberID = member_id;
            Gender = gender;
            LeagueDescription = description;
            MaxNumberOfTeams = max;
        }
        public League()
        {

        }

        public class LeagueVM : League
        {
            public string SportName { get; set; }
            public string genderAsText { get; set; }
        }

    } 
}
