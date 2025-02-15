/// <summary>
/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the manager for the Member data object.
/// It bridges the presentation to the database and does computations if needed.
/// 
/// </summary>
///
/// <remarks>
/// Updater Name: Jacob Lindauer
/// Updated: 2023/02/10
/// 
/// Added HashSha265 Method and EditMemberPassword
/// </remarks>

/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Member Manager
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using System.Security.Cryptography;
using DataObjects;
using DataAccessLayer;
using System.Data;

namespace LogicLayer
{
    public class MemberManager : IMemberManager
    {
        private IMemberAccessor _memberAccessor = null;
        private MemberAccessorFake _fakeMemberAccessor = null;

        public MemberManager()
        {
            _memberAccessor = new MemberAccessor();
        }
        public MemberManager(IMemberAccessor ma)
        {
            _memberAccessor = ma;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method calls the MemberAccessor method SetUserToInactive
        /// </summary>
        /// 
        /// <returns> int count of rows effected </returns>
        public int EditUserToInactive(int member_id)
        {
            try
            {
                return _memberAccessor.SetUserToInactive(member_id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Member not found.", ex);
            }
        }

        public bool EditMemberPassword(int member_id, string oldPassword, string newPassword)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created: 01/24/2023
            /// 
            /// Method takes old and new password text and converts it to SHA256 Hash format and passes that to accessor
            /// </summary>
            bool result = false;
            string currentPassword = HashSha256(oldPassword);
            string updatePassword = HashSha256(newPassword);

            try
            {
                if (currentPassword.Equals(updatePassword))
                {
                    throw new ArgumentException("New password cannot be the same as the old password.");
                }
                else
                {
                    result = _memberAccessor.UpdateMemberPassword(member_id, updatePassword, currentPassword);

                    if (!result)
                    {
                        throw new ApplicationException("Failed to update password!");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Password Mismatch", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Failed", ex);
            }
            return result;
        }

        public string HashSha256(string source)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created 01/24/2023
            /// 
            /// Method take input string and returns 256 Hash value.
            /// </summary>
            string result = "";

            if (source.Equals("") || source.Equals(null))
            {
                throw new ArgumentException("Source cannot be empty");
            }

            byte[] data;

            // Creating hash provider
            using (SHA256 sha256hasher = SHA256.Create())
            {
                // Hash input
                data = sha256hasher.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            var stringBuilder = new StringBuilder();

            // Convert array to string to match return type
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            result = stringBuilder.ToString();

            return result.ToUpper();
        }

        public Member RetrieveMemberByEmail(string email)
        {
            Member returnMember = null;

            try
            {
                returnMember = _memberAccessor.SelectMemberByEmail(email);

                if (returnMember == null)
                {
                    throw new ArgumentException("Invalid Email");
                }
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Error Finding Member", ae);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Finding Member", ex);
            }

            return returnMember;
        }

        public List<Member> SearchMemberByFirstAndLastName(string firstName, string lastName)
        {
            List<Member> results = null;

            try
            {
                //results = _memberAccessor.SelectMemberByMemberFullName(firstName, lastName);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Search Has Failed", ex);
            }

            return results;

        }



        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/28
        /// 
        /// </summary>
        /// Method for searching for members, passing a string
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public List<Member> SearchMemberByFirstName(string firstName)
        {
            List<Member> results = null;

            try
            {
                //results = _memberAccessor.SelectMemberByMemberFirstName(firstName);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Search Has Failed", ex);
            }

            return results;
        }

        /// <summary>
        /// Michael Haring
        /// Created: 2023/02/14
        /// 
        /// </summary>
        /// Logic to reset user password to default hash
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public bool ResetPasswordToDefault(int memberID)
        {
            string defaultHash = HashSha256("newuser");

            try
            {
                int results = _memberAccessor.UpdatePasswordHashToDefault(memberID, defaultHash);

                if (results == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error resetting member password", ex);
            }
        }


        /// <MemberManager>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// This is a method to get all members by id, (for getting coach names)
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public List<Member> RetrieveMembersByMemberID(List<int> memberID)
        {
            List<Member> _tempMemberList = new List<Member>();
            try
            {
                foreach (var memID in memberID)
                {
                    Member tempMember = _memberAccessor.SelectAUserByID(memID);
                    _tempMemberList.Add(tempMember);
                }
                return _tempMemberList;
            }
            catch (Exception up)
            {
                throw new ApplicationException("Unable to find any members", up);
            }
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
        public List<Member> GetAListOfMembersByTeamID(int teamID)
        {
            try
            {
                List<Member> _members = new List<Member>();
                _members = _memberAccessor.SelectAllMembersByTeamID(teamID);
                if (_members == null)
                {
                    throw new ArgumentException("No Team Members");
                }
                return _members;

            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("team is incorrect", up);
            }
            catch (ApplicationException down)
            {
                throw new ApplicationException("Error getting data", down);
            }
        }

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// log in for member
        /// </summary>

        public Member LoginMember(string email, string password)
        {
            Member member = null;
            try
            {
                String passwordHash = HashSha256(password);
                if (1 == _memberAccessor.AuthenticateMember(email, passwordHash))
                {

                    member = _memberAccessor.SelectMemberByEmail(email);

                    // Apply roles to member
                    member.Roles = _memberAccessor.SelectMemberRoles(member.MemberID);

                }
                else
                {
                    throw new ApplicationException("Bad Username or Password");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Login Failed", ex);
            }

            return member;
        }



        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/26
        /// searching for list of members by first name, last name or email
        /// </summary>
        /// 
        public List<Member> SearchingForMembersByNameAndOrEmail(String firstName, String lastName, String email)
        {
            List<Member> _searchedMembers = new List<Member>();
            try
            {
                _searchedMembers = _memberAccessor.SelectAListOfMembersByNameAndOrEmail(firstName, lastName, email);
            }
            catch (Exception up)
            {
                throw new ApplicationException("Error connecting to database", up);
            }
            return _searchedMembers;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/04/03
        /// 
        /// Method obtains all events for member by member's ID and puts them into a single list of Calendar Events
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public List<CalendarEvent> RetreiveMemberSchedule(int member_id)
        {
            List<CalendarEvent> events = null;
            try
            {
                DataTable practices = _memberAccessor.SelectPracticesByMemberID(member_id);
                DataTable games = _memberAccessor.SelectGamesByMemberID(member_id);
                DataTable tournamentGames = _memberAccessor.SelectTournamentGamesByMemberID(member_id);
                DataTable availabilityDates = _memberAccessor.SelectAvailabilityByMemberID(member_id);

                events = new List<CalendarEvent>();

                // Loop through each table and add to event list
                foreach (var availability in availabilityDates.AsEnumerable())
                {
                    CalendarEvent calEvent = new CalendarEvent();
                    calEvent.Type = availability[0].ToString();
                    calEvent.EventID = Convert.ToInt32(availability[1]);
                    calEvent.Date = Convert.ToDateTime(availability[2]).ToString("MM/dd/yyyy h:mm tt") + "," + Convert.ToDateTime(availability[3]).ToString("MM/dd/yyyy h:mm tt");
                    if (availability[4] == null)
                    {
                        calEvent.Description = null;
                    }
                    else
                    {
                        calEvent.Description = availability[4].ToString();
                    }

                    events.Add(calEvent);
                }
                foreach (var practice in practices.AsEnumerable())
                {
                    CalendarEvent practiceEvent = new CalendarEvent();
                    practiceEvent.Type = practice[0].ToString();
                    practiceEvent.EventID = Convert.ToInt32(practice[1]);
                    practiceEvent.Location = practice[2].ToString();
                    practiceEvent.Date = Convert.ToDateTime(practice[3]).ToString("MM/dd/yyyy h:mm tt");
                    if (practice[4].ToString() == "" || practice[4] == null)

                    {
                        practiceEvent.Description = null;
                    }
                    else
                    {
                        practiceEvent.Description = Convert.ToString(practice[4]);

                    }
                    events.Add(practiceEvent);
                }

                foreach (var tournamentGame in tournamentGames.AsEnumerable())
                {
                    CalendarEvent game = new CalendarEvent();
                    game.Type = tournamentGame[0].ToString();
                    game.EventID = Convert.ToInt32(tournamentGame[1]);
                    game.Location = tournamentGame[2].ToString();
                    game.Date = Convert.ToDateTime(tournamentGame[3]).ToString("MM/dd/yyyy h:mm tt");
                    game.Description = null;

                    events.Add(game);
                }

                foreach (var game in games.AsEnumerable())
                {
                    // Games can be added via tournamet games, validate game has not already been added
                    if (events.Where(x => x.EventID == (int)game[1]).Where(y => y.Type == "Tournament Game").Count() == 0)
                    {
                        CalendarEvent gameEvent = new CalendarEvent();
                        gameEvent.Type = game[0].ToString();
                        gameEvent.EventID = Convert.ToInt32(game[1]);
                        gameEvent.Location = game[2].ToString();
                        gameEvent.Date = Convert.ToDateTime(game[3]).ToString("MM/dd/yyyy h:mm tt");
                        gameEvent.Description = null;
                        events.Add(gameEvent);
                    }
                }


            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error retrieving events", ex);
            }

            return events;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Add a new user
        /// </summary>
        public int AddUser(Member member) // Add new user
        {
            int requestedUser = 0;

            try
            {
                requestedUser = _memberAccessor.AddUser(member);
            }
            catch (Exception)
            {
                requestedUser = 0; ;
            }
            return requestedUser;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get member by memberID
        /// </summary>
        public Member GetMemberByMemberID(int MemberID)
        {
            Member member = null;
            try
            {
                member = _memberAccessor.GetMemberByMemberID(MemberID);
            }
            catch (Exception)
            {
                member = null;
            }
            return member;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get member by name
        /// </summary>
        public List<Member> GetMemberByName(string name)
        {
            List<Member> members = null;
            try
            {
                members = _memberAccessor.GetMemberByFirstNameFamilyNameAndEmail(name);
            }
            catch (Exception)
            {
                members = null;
            }
            return members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all members
        /// </summary>
        public List<Member> GetMembers()
        {
            List<Member> members = null;
            try
            {
                members = _memberAccessor.GetListOfAllMembers();
            }
            catch (Exception)
            {
                members = null;
            }
            return members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update profile picture for a member
        /// </summary>
        public int UpdateProfilePicture(Member member)
        {
            int requestedUser = 0;

            try
            {
                requestedUser = _memberAccessor.UpdateProfilePicture(member);
            }
            catch (Exception)
            {
                requestedUser = 0;
            }
            return requestedUser;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update member Bio
        /// </summary>
        public int UpdateUserBio(Member member)
        {
            int requestedUser = 0;

            try
            {
                requestedUser = _memberAccessor.UpdateUserBio(member);
            }
            catch (Exception)
            {
                requestedUser = 0; ;
            }
            return requestedUser;
        }

        public bool AddCalendarEvent(CalendarEvent addEvent, int member_id)
        {
            bool result = false;
            try
            {
                result = _memberAccessor.InsertCalendarEvent(addEvent, member_id);
                if (result == false)
                {
                    throw new ApplicationException("Event not added");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding event", ex);
            }
            return result;
        }

        public bool UpdateCalendarEvent(CalendarEvent calendarEvent, int member_id)
        {
            bool result = false;

            try
            {
                result = _memberAccessor.UpdateCalendarEvent(calendarEvent, member_id);

                if (result == false)
                {
                    throw new ApplicationException("Event not updated");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Updating calendar event", ex);
            }

            return result;
        }

        public bool RemoveCalendarEvent(CalendarEvent calendarEvent, int member_id)
        {
            bool result = false;

            try
            {
                result = _memberAccessor.DeleteCalendarEvent(calendarEvent, member_id);

                if (result == false)
                {
                    throw new ApplicationException("Event not updated");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Removing calendar event", ex);
            }

            return result;
        }

        public List<Member> GetAListOfMembersByFirstNameLastNameOrEmail(string firstName, string lastName, string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Michael Haring
        /// Created: 2023/04/16
        /// 
        /// Selects all roles from the role table
        /// </summary>
        public List<string> RetrieveAllRoles()
        {
            List<string> roles = null;

            try
            {
                roles = _memberAccessor.SelectAllRoles();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Roles not found", ex);
            }

            return roles;
        }

        /// <summary>
        /// Michael Haring
        /// Created: 2023/04/17
        /// 
        /// Boolean used to find user
        /// </summary>
        public bool FindUser(string email)
        {
            try
            {
                return _memberAccessor.SelectMemberByEmail(email) != null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }

        /// <summary>
        /// Michael Haring
        /// Created: 2023/04/17
        /// 
        /// Authenticates User
        /// Created to be used for Identity Framework
        /// </summary>
        public Member AuthenticateUser(string email, string password)
        {
            Member result = null;

            // we need to hash the password
            var passwordHash = HashSha256(password);

            try
            {
                result = _memberAccessor.AuthenticateUser(email, passwordHash);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login failed!", ex);
            }

            return result;
        }
    }
}
