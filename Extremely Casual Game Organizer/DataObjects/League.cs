/// <LeagueObject>
/// Alex Korte
/// Created: 2023/02/04
/// 
/// </summary>
/// This class is used to create the League Object
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
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
        public decimal LeagueDues { get; set; }
        public Boolean Active { get; set; }//open regestration or closed
        public int MemberID { get; set; }//person who made the league
        public bool? Gender { get; set; }//nullable and if there is a gender requirement
        public string Description { get; set; }//description of the league
        public string Name { get; set; }//name of the league

        public League()
        {

        }

        public League(int leagueID, int sportID, decimal leagueDues, bool active, int memberID, bool? gender
            , string description, string name)
        {
            this.LeagueID = leagueID;
            this.SportID = sportID;
            this.LeagueDues = leagueDues;
            this.Active = active;
            this.MemberID = memberID;
            this.Gender = gender;
            this.Description = description;
            this.Name = name;
        }
    }
}
