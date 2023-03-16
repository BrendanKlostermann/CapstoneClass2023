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

using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataObjects;
using DataAccessLayerFakes;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class MemberTest
    {
        IMemberManager _iMemberManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            // In order for this line to work you must have a Logic Layer Accessor setup to allow a DataAccessor Interface.
            // This will allow the unit test to route to your data fakes instead the actual database.

            _iMemberManager = new MemberManager(new FakeMemberAccessor());
        }

		[TestMethod]
		public void AddUserGood()
		{
			//Arrange
			Member member = new Member()
			{
				MemberID = 123,
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
			int actualResult = _iMemberManager.AddUser(member);

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}

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
			int actualResult = _iMemberManager.AddUser(member);

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void GetExistingUser()
		{
			//Arrange
			Member member = new Member()
			{
				MemberID = 123,
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
			List<Member> _members = _iMemberManager.GetMemberByName(member.FamilyName);

			int actualResult = _members[0].MemberID;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		public void GetBadUser()
		{
			//Arrange
			Member member = new Member()
			{
				MemberID = 0,
				FirstName = "Heritier",
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
			List<Member> _members = _iMemberManager.GetMemberByName(member.FamilyName);

			int actualResult = _members.Count;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}


		[TestMethod]
		public void GetUserByIDGood()
		{
			//Arrange
			Member member = new Member()
			{
				MemberID = 123,
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
			Member _member = _iMemberManager.GetMemberByMemberID(member.MemberID);

			int actualResult = _member.MemberID;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}

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
			Member _member = _iMemberManager.GetMemberByMemberID(member.MemberID);

			int actualResult = 0;
			if (_member!=null) actualResult = 1;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void UpdateMemberProfileGood()
		{
			//Arrange
			Member member = new Member()
			{
				MemberID = 123,
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
			int expectedResult =  _iMemberManager.UpdateProfilePicture(member);

			int actualResult = 1;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}

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
			int expectedResult = _iMemberManager.UpdateProfilePicture(member);

			int actualResult = 0;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void UpdateMemberBioGood()
		{
			//Arrange
			Member member = new Member()
			{
				MemberID = 123,
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
			int expectedResult = _iMemberManager.UpdateUserBio(member);

			int actualResult = 1;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}

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
			int expectedResult = _iMemberManager.UpdateUserBio(member);

			int actualResult = 0;

			//Test
			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}
