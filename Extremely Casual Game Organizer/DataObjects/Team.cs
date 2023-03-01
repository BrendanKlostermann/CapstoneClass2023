
﻿/// <TeamObject>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to create the Team Object
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

﻿using System;
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
        public string Description { get; set; }
		
        public Team()
        {
            
        }

        public Team(int teamID, string teamName, bool? gender, int sportID, string description){
            this.TeamID = teamID;
            this.TeamName = teamName;
            this.Gender = gender;
            this.SportID = sportID;
            this.Description = description;
        }
    }
}
