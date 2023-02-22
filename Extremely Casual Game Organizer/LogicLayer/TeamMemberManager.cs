
﻿/// <TeamMemberManager>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to create the TeamMember Manager.
/// it uses the ITeamMemberInterface to access methods
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerFakes;

namespace LogicLayer
{
    public class TeamMemberManager : ITeamMemberManager
    {
        private ITeamAccessor _teamAccessor = null;

        public TeamMemberManager()
        {
            _teamAccessor = new TeamAccessor();
        }

        public TeamMemberManager(ITeamAccessor ta)
        {
            _teamAccessor = ta;
        }

        ITeamMemberAccessor _teamMemberAccessor = null;
        public TeamMemberManager(ITeamMemberAccessor tma)
        {
            _teamMemberAccessor = tma;
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// This method will run through the stack to get a list of members on a team
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Member> GetAListOfAllMembersByTeamID(int teamID)
        {
            try
            {
                List<Member> _members = _teamAccessor.SelectAllmembersByTeamID(teamID);
                if (_members.Count == 0 || _members == null)
                {
                    throw new ArgumentException("No data found");
                }
                else
                {
                    return _members;
                }
            }catch(ArgumentException up)
            {
                throw new ArgumentException("team is incorrect", up);
            }catch(ApplicationException down)
            {
                throw new ApplicationException("Error getting data", down);
            }
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// This method will remove a player from a team, using teamID and memberID
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int RemoveAPlayerFromATeamByTeamIDAndMemberID(int teamID, int memberID)
        {
            int results = 0;
            try
            {
                results  = _teamAccessor.DeleteAMemberFromATeamByMemberIdAndTeamID(teamID, memberID);
                if (results == 0)
                {
                    throw new ArgumentException("You have selected an invalid member");
                }
            }catch(ApplicationException up)
            {
                throw new ApplicationException("Error loading data", up);
            }catch(ArgumentException up)
            {
                throw new ArgumentException("You have selected an invalid member", up);
            }
            return results;
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// Method to sort a list of members into starters or benched.  This will be able 
        /// to toggle and get one or the other for editing teams.
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Member> SortIntoStarters(List<Member> members, int teamID, bool active)
        {
            List<Member> _tempMembers = new List<Member>();
            List<TeamMember> _tempTeamMembers = new List<TeamMember>();
            List<int> _memberId = new List<int>();
            
            foreach (var member in members)//getting each member that is in a team
            {
                TeamMember _teamMember = _teamAccessor.SelectAMembersInATeamWithTeamDetails(member.MemberID, teamID);
                _tempTeamMembers.Add(_teamMember);
            }
            foreach (var starter in _tempTeamMembers)//get a list of each member who is a starter or benched
            {
                if(starter.Starter == active)
                {
                    _memberId.Add(starter.MemberID);
                }
            }
            foreach (var id in _memberId) // getting a list of members that are a starter or benched
            {
                foreach (var member in members)//using origional list passed in.
                {
                    if(member.MemberID == id)
                    {
                        _tempMembers.Add(member);
                    }
                }
            }
            return _tempMembers;//sending the filtered list of only starters or benched.
		}
        public int AddTeamMember(int team_id, int member_id, string description)
        {
            int result = 0;

            try
            {
                result = _teamMemberAccessor.InsertTeamMember(team_id, member_id, description);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Team Member Addition Failed", ex);
            }

            return result;
        }
    }
}
