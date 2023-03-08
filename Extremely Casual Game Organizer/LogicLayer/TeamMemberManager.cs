
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


        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/04
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method used to add a player to a team by memberID
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public int AddAPlayerToATeamByTeamIDAndMemberID(int teamID, int memberID)
        {
            int successful = _teamAccessor.AddMemberToTeamByTeamIDAndMemberID(teamID, memberID);
            return successful;
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/04
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        ///\A method used to move a player to a bench or back to starter
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public String MoveAPlayerToBenchOrStarter(int teamID, bool starter, int memberID)
        {
            string success = "";//make a string to return to the presentation layer

            try
            {
                int successful = _teamAccessor.MoveAPlayerToBenchOrStarter(teamID, starter, memberID);//get the int value of the change
                if (successful == 1)
                {
                    success = "Success";
                }
                else
                {
                    success = "Failed";
                }
            }catch(ArgumentException up)
            {
                throw new ArgumentException("Invalid Id", up);
            }
            return success;
        }
    }
}
