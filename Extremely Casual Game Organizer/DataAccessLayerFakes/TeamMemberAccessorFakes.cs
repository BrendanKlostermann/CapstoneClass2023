/// <TeamMemberAccessorFakes>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This is the fake data to run unit tests on getting teamMembers and 
/// a list of members from the database
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class TeamMemberAccessorFakes : ITeamAccessor
    {
        //list of variables needed for the test
        //list of members
        List<Member> _members = null;
        //list of teamMembers, different from individual members
        List<TeamMember> _teamMember = null;
        //sport needs to be here to make a team
        Sport _sport;
        //a team for members to go on
        Team _team;


        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// making the TeamMemberAccessorFakes, setting up the fake data for my tests.
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public TeamMemberAccessorFakes()
        {
            //created 2 members here and added them to a list
            //needed to create a date time object to give them a bday
            _members = new List<Member>();
            DateTime birthday = new DateTime(2023, 01, 25);
            Member test1 = new Member(100000, "test@gmail.com", "Alex", "Korte"
                , birthday, "5159758769", true, true, "Test Profile");
            _members.Add(test1);


            DateTime birthday2 = new DateTime(1980, 11, 04);
            Member test2 = new Member(100001, "crackers@gmail.com", "Cravn", "Crackers"
                , birthday2, "5159758769", null, true, "Test Profile for Crackers");
            _members.Add(test2);



            //created sport
            _sport = new Sport();

            //created a team named "testing Team" 
            _team = new Team(1000, "Testing Team", false, 1000);



            //created teammembers by adding them to a team
            _teamMember = new List<TeamMember>();
            TeamMember temp = new TeamMember(1000, "test1", 100000);
            _teamMember.Add(temp);
            TeamMember temp2 = new TeamMember(1000, "test 2", 100001);
            _teamMember.Add(temp2);
        }

        public int AddMemberToTeamByTeamIDAndMemberID(int teamID, int memberID)
        {
            throw new NotImplementedException();
        }

        public int AddTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public int DeactivateOwnTeam(int teamID, int memberID)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// used a for loop and an if to get all members by their teamID and memberID
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int DeleteAMemberFromATeamByMemberIdAndTeamID(int member_id, int team_id)
        {
            int count = 0;
            for (int i = 0; i < _teamMember.Count; i++)
            {
                if (_teamMember[i].MemberID == member_id && _teamMember[i].TeamID == team_id)
                {
                    _teamMember.Remove(_teamMember[i]);
                    count++;
                }
            }
            return count;
        }

        public List<string> getSportName()
        {
            throw new NotImplementedException();
        }

        public List<TeamMemberAndSport> getTeamByMemberID(int member_id)
        {
            throw new NotImplementedException();
        }

        public List<TeamSport> getTeamByTeamName(string name, int sport_id)
        {
            throw new NotImplementedException();
        }

        public int MoveAPlayerToBenchOrStarter(int teamID, bool starterOrBench, int memberID)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// here we made 2 foreach loops.
        ///  1 to get all the members and add them to a list
        ///  2 to seperate all members who happen to be on a team with the same teamID
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Member> SelectAllmembersByTeamID(int team_id)
        {
            List<int> memberIDList = new List<int>();
            List<Member> membersOnTeamList = new List<Member>();
            foreach (var member in _teamMember)
            {
                if (member.TeamID == team_id)
                {
                    memberIDList.Add(member.MemberID);
                }
            }
            foreach (var memberOnTeam in memberIDList)
            {
                foreach (var memb in _members)
                {
                    if (memberOnTeam == memb.MemberID)
                    {
                        membersOnTeamList.Add(memb);
                    }
                }
            }

            return membersOnTeamList;
        }

        public List<Team> SelectAllTeams()
        {
            throw new NotImplementedException();
        }

        public TeamMember SelectAMembersInATeamWithTeamDetails(int memberID, int teamID)
        {
            throw new NotImplementedException();
        }

        public int SelectOwnerIDByTeamID(int team_id)
        {
            throw new NotImplementedException();
        }

        public Team SelectTeamByTeamID(int team_id)
        {
            throw new NotImplementedException();
        }

        public List<TeamMember> SelectTeamMembersByTeamID(int team_id)
        {
            throw new NotImplementedException();
        }
    }
}
