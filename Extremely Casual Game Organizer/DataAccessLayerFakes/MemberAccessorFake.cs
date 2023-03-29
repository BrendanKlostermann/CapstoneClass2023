/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Fake Data used in place of real Data Accessor for Member.
/// </summary>
///
/// <remarks>
/// Updater Name: Jacob Lindauer
/// Updated: 2023/02/10
/// 
/// Added method for UpdateMemberPassword
/// </remarks>

/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
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
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class MemberAccessorFake : IMemberAccessor
    {
        List<Member> _members = null;
        DataTable _passwords = null;
        DataTable _practices = null;
        DataTable _games = null;
        DataTable _tournamentGames = null;
        DataTable _availability = null;
        
        private List<string> passwordHashes = new List<string>();

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// 
        /// </summary>
        // private List<Member> members = new List<Member>();
        private DateTime adulttxtBirthday = new DateTime(2005, 01, 01);

        private List<Member> testingMembers = new List<Member>();

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This constructor creates a list of fake members.
        /// </summary>
        public MemberAccessorFake()
        {
            /// <summary> 
            /// Jacob LIndauer
            /// Created 2023/02/10
            /// 
            /// Constructor creates mock members for MemberManager Unit Testing. 
            /// </summary>
            _members = new List<Member>()
            {
                new Member{
                    MemberID = 10000,
                    Email = "johns@company.com",
                    FirstName = "John",
                    FamilyName = "Smith",
                    Birthday =  new DateTime(2003, 01, 25),
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
                    Birthday =  new DateTime(2002, 02, 12),
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
                    Birthday =  new DateTime(2000, 08, 10),
                    PhoneNumber = "319-777-7777",
                    Gender = true,
                    Active = true,
                    Bio = "Yet Another Member bio"
                }
            };
            // Create data table and setup columns, then add values to table.
            // This talbe is used to map password hashes to members since the members do not and should not have a password hash property
            _passwords = new DataTable();
            _passwords.Columns.Add("MemberID", typeof(int));
            _passwords.Columns.Add("PasswordHash", typeof(string));

            _passwords.Rows.Add(10000, "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");
            _passwords.Rows.Add(10001, "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e");
            _passwords.Rows.Add(10002, "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e");

            // Added By Jacob Lindauer. Need to create data fakes for schedule.
            _practices = new DataTable();
            _practices.Columns.Add("Type", typeof(string));
            _practices.Columns.Add("PracticeID", typeof(int));
            _practices.Columns.Add("Location", typeof(string));
            _practices.Columns.Add("date_and_time", typeof(DateTime));
            _practices.Columns.Add("Description", typeof(string));

            _practices.Rows.Add("Practice", 1000, "Basketball Court", new DateTime(2023, 03, 04), "Bring Shoes");
            _practices.Rows.Add("Practice", 1001, "YMCA", new DateTime(2023, 05, 12), "Running laps");
            _practices.Rows.Add("Practice", 1002, "Public Court", new DateTime(2023, 04, 03), "Evnet Prep");
            _practices.Rows.Add("Practice", 1003, "The Gym", new DateTime(2023, 03, 14), "Bring gloves");

            _games = new DataTable();
            _games.Columns.Add("Type", typeof(string));
            _games.Columns.Add("GameID", typeof(int));
            _games.Columns.Add("Location", typeof(string));
            _games.Columns.Add("date_and_time", typeof(DateTime));

            _games.Rows.Add("Game", 100, "Basketball Court", new DateTime(2023, 02, 15));
            _games.Rows.Add("Game", 1001, "YMCA", new DateTime(2023, 01, 12));
            _games.Rows.Add("Game", 1002, "Public Court", new DateTime(2023, 08, 03));
            _games.Rows.Add("Game", 1003, "The Gym", new DateTime(2023, 12, 14));

            _tournamentGames = new DataTable();
            _tournamentGames.Columns.Add("Type", typeof(string));
            _tournamentGames.Columns.Add("GameID", typeof(int));
            _tournamentGames.Columns.Add("Location", typeof(string));
            _tournamentGames.Columns.Add("date_and_time", typeof(DateTime));

            _tournamentGames.Rows.Add("Tournament", 1004, "Basketball Court", new DateTime(2023, 01, 12));
            _tournamentGames.Rows.Add("Tournament", 1005, "YMCA", new DateTime(2023, 08, 03));
            _tournamentGames.Rows.Add("Tournament", 1006, "The Gym", new DateTime(2023, 12, 14));

            _availability = new DataTable();
            _availability.Columns.Add("Type", typeof(string));
            _availability.Columns.Add("AvailabilityID", typeof(int));
            _availability.Columns.Add("StartAvailability", typeof(DateTime));
            _availability.Columns.Add("EndAvailability", typeof(DateTime));
            _availability.Columns.Add("Description", typeof(string));

            _availability.Rows.Add("Availability", 1001, new DateTime(2023, 12, 1, 0, 0, 0), new DateTime(2023, 12, 1, 11, 0, 0), "");
            _availability.Rows.Add("Availability", 1002, new DateTime(2023, 12, 3, 0, 0, 0), new DateTime(2023, 12, 5, 12, 0, 0), "On Vacation");
            _availability.Rows.Add("Availability", 1003, new DateTime(2023, 01, 1, 0, 0, 0), new DateTime(2023, 01, 5, 12, 30, 0), "");

        }



        public Member SelectAUserByID(int memberID)
        {
            foreach (Member mem in _members)
            {
                if (mem.MemberID == memberID)
                {
                    return mem;
                }
            }
            throw new ApplicationException("No member was found with ID: " + memberID);

        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method loops through the member list for a matching MemberID and if it finds one it
        /// sets the member's active state to false.
        /// </summary>
        /// <returns> int count of rows effected </returns>
        public int SetUserToInactive(int member_id)
        {
            int count = 0;
            foreach (Member mem in _members)
            {
                if (mem.MemberID == member_id)
                {
                    mem.Active = false;
                    count++;
                }
            }
            return count;
        }




        public List<Member> SelectMemberByMemberFirstName(string firstName)
        {
            List<Member> results = new List<Member>();

            try
            {
                var memberSearch = from user in _members where user.FirstName.Equals(firstName) select new Member { FirstName = user.FirstName, FamilyName = user.FamilyName, MemberID = user.MemberID };

                results = memberSearch.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return results;
        }

        public List<Member> SelectMemberByMemberFullName(string firstName, string lastName)
        {
            List<Member> results = new List<Member>();

            try
            {
                var memberSearch = from user in _members where user.FirstName.Equals(firstName) where user.FamilyName.Equals(lastName) select new Member { FirstName = user.FirstName, FamilyName = user.FamilyName, MemberID = user.MemberID };

                results = memberSearch.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return results;
        }

        public bool UpdateMemberPassword(int member_id, string password, string oldPassword)
        {
            /// <summary>
            /// Jacob Lindauer
            /// Created 01/24/2022
            /// 
            /// Accessor fake for unit testing resetting the password.
            /// Method to Update Passord should take in both old and new password. Verify memberID and that old input password = old password
            /// </summary>
            /// <returns>
            /// Updated by: Jacob Lindauer
            /// Date: 2023/02/23
            /// 
            /// Updated method to not use the PasswordHash property from the Member data object. This property needed to be removed.
            /// Created the data table above to store password hashes and setup the Linq query to obtain password hash based on provided memberID and reset the password
            /// if given old passwordHash is the same as hash in data table. This should mimic what the database is doing. 
            /// </returns>
            /// 
            bool result = false;

            try
            {
                int memberID = member_id;
                string newPassword = password;
                string currentPassword = oldPassword;

                foreach (Member member in _members)
                {
                    var getPassword = from row in _passwords.AsEnumerable() where row["MemberID"].Equals(member.MemberID) select row;
                    var selectedPassword = getPassword.First(); // Should only return 1 result.
                    if (member.MemberID == memberID && currentPassword == selectedPassword["PasswordHash"].ToString())
                    {
                        _passwords.Rows.RemoveAt(_passwords.Rows.IndexOf(selectedPassword)); // I do not know how to update Data Table entries so remove and re-add will work fine for this test.
                        _passwords.Rows.Add(memberID, newPassword);

                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
        /// <summary>
        /// Michael Haring
        /// Created: 2023/02/14
        /// 
        /// </summary>
        /// Fake data to test updating member password hash to default
        ///
        /// <remarks>
        /// Updater Name: Jacob Lindauer
        /// Updated: 2023/02/23
        /// 
        /// Applied my method I created above for updating member password. Changed some things to make it work.
        /// This method previously was trying to apply values to Member PasswordHash property that we removed.
        /// This resolved those issues. 
        /// </remarks>
        public int UpdatePasswordHashToDefault(int memberID, string passwordHash)
        {
            int rows = 0;
            var member = _members.Where(b => b.MemberID == memberID).First();

            if (member == null)
            {
                // employee not found
                throw new ApplicationException("Bad member id.");
            }


            foreach (Member resetMember in _members)
            {
                var getPassword = from row in _passwords.AsEnumerable() where row["MemberID"].Equals(member.MemberID) select row;
                var selectedPassword = getPassword.First(); // Should only return 1 result.
                if (resetMember.MemberID == memberID)
                {
                    _passwords.Rows.RemoveAt(_passwords.Rows.IndexOf(selectedPassword)); // I do not know how to update Data Table entries so remove and re-add will work fine for this test.
                    _passwords.Rows.Add(memberID, passwordHash);

                    rows = 1;
                }
            }
            return rows;
        }


        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// fakes for authenticating a member
        /// </summary>
        public int AuthenticateMember(string email, string passwordHash)
        {
            int result = 0;

            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].Email == email && passwordHashes[i] == passwordHash)
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// Fakes for selecting a member
        /// </summary>

        public Member SelectMemberByEmail(string email)
        {
            Member member = null;

            foreach (var fakeMember in _members)
            {
                if (fakeMember.Email == email)
                {
                   member = fakeMember;
                    break;
                }
            }

            if (member == null)
            {
                throw new ApplicationException("User not found.");
            }
            return member;
        }

        public List<string> SelectRolesByMemberID(int memberID)
        {
            throw new NotImplementedException();
        }


        /// <MemberAccessor>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// This is a method to test selecting all members by  member id
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public List<Member> SelectAllMembersByMemberID(List<int> memberID)
        {
            List<Member> _tempList = new List<Member>();
            for(int i = 0; i < memberID.Count; ++i)//list of ints
            {
                for(int j = 0; j < _members.Count; j++)//list of teams (or database)
                {
                    if(_members[j].MemberID == memberID[i])//add member to temp list
                    {
                        _tempList.Add(_members[j]);
                    }
                }
            }
            return _tempList;//return temp list
        }
        public List<Member> SelectAllMembersByTeamID(int memberID)
        {
            throw new NotImplementedException();
        }

        public List<Member> SelectAListOfMembersByNameAndOrEmail(string firstName, string lastName, string email)
        {
            throw new NotImplementedException();
		}
		
		
        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/03
        /// 
        /// Returns practice list
        public DataTable SelectPracticesByMemberID(int member_id)
        {
            return _practices;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/03
        /// 
        /// Returns Game list
        public DataTable SelectGamesByMemberID(int member_id)
        {
            return _games;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/03
        /// 
        /// Returns Tournament Game list
        public DataTable SelectTournamentGamesByMemberID(int member_id)
        {
            return _tournamentGames;
        }

        
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Create a user
        /// </summary>
        public int AddUser(Member member)
        {
            try
            {
                if (member.Email == null || member.Email == ""
                    || member.Email.Length < 6 || !(member.Email.Contains("@"))
                    || !(member.Email.Contains("@"))
                    || member.FirstName == null || member.FirstName == ""
                    || member.FamilyName == "" || member.FirstName == ""
                    || member.Birthday.Year > adulttxtBirthday.Year
                    || member.PhoneNumber.Length < 10
                   )
                {
                    return 0;
                }
                else
                {
                    _members.Add(member);
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select all members
        /// </summary>
        public List<Member> GetListOfAllMembers()
        {
            return _members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Member either by first name, family name or email
        /// </summary>
        public List<Member> GetMemberByFirstNameFamilyNameAndEmail(string name)
        {
            var members = _members.Where(b => b.FirstName == name ||
                                        b.FamilyName== name ||
                                        b.Email == name).ToList();
            if (members == null)
            {
                throw new ApplicationException("Member not found.");
            }
            return members;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select Member by member_ID
        /// </summary>
        public Member GetMemberByMemberID(int MemberID)
        {
            var member = _members.Where(b => b.MemberID == MemberID).ToList();

            if (member == null)
            {
                throw new ApplicationException("Member not found");
            }
            int num = _members.FindIndex(b => b.MemberID == MemberID);
            
            return _members[num];
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update profile picture of a member
        /// </summary>
        public int UpdateProfilePicture(Member _member)
        {
            var member = _members.Where(b => b.MemberID == _member.MemberID).ToList();

            if (member == null)
            {
                throw new ApplicationException("Update Failed.");
            }

            int num = _members.FindIndex(b => b.MemberID == _member.MemberID);

            _members[num].ProfilePhoto = _member.ProfilePhoto;


            return 1;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Update bio of a member
        /// </summary>
        public int UpdateUserBio(Member _member)
        {
            var member = _members.Where(b => b.MemberID == _member.MemberID).ToList();

            if (member == null)
            {
                throw new ApplicationException("Update Failed.");
            }

            int num = _members.FindIndex(b => b.MemberID == _member.MemberID);

            _members[num].Bio = _member.Bio;


            return 1;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/03
        /// 
        /// Returns Availability list
        public DataTable SelectAvailabilityByMemberID(int member_id)
        {
            return _availability;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/03
        /// 
        /// Inserts into data fake table depending on the CalendarEvent Type being inserted
        public bool InsertCalendarEvent(CalendarEvent insertEvent, int member_id)
        {

            if (insertEvent.Type == "Availability")
            {
                int preCount = _availability.Rows.Count;

                string[] dates = insertEvent.Date.Split(',');
                _availability.Rows.Add(insertEvent.Type, insertEvent.EventID, dates[0], dates[1]);

                int postCount = _availability.Rows.Count;

                int count = postCount - preCount;

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            if (insertEvent.Type == "Tournament Game")
            {
                int preCount = _tournamentGames.Rows.Count;

                _tournamentGames.Rows.Add(insertEvent.Type, insertEvent.EventID, insertEvent.Location, insertEvent.Date);

                int postCount = _tournamentGames.Rows.Count;

                int count = postCount - preCount;

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (insertEvent.Type == "Game")
            {
                int preCount = _games.Rows.Count;

                _games.Rows.Add(insertEvent.Type, insertEvent.EventID, insertEvent.Location, insertEvent.Date);

                int postCount = _games.Rows.Count;

                int count = postCount - preCount;

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (insertEvent.Type == "Practice")
            {
                int preCount = _practices.Rows.Count;

                _practices.Rows.Add(insertEvent.Type, insertEvent.EventID, insertEvent.Location, insertEvent.Date);

                int postCount = _practices.Rows.Count;

                int count = postCount - preCount;

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/03
        /// 
        /// Updates data fake row depending on the CalendarEvent Type being Updated
        public bool UpdateCalendarEvent(CalendarEvent updateEvent, int member_id)
        {
            bool result = false;

            if (updateEvent.Type == "Availability")
            {
                // parse dates
                string[] dates = updateEvent.Date.Split(',');

                int preCount = _availability.Rows.Count;

                var findRow = from row in _availability.AsEnumerable()
                              where row[0].Equals(updateEvent.Type)
                              where row[1].Equals(updateEvent.EventID)
                              select row;

                // Remove old row
                _availability.Rows.RemoveAt(_availability.Rows.IndexOf(findRow.First()));
                int postCount = _availability.Rows.Count;

                int count = preCount - postCount;

                if (count == 1)
                {
                    // Add new row
                    _availability.Rows.Add(updateEvent.Type, updateEvent.EventID, dates[0], dates[1]);
                    return true;
                }
            }

            return result;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/03
        /// 
        /// deletes data fake row depending on the CalendarEvent Type being removed
        public bool DeleteCalendarEvent(CalendarEvent deleteEvent, int member_id)
        {
            bool result = false;

            if (deleteEvent.Type == "Availability")
            {
                // parse dates
                string[] dates = deleteEvent.Date.Split(',');

                int preCount = _availability.Rows.Count;

                var findRow = from row in _availability.AsEnumerable()
                              where row[0].Equals(deleteEvent.Type)
                              where row[1].Equals(deleteEvent.EventID)
                              select row;

                _availability.Rows.Remove(findRow.First());

                int postCount = _availability.Rows.Count;

                int count = preCount - postCount;

                if (count == 1)
                {
                    return true;
                }
            }

            return result;
        }
    }
}
