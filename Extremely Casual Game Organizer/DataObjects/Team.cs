
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
        public int MemberID { get; set; }
        public string Description { get; set; }

        public Team()
        {

        }


        public Team(int teamID, string teamName, bool? gender, int sportID, int memberID, string description){
            this.TeamID = teamID;
            this.TeamName = teamName;
            this.Gender = gender;
            this.SportID = sportID;
            this.MemberID = memberID;
            this.Description = description;
        }

        /// <TeamView>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Creating a team view, changing member id to member name
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public class TeamVM : Team
        {
            public string FirstName { get; set; }//first name to display
            public string LastName { get; set; }//last name to display
            public string GenderAsText { get; set; } //allows me to change how i display gender

            //generic constructor-alex
            public TeamVM()
            {

            }

            //custom constructor-alex
            public TeamVM(int teamID, string teamName, bool? gender, int sportID, string description, string firstName)
            {
                this.TeamID = teamID;
                this.TeamName = teamName;
                this.Gender = gender;
                this.SportID = sportID;
                this.Description = description;
                this.FirstName = firstName;

            }
        }
    }
}
