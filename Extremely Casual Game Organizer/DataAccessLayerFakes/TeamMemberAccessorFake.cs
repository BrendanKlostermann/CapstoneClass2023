using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class TeamMemberAccessorFake //: ITeamMemberAccessor
    {
        List<TeamMember> _teamMemberList = null;
        TeamRoles _teamRole = null;
        TeamRoleType _teamRoleType = null;
        List<Team> _teamList = null;
        List<Member> _memberList = null;
        public TeamMemberAccessorFake()
        {
            _teamMemberList = new List<TeamMember>();

            _teamRole = new TeamRoles();
            _teamRoleType = new TeamRoleType();

            List<TeamMember> _teamMember = null;
            List<Member> _member = null;
            List<Team> _team = null;
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

            _member = new List<Member>()
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

            _teamMember = new List<TeamMember>()
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

        }
        public int InsertTeamMember(int team_id, int member_id, string description)
        {
            int result = 0;

            try
            {
                TeamMember newMember = new TeamMember() { TeamID = team_id, MemberID = member_id, Description = description, Starter = false };

                _teamMemberList.Add(newMember);

                var resultCount = from member in _teamMemberList where member.TeamID.Equals(team_id) where member.MemberID.Equals(member_id) select member;
                result = resultCount.Count();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public int InsertTeamMember(int team_id, int member_id)
        {
            throw new NotImplementedException();
        }
    }
}
