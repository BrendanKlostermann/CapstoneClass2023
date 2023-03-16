/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Team Manager
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using DataAccessLayer;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TeamManager: ITeamManager
    {
        private ITeamAccessor _teamAccessor = null;

        public TeamManager()
        {
            _teamAccessor = new TeamAccessor();
        }
        public TeamManager(ITeamAccessor teamAccessor)
        {
            _teamAccessor = teamAccessor;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a team
        /// </summary>
        public int AddTeam(Team team) 
        {
            int requestTeam = 0;

            try
            {
                requestTeam = _teamAccessor.AddTeam(team);
            }
            catch (Exception)
            {
                //requestTeam = 0;
                throw new ApplicationException("Cannot create the team");
            }
            return requestTeam;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Sports names
        /// </summary>
        public List<string> getSportName()
        {
            List<string> sports = null;

            try
            {
                sports = _teamAccessor.getSportName();
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot read sports");
            }
            return sports;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select team by memberID
        /// </summary>
        public List<TeamMemberAndSport> getTeamByMemberID(int member_id)
        {
            List<TeamMemberAndSport> teams = null;

            try
            {
                teams = _teamAccessor.getTeamByMemberID(member_id);
            }
            catch (Exception)
            {
                throw new ApplicationException("Team not found");
            }
            return teams;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Search team by name
        /// </summary>
        public List<TeamSport> getTeamByTeamName(string _team, int sport_id)
        {
            List<TeamSport> team = null;

            try
            {
                team = _teamAccessor.getTeamByTeamName(_team, sport_id);
            }
            catch (Exception)
            {
                throw new ApplicationException("Team not found.");
            }
            return team;
        }
    }
}
