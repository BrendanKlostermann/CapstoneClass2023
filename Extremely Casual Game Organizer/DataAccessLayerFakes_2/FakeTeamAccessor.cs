/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// DataFakes for Team
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{


    /// <summary>
    /// Heritier Otiom
    /// Created: 2023/01/31
    /// 
    /// Fake Team Accessor
    /// </summary>
    public class FakeTeamAccessor : ITeamAccessor
    {
        List<Team> _teamList = new List<Team>();
        List<TeamSport> _teamSports = new List<TeamSport>();
        List<TeamMemberAndSport> _teamMemberAndSport = new List<TeamMemberAndSport>();
        List<string> _sports = new List<string>();
        //private ITeamAccessor _teamAccessor = null;



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Constructor
        /// </summary>
        public FakeTeamAccessor()
        {
            //_teamAccessor = new TeamAccessor();

            _teamList.Add(new Team()
            {
                TeamID = 10001,
                Name = "Iowa Hawkeyes",
                Gender = true,
                SportID = 1001
            });

            _teamList.Add(new Team()
            {
                TeamID = 10002,
                Name = "Iowan Soccer",
                Gender = true,
                SportID = 1002
            });

            _teamList.Add(new Team()
            {
                TeamID = 10003,
                Name = "Muscantine Basketball",
                Gender = true,
                SportID = 1001
            });

            _sports.Add("Soccer");
            _sports.Add("Basketball");
            _sports.Add("Fooball");
            _sports.Add("Tennis");

            _teamSports.Add(new TeamSport()
            {
                Description = "Basketball",
                SportID = 1009,
                TeamID = 1001,
                Gender = true,
                Name = "Lakers"
            });

            _teamMemberAndSport.Add(new TeamMemberAndSport()
            {
                Description = "Sport",
                Gender = true,
                TeamID = 1001,
                SportName = "Basketball",
                Starter = true,
                MemberID = 1001,
                TeamName = "Lakers"
            });
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a team
        /// </summary>
        public int AddTeam(Team team)
        {
            if(team.Name!="" && team.Name != null)
            {
                _teamList.Add(team);
                return 1;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select all sport name
        /// </summary>
        public List<string> getSportName()
        {
            return _sports;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Team by Member_ID
        /// </summary>
        public List<TeamMemberAndSport> getTeamByMemberID(int member_id)
        {
            var teams = _teamMemberAndSport.Where(b => b.MemberID == member_id).ToList();

            if (teams == null)
            {
                throw new ApplicationException("Team not found.");
            }

            return teams;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Team by team_name
        /// </summary>
        public List<TeamSport> getTeamByTeamName(string name, int sport_id)
        {
            var teams = _teamSports.Where(b => b.Name == name || b.SportID == sport_id).ToList();

            if (teams == null)
            {
                throw new ApplicationException("Team not found.");
            }

            return teams;
        }
    }
}
