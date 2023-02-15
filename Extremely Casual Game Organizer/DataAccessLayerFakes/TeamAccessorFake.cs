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
