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

/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class will contain the properties and View Models for the
/// League data Object.
/// </summary>
///
﻿/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// A data object representing a League of sports
/// </summary>
///
/// <remarks>
/// Elijah Morgan
/// Updated: 2023/04/24
/// 
/// Added AssignedGender to LeagueVM
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
        public decimal LeagueDues { get; set; }
        public bool Active { get; set; }//open regestration or closed
        public int MemberID { get; set; }//person who made the league
        public bool? Gender { get; set; }//nullable and if there is a gender requirement
        public string Description { get; set; }//description of the league
        public string Name { get; set; } //name of the league
        public int MaxNumOfTeams { get; set; }

        public League(int league_id, int sport_id, decimal league_dues, bool active, int member_id, bool? gender, string description, string name, int max = 0)
        {
            LeagueID = league_id;
            SportID = sport_id;
            LeagueDues = league_dues;
            Active = active;
            MemberID = member_id;
            Gender = gender;
            Description = description;
			Name = name;
            MaxNumOfTeams = max;
        }
		
        public League()
        {

        }
	}

    public class LeagueGridVM
    {
        public int LeagueID { get; set; }
        public string LeagueName { get; set; }
        public string Description { get; set; }
        public string SportName { get; set; }
        public string LeagueCreator { get; set; }
        public string Gender { get; set; }
        public bool? GenderBool { get; set; }

    }

	public class LeagueVM : League
	{
        public string AssignedGender { get; set; }
        public string SportName { get; set; }
		public string genderAsText { get; set; }
	}
 
}
