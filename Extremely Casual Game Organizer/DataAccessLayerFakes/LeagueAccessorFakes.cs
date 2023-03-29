using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{

    public class LeagueAccessorFakes : ILeagueAccessor
    {
        List<League> leagues = new List<League>();
        List<LeagueTeam> leagueTeams = new List<LeagueTeam>();
        Team team = null;
        Sport _sport = null;
        Member _member = null;

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Setting up all the fake data needed to test my methods for LeagueAccessor
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public LeagueAccessorFakes()
        {
            //Sport needed
            _sport = new Sport(1000, "Soccer");

            //member needed to make a league
            DateTime birthday = new DateTime(2023, 01, 25);
            _member = new Member(100000, "test@gmail.com", "Alex", "Korte"
                , birthday, "5159758769", true, true, "Test Profile");

            //league number one created
            //added league to a list
            League tempLeague = new League(1000, 1000, 25, true, 100000, false, "test League 1", "testing1");
            leagues.Add(tempLeague);

            //created a team
            team = new Team(1000, "Testing team 1", false, 1000);

            //creating the LeagueTeam data using league 1 and team 1
            LeagueTeam leagueTeamCombo = new LeagueTeam(tempLeague.LeagueID, team.TeamID);
            leagueTeams.Add(leagueTeamCombo);


            //league number 2 created and added to a list
            tempLeague = new League(1001, 1000, 26, true, 100000, false, "test League 2", "testing2");
            leagues.Add(tempLeague);

            //team created
            team = new Team(1001, "Testing team 2", false, 1000);

            //team created and added to league 2
            leagueTeamCombo = new LeagueTeam(tempLeague.LeagueID, team.TeamID);
            leagueTeams.Add(leagueTeamCombo);

            //league 3 made and added to a list
            tempLeague = new League(1002, 1000, 27, true, 100000, false, "test League 3", "testing3");
            leagues.Add(tempLeague);

            //Team 3 created
            team = new Team(1002, "Testing team 3", false, 1000);

            //added 3rd LeagueTeam data
            leagueTeamCombo = new LeagueTeam(tempLeague.LeagueID, team.TeamID);
            leagueTeams.Add(leagueTeamCombo);

            //added 4th team to league 3
            team = new Team(1003, "Testing team 3", false, 1000);

            //added 3rd LeagueTeam data
            leagueTeamCombo = new LeagueTeam(tempLeague.LeagueID, team.TeamID);
            leagueTeams.Add(leagueTeamCombo);

        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A  method that will remove a team from a specific league
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int RemoveATeamFromALeague(int teamID, int leagueID)
        {
            int countControl = 0;
            for(int i = 0; i < leagueTeams.Count; i++)
            {
                if(leagueTeams[i].TeamID == teamID && leagueTeams[i].LeagueID == leagueID)
                {
                    leagueTeams.Remove(leagueTeams[i]);
                    countControl++;
                }
            }
            return countControl;
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method that selects all leagues, and returns them as a list(objects)
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<League> SelectAllLeagues()
        {
            return leagues;
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A Method to get a list of teams(objects) by a league id
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Team> SelectATeamByLeagueID(int leagueID)
        {
            List<Team> teamsInLeague = new List<Team>();

            foreach (var team in leagueTeams)
            {
                if(team.LeagueID == leagueID)
                {
                    teamsInLeague.Add(new Team() { TeamID = team.TeamID });
                }
            }
            return teamsInLeague;
        }

        public List<League> SelectLeagueByActiveStatus(bool active)
        {
            throw new NotImplementedException();
        }

        public League SelectLeagueByLeagueID(int leagueID)
        {
            throw new NotImplementedException();
        }

        public League SelectLeaguesBySportID(int sportID)
        {
            throw new NotImplementedException();
        }

        public List<League> SelectLeaguesByTeamID(int team_id)
        {
            throw new NotImplementedException();
        }

        public List<LeagueGridVM> SelectLeaguesForGrid()
        {
            throw new NotImplementedException();
        }

        public List<League> SelectListOfLeagues()
        {
            throw new NotImplementedException();
        }

        public int UpdateLeague(League oldLeague, League newLeague)
        {
            throw new NotImplementedException();
        }
    }
}
