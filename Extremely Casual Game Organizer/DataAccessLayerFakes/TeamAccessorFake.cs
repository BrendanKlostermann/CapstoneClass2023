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
                    Description = "TheTestTeam1 Description"
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
    }
}
