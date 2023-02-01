/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// Test class to ensure functionality of the logic layer for Member Manager.
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayer;

namespace LogicLayerTests
{
    [TestClass]
    public class MemberManagerTest
    {
        private MemberManager _memberManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _memberManager = new MemberManager();
        }


        [TestMethod]
        public void TestEditUserToInactive()
        {
            int expectedResult = 1;
            int actualResult = _memberManager.EditUserToInactive(100000);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestEditUserToInactiveReturnNothingWithBadMemberID()
        {
            int expectedResult = 0;
            int actualyResult = _memberManager.EditUserToInactive(1);
            Assert.AreEqual(expectedResult, actualyResult);
        }



    }
}
