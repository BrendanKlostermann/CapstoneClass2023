using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using LogicLayer;

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
    }
}
