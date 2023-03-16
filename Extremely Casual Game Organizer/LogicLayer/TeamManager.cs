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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using DataObjects;
using LogicLayerInterfaces;
using System.Data;

namespace LogicLayer
{
    public class TeamManager : ITeamManager
    {
        ITeamAccessor _teamAccessor = null;
        
        public TeamManager()
        {
            _teamAccessor = new TeamAccessor();
        }
        public TeamManager(ITeamAccessor ta)
        {
            _teamAccessor = ta;
        }

        /// <TeamManager Getting list of all teams>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// This method will get us all teams to display
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public List<Team> RetrieveAllTeams()
        {
            List<Team> _teams = null;
            try
            {
                _teamAccessor = new TeamAccessor();
                _teams = _teamAccessor.SelectAllTeams();
                return _teams;
            }catch(ApplicationException up)
            {
                throw new ApplicationException("No teams in the System", up);
            }
        }

        /// <summary>
        /// Created by: Jacob Lindauer
        /// Date 2023/20/02
        /// 
        /// Method to retreive team object from data accessor.
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        /// 

        public Team RetrieveTeamByTeamID(int team_id)
        {
            Team selectedTeam = null;

            try
            {
                selectedTeam = _teamAccessor.SelectTeamByTeamID(team_id);

                if (selectedTeam == null)
                {
                    throw new ArgumentException("Invalid Team ID");
                }
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Team Not Found", ae);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Team Not Found", ex);
            }

            return selectedTeam;
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
