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
    }
}
