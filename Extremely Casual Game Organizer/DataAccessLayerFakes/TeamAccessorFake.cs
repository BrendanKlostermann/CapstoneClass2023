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

using System;
using System.Collections.Generic;
using System.Data;
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
        DataTable _gameTable = null; // For Game Details
        List<GameRoster> _gameRoster = null; // TeamID is stored in these objects
        List<Member> _members = null;
        List<TeamMember> _teamMembers = null;


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Fake Team Accessor
        /// </summary>
        List<TeamSport> _teamSports = new List<TeamSport>();
        List<TeamMemberAndSport> _teamMemberAndSport = new List<TeamMemberAndSport>();
        List<string> _sports = new List<string>();


        public TeamAccessorFake()
        {
            _teamList = new List<Team>
            {
                new Team()
                {
                    TeamID = 1000,
                    TeamName = "TheTestTeam1",
                    Gender = true,
                    SportID = 1001,
                    Description = "TheTestTeam1 Description",
                    MemberID = 100001
                },
                new Team()
                {
                    TeamID = 1001,
                    TeamName = "TheTestTeam2",
                    Gender = true,
                    SportID = 1001,
                    Description = "TheTestTeam2 Description"

                },
                new Team()
                {
                    TeamID = 1002,
                    TeamName = "TheTestTeam3",
                    Gender = false,
                    SportID = 1002,
                    Description = "TheTestTeam3 Description"
                },
                new Team()
                {
                    TeamID = 1003,
                    TeamName = "TheTestTeam4",
                    Gender = null,
                    SportID = 1002,
                    Description = "TheTestTeam4 Description"
                },
                new Team()
                {
                    TeamID = 1001,
                    TeamName = null, // Name can't be null
                    MemberID = 1230,
                    SportID = 1002,
                    Gender = true
                }

        };

            _members = new List<Member>()
            {
                new Member{
                    MemberID = 10000,
                    Email = "johns@company.com",
                    FirstName = "John",
                    FamilyName = "Smith",
                    Birthday =  new DateTime(2023, 01, 25),
                    PhoneNumber = "319-999-9999",
                    Gender = true,
                    Active = true,
                    Bio = "Member bio"
                },

                new Member{
                    MemberID = 10001,
                    Email = "Narkk@company.com",
                    FirstName = "Mark",
                    FamilyName = "Johnson",
                    Birthday =  new DateTime(2022, 02, 12),
                    PhoneNumber = "319-888-8888",
                    Gender = true,
                    Active = false,
                    Bio = "Another Member bio"
                },

                new Member{
                    MemberID = 10002,
                    Email = "KevinW@company.com",
                    FirstName = "Kevin",
                    FamilyName = "Waters",
                    Birthday =  new DateTime(2020, 08, 10),
                    PhoneNumber = "319-777-7777",
                    Gender = true,
                    Active = true,
                    Bio = "Yet Another Member bio"
                }
            };

            _teamMembers = new List<TeamMember>()
            {
                new TeamMember
                {
                    TeamID = 1000,
                    Description = "Test team member 1",
                    Starter = true,
                    MemberID = 10000
                },
                new TeamMember
                {
                    TeamID = 1000,
                    Description = "Test team member 2",
                    Starter = true,
                    MemberID = 10001
                },
                new TeamMember
                {
                    TeamID = 1000,
                    Description = "Test team member 3",
                    Starter = true,
                    MemberID = 10002
                },
                                new TeamMember
                {
                    TeamID = 1001,
                    Description = "Test team member 1",
                    Starter = true,
                    MemberID = 10000
                },
                new TeamMember
                {
                    TeamID = 1001,
                    Description = "Test team member 2",
                    Starter = true,
                    MemberID = 10001
                },
                new TeamMember
                {
                    TeamID = 1001,
                    Description = "Test team member 3",
                    Starter = true,
                    MemberID = 10002
                },                new TeamMember
                {
                    TeamID = 1002,
                    Description = "Test team member 1",
                    Starter = true,
                    MemberID = 10000
                },
                new TeamMember
                {
                    TeamID = 1002,
                    Description = "Test team member 2",
                    Starter = true,
                    MemberID = 10001
                },
                new TeamMember
                {
                    TeamID = 1003,
                    Description = "Test team member 3",
                    Starter = true,
                    MemberID = 10002
                },
                new TeamMember
                {
                    TeamID = 1003,
                    Description = "Test team member 1",
                    Starter = true,
                    MemberID = 10000
                },
                new TeamMember
                {
                    TeamID = 1003,
                    Description = "Test team member 2",
                    Starter = true,
                    MemberID = 10001
                },
                new TeamMember
                {
                    TeamID = 1003,
                    Description = "Test team member 3",
                    Starter = true,
                    MemberID = 10002
                }
            };



        // Create Game Table Data
        _gameTable = new DataTable();
            _gameTable.Columns.Add("game_id", typeof(int));
            _gameTable.Columns.Add("Teams", typeof(string));
            _gameTable.Columns.Add("Location", typeof(string));
            _gameTable.Columns.Add("Date and Time", typeof(DateTime));

            _gameTable.Rows.Add("1000", "TheMediocreTeam VS TheWorstTeam", "Kyles House", new DateTime(2023, 12, 01));
            _gameTable.Rows.Add("1001", "TheBestTeam VS TheOkayTeam ", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 12, 01));
            _gameTable.Rows.Add("1002", "TheBestTeam VS TheMediocreTeam ", "123 Lazy BLVD, Waterloo IA, 12345", new DateTime(2023, 02, 04));
            _gameTable.Rows.Add("1003", "TheBestTeam VS TheOkayTeam ", "1251 Main St SW, Cedar Rapids IA, 52401", new DateTime(2023, 06, 03));


            // Create GameRoster List
            _gameRoster = new List<GameRoster>()
            {
                new GameRoster
                { GameID = 1000, TeamID = 1001, MemberID = 100000, Description = "Home Team", GameRosterID = 10, TeamName = "TheFirstTeam", FirstName = "Adam", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1001, MemberID = 100001, Description = "Home Team", GameRosterID = 11, TeamName = "TheFirstTeam", FirstName = "Brad", LastName = "Smith" },
                 new GameRoster
                { GameID = 1000, TeamID = 1001, MemberID = 100002, Description = "Home Team", GameRosterID = 12, TeamName = "TheFirstTeam", FirstName = "Charles", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1002, MemberID = 100003, Description = "Away Team", GameRosterID = 13, TeamName = "TheSecondTeam", FirstName = "Dave", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1002, MemberID = 100004, Description = "Away Team", GameRosterID = 14, TeamName = "TheSecondTeam", FirstName = "Edward", LastName = "Smith" },
                new GameRoster
                { GameID = 1000, TeamID = 1002, MemberID = 100005, Description = "Away Team", GameRosterID = 15, TeamName = "TheSecondTeam", FirstName = "Frank", LastName = "Smith" },
            };

            /// <summary>
            /// Heritier Otiom
            /// Created: 2023/01/31
            /// 
            /// Fake Team Accessor
            /// </summary>
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

        public int AddMemberToTeamByTeamIDAndMemberID(int teamID, int memberID)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/07
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// this method will remove a member form a team member list where id matches id
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int DeleteAMemberFromATeamByMemberIdAndTeamID(int memberId, int teamId)
        {
            int countControl = 0;
            foreach (var teamMember in _teamMembers)
            {
                if(teamMember.MemberID == memberId && teamMember.TeamID == teamId)
                {
                    _teamMembers.Remove(teamMember);
                    countControl = 1;
                }
            }
            return countControl;
        }

        public int MoveAPlayerToBenchOrStarter(int memberID)
        {
            throw new NotImplementedException();
        }

        public int MoveAPlayerToBenchOrStarter(int teamID, bool starterOrBench, int memberID)
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
                selectedTeam = (Team)teamQuery.First(); // Should only return 1 result
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Team not found", ex);
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
            if(team.TeamName!="" && team.TeamName != null)
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

        public List<TeamMember> SelectTeamMembersByTeamID(int team_id)
        {
            try
            {
               var teamList = _teamMembers.Where(x => x.TeamID == team_id);

               return teamList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Garion Opiola
        /// Created: 2023/03/21
        /// 
        /// Remove own Team
        /// </summary>
        public int DeactivateOwnTeam(int teamID, int memberID)
        {
            for (int i = 0; i < _teamList.Count; i++)
            {
                if (teamID == _teamList[i].TeamID && memberID == _teamList[i].MemberID)
                {
                    _teamList[i].Active = false;
                    return 1;
                }
            }
            return 0;
        }

        public int SelectOwnerIDByTeamID(int team_id)
        {
            throw new NotImplementedException();
        }

        public List<TeamRequest> SelectRequestsByTeamID(int TeamID)
        {
            throw new NotImplementedException();
        }

        public int UpdateTeamRequestStatus(int RequestID, string Status)
        {
            throw new NotImplementedException();
        }

        public int AddATeamRequest(TeamRequest request)
        {
            throw new NotImplementedException();
        }

        public List<Team> SelectTeamsByMemberID(int memberID)
        {
            throw new NotImplementedException();
        }
    }
}
