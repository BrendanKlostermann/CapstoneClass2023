/// <LeagueTeamObject>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to create the LeagueTeam Object
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
    public class LeagueTeam
    {
        public int LeagueID { get; set; }
        public int TeamID { get; set; }

        public LeagueTeam(int leagueID, int teamID)
        {
            this.LeagueID = leagueID;
            this.TeamID = teamID;
        }
    }

}
