/// /// <summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Unit Testing for for MemberManager classes.
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using LogicLayer;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class MemberManagerTests
    {
        IMemberManager _memberManager = null;


        [TestInitialize]
        public void TestSetup()
        {
            _memberManager = new MemberManager(new MemberAccessorFake());
        }
        [TestMethod]
        public void TestResettingMemberPassword()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>

            const int source = 10000;
            const string newPassword = "password1";
            const string currentPassword = "password";
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.EditMemberPassword(source, currentPassword, newPassword);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPasswordMethodWithBadPasswordInput()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>

            const int source = 10000;
            const string newPassword = "password";
            const string currentPassword = "password";
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.EditMemberPassword(source, currentPassword, newPassword);

        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 02/10/2023
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPasswordResetWithBadEmailInput()
        {
            Member testMember = new Member();
            const string source = "bademail@email.com";
            const string expectedResult = "John";
            string actualResult = "";

            testMember = _memberManager.RetrieveMemberByEmail(source);
            actualResult = testMember.FirstName;

        }
        [TestMethod]
        public void TestRetreiveMemberByEmail()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
            Member testMember = new Member();
            const string source = "johns@company.com";
            const string expectedResult = "John";
            string actualResult = "";

            testMember = _memberManager.RetrieveMemberByEmail(source);
            actualResult = testMember.FirstName;

            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRetreiveMemberWithInvalidEmail()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
            Member testMember = new Member();
            const string source = "asdf";
            const string expectedResult = "John";
            string actualResult = "";

            testMember = _memberManager.RetrieveMemberByEmail(source);

        }
        /// <summary>
        /// Michael Haring
        /// Created: 2023/02/14
        /// 
        /// </summary>
        /// Test cases for Admin_010 - Reset Member Password
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        [TestMethod]
        public void TestResetToDefaultPassword()
        {
            // Arrange
            const int memberID = 10001;
            const bool expectedResult = true;
            bool actualResult;

            // Act
            var rowsAffected = _memberManager.ResetPasswordToDefault(memberID);
            actualResult = Convert.ToInt32(rowsAffected) > 0;

            // Assert
            // Needs to be changed to currently logged in member and grab their password
            Assert.AreEqual(expectedResult, actualResult);
            //var member = memberManager.GetMemberByID(memberID);
            //Assert.AreEqual(defaultPassword, member.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestResetToDefaultPasswordFailsWithBadID()
        {
            // Arrange
            const int memberID = 900001;  // bad id

            // Act
            var rowsAffected = _memberManager.ResetPasswordToDefault(memberID);

            // Assert - nothing to do, exception checking
        }



        /// <TestMemberManager>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// </summary>
        /// Test to check if manager class methods work
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        [TestMethod]
        public void TestGettingListOfAllMembersByMemberID()
        {
            List<int> _tempMemberID = new List<int>() { 10000, 10002 };

            List<Member> _tempMembers = _memberManager.RetrieveMembersByMemberID(_tempMemberID);
            int actual = 2;

            Assert.AreEqual(_tempMembers.Count, actual);
        }
        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// test for empty string
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHashSHA256ThrowsExceptionForEmptyString()
        {
            // Arrange
            const string source = "";

            // Act
            _memberManager.HashSha256(source);

            // Assert

        }

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// test for correct passwordHash
        /// </summary>

        [TestMethod]
        public void TestHashSHA256ReturnsCorrectHash()
        {
            // Arrange
            const string source = "newuser";
            const string expectedResult =
                "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e";
            string actualResult = "";

            // Act
            actualResult = _memberManager.HashSha256(source);

            // Assert
            Assert.AreEqual(expectedResult.ToUpper(), actualResult);
        }
        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// test with correct info 
        /// </summary>

        [TestMethod]
        public void TestLoginUserPassesWithCorrectEmailAndPassword()
        {
            // Arrange

            const string email = "KevinW@company.com";
            const string password = "newuser";
            int expectedResult = 10002;
            int actualResult = 0;

            // Act

            Member testUser = _memberManager.LoginMember(email, password);
            actualResult = testUser.MemberID;

            // Assert

            Assert.AreEqual(expectedResult, actualResult);

        }
        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// test for bad email
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestLoginUserFailsWithBadEmail()
        {
            // Arrange

            const string email = "bad-test@gmail.com";
            const string password = "newuser";

            // Act

            _memberManager.LoginMember(email, password);

        }
        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// test for bad password
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestLoginUserFailsWithBadPassword()
        {
            // Arrange

            const string email = "test1@gmail.com";
            const string password = "bad-newuser";

            // Act

            _memberManager.LoginMember(email, password);
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/04
        /// 
        /// Test retreiving member schedule events
        /// </summary>
        [TestMethod]
        public void TestRetrievingMemberSchedule()
        {
            const int source = 100000;
            const int expectedResult = 14;
            int actualResult = 0;

            actualResult = _memberManager.RetreiveMemberSchedule(source).Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAddingAvailabiltyEvent()
        {
            const int memberID = 100000;
            CalendarEvent addEvent = new CalendarEvent()
            {
                Type = "Availability"
                , EventID = 1004
                , Date = new DateTime(2023, 12, 1, 0, 0, 0).ToString() + "," + (new DateTime(2023, 12, 1, 11, 0, 0)).ToString()
            };
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.AddCalendarEvent(addEvent, memberID);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorWhenAddingCalendarEvent()
        {
            const int memberID = 100000;
            CalendarEvent addEvent = new CalendarEvent();
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.AddCalendarEvent(addEvent, memberID);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdatingCalendarEvent()
        {
            const int memberID = 100000;
            CalendarEvent updateEvent = new CalendarEvent()
            {
                Type = "Availability"
                , EventID = 1001
                , Date = new DateTime(2023, 12, 1, 0, 0, 0) + "," + new DateTime(2023, 12, 1, 11, 0, 0)
            };
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.UpdateCalendarEvent(updateEvent, memberID);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorWhenUpdatingCalendarEvent()
        {
            const int memberID = 100000;
            CalendarEvent updateEvent = new CalendarEvent()
            {
                Type = ""
                , EventID = 0
                , Date = new DateTime(2023, 12, 1, 0, 0, 0).ToString() + "," + (new DateTime(2023, 12, 1, 11, 0, 0)).ToString()
            };
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.UpdateCalendarEvent(updateEvent, memberID);
        }

        [TestMethod]
        public void TestRemovingCalendarEvent()
        {
            const int memberID = 100000;
            CalendarEvent updateEvent = new CalendarEvent()
            {
                Type = "Availability"
                , EventID = 1001
                , Date = new DateTime(2023, 12, 1, 0, 0, 0).ToString() + "," + (new DateTime(2023, 12, 1, 11, 0, 0)).ToString()
            };
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.RemoveCalendarEvent(updateEvent, memberID);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestExpectedErrorRemovingCalendarEvent()
        {
            const int memberID = 100000;
            CalendarEvent updateEvent = new CalendarEvent()
            {
                Type = ""
                , EventID = 0
                , Date = new DateTime(2023, 12, 1, 0, 0, 0).ToString() + "," + (new DateTime(2023, 12, 1, 11, 0, 0)).ToString()
            };
            const bool expectedResult = true;
            bool actualResult = false;

            actualResult = _memberManager.RemoveCalendarEvent(updateEvent, memberID);
        }

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void AddUserGood()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 10000,
                FirstName = "Heritier",
                FamilyName = "Otiom",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-3008",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "example@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            const int expectedResult = 1;
            int actualResult = _memberManager.AddUser(member);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void AddUserBad()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 123,
                FirstName = "Heritier",
                FamilyName = "Otiom",
                Birthday = new DateTime(2010, 02, 24), // Bad birthday (Adult Only. So you have to born after 2005)
                Bio = "",
                PhoneNumber = "319-519-3008",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "example@papa.com", // Bad email
                Active = true,
                Gender = true
            };

            //Act
            const int expectedResult = 0;
            int actualResult = _memberManager.AddUser(member);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void GetExistingUser()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 10000,
                FirstName = "John",
                FamilyName = "Smith",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = member.MemberID;
            List<Member> _members = _memberManager.GetMemberByName(member.FamilyName);

            int actualResult = _members[0].MemberID;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void GetBadUser()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 0,
                FirstName = "Heritier", // Unexisting user
                FamilyName = null,
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = member.MemberID;
            List<Member> _members = _memberManager.GetMemberByName(member.FamilyName);

            int actualResult = _members.Count;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void GetUserByIDGood()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 10000,
                FirstName = "Lebron",
                FamilyName = "James",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = member.MemberID;
            Member _member = _memberManager.GetMemberByMemberID(member.MemberID);

            int actualResult = _member.MemberID;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void GetUserByIDBad()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 001,
                FirstName = "Lebron",
                FamilyName = "James",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = 0;
            Member _member = _memberManager.GetMemberByMemberID(member.MemberID);

            int actualResult = 0;
            if (_member != null) actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void UpdateMemberProfileGood()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 10000,
                FirstName = "Lebron",
                FamilyName = "James",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = 1;

            int actualResult = _memberManager.UpdateProfilePicture(member);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void UpdateMemberProfileBad()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 001,
                FirstName = "Lebron",
                FamilyName = "James",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = _memberManager.UpdateProfilePicture(member);

            int actualResult = 0;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void UpdateMemberBioGood()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 10000,
                FirstName = "Lebron",
                FamilyName = "James",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = _memberManager.UpdateUserBio(member);

            int actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// </summary>
        [TestMethod]
        public void UpdateMemberBioBad()
        {
            //Arrange
            Member member = new Member()
            {
                MemberID = 001,
                FirstName = "Lebron",
                FamilyName = "James",
                Birthday = new DateTime(2000, 02, 24),
                Bio = "",
                PhoneNumber = "319-519-1234",
                ProfilePhoto = null,
                PasswordHash = "P@ssw0rd",
                Email = "lebron@gmail.com",
                Active = true,
                Gender = true
            };

            //Act
            int expectedResult = _memberManager.UpdateUserBio(member);

            int actualResult = 0;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
