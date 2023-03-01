using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class TeamAccessorFake : ITeamAccessor
    {
        List<Team> _teamList = null;
        public TeamAccessorFake()
        {
            _teamList = new List<Team>
            {
                new Team()
                {
                    TeamID = 1000,
                    TeamName = "TheTestTeam1",
                    Gender = true,
                    SportID = 1001
                },
                new Team()
                {
                    TeamID = 1001,
                    TeamName = "TheTestTeam2",
                    Gender = true,
                    SportID = 1001
                },
                new Team()
                {
                    TeamID = 1002,
                    TeamName = "TheTestTeam3",
                    Gender = false,
                    SportID = 1002
                },
                new Team()
                {
                    TeamID = 1003,
                    TeamName = "TheTestTeam4",
                    Gender = null,
                    SportID = 1002
                }

            };
        }

        public int DeleteAMemberFromATeamByMemberIdAndTeamID(int memberId, int teamId)
        {
            throw new NotImplementedException();
        }

        public List<Member> SelectAllmembersByTeamID(int teamId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to select all teams
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Team> SelectAllTeams()
        {
            try
            {
                if (_teamList.Count > 0)
                {
                    return _teamList;//if there are 1 or more teams send list back
                }
                else
                {
                    return _teamList = new List<Team>();//else make a list of teams and send it back empty
                }
            }catch(ApplicationException up)
            {
                throw new ApplicationException("There are no teams", up);
            }

        }

        public TeamMember SelectAMembersInATeamWithTeamDetails(int memberID, int teamID)
        {
            throw new NotImplementedException();
        }

        public Team SelectTeamByTeamID(int team_id)
        {
            Team selectedTeam = null;

            try
            {
                var teamQuery = from team in _teamList where team.TeamID.Equals(team_id) select team;
                selectedTeam = (Team)teamQuery.First(); // Should only return 1 result;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Team not found", ex);
            }

            return selectedTeam;
        }
    }
}
