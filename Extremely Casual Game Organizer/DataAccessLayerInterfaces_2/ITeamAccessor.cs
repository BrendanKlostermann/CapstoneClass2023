/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Accessor for Team
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface ITeamAccessor
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a new team
        /// </summary>
        int AddTeam(Team team); // Add new team


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get sport description
        /// </summary>
        List<string> getSportName(); // Get sports descriptions


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Search a team by name
        /// </summary>
        List<TeamSport> getTeamByTeamName(string name, int sport_id); //Get team by team name


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all teams a user is into
        /// </summary>
        List<TeamMemberAndSport> getTeamByMemberID(int member_id); //Get team by member ID and details about the sport, gender and others.

    }
}
