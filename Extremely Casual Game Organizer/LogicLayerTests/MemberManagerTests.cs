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
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPasswordResetWithBadEmailInput()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/10/2023
            /// </summary>
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
            Assert.AreEqual(expectedResult, actualResult);
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

            const string email = "test1@gmail.com";
            const string password = "newuser";
            int expectedResult = 999999;
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
            const int expectedResult = 11;
            int actualResult = 0;

            actualResult = _memberManager.RetreiveMemberSchedule(source).Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
