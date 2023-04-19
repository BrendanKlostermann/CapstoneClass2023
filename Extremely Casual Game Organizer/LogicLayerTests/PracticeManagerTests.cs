using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerFakes;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace LogicLayer.Tests
{

    // ALL TESTS created by Nick Vroom
    // Remove,  Create,  Select All Practices

    [TestClass]
    public class PracticeManagerTest
    {
        private IPracticeManager _practiceManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _practiceManager = new PracticeManager(new PracticeAccessorFakes());
        }

        [TestMethod]
        public void RemovePracticeTestGood()
        {
            Practice testPractice = new Practice
            {
                PracticeID = 1000000,
                Location = "Test Location",
                TeamID = 1000,
                DateAndTime = new DateTime(2020, 08, 10),
                Description = "Test Description",
                ZIP = 50219
            };
            _practiceManager.CreatePractice(testPractice);
            int actualResult = _practiceManager.RemovePractice(testPractice);
            int expectedResult = 1;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemovePracticeTestBad()
        {
            Practice testPractice = new Practice
            {
                PracticeID = 1000000,
                Location = null,
                TeamID = 1000,
                DateAndTime = new DateTime(2020, 08, 10),
                Description = "Test Description",
                ZIP = 50219
            };
            _practiceManager.CreatePractice(testPractice);
            int actualResult = _practiceManager.RemovePractice(testPractice);
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CreatePracticeTestGood()
        {
            Practice testPractice = new Practice
            {
                PracticeID = 1000000,
                Location = "Test Location",
                TeamID = 1000,
                DateAndTime = new DateTime(2020, 08, 10),
                Description = "Test Description",
                ZIP = 50219
            };
            int actualResult = _practiceManager.CreatePractice(testPractice);
            int expectedResult = 2;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void CreatePracticeTestBad()
        {
            Practice testPractice = new Practice
            {
                PracticeID = 1000000,
                Location = "Test Location",
                TeamID = 1000,
                DateAndTime = new DateTime(2020, 08, 10),
                Description = null,
                ZIP = 50219
            };
            int actualResult = _practiceManager.CreatePractice(testPractice);
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void SelectPracticesTestGood()
        {
            List<Practice> _practices = null;
            _practices = _practiceManager.SelectPractices(1000);
            int actualResult = _practices.Count;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SelectPracticesTestBad()
        {
            List<Practice> _practices = null;
            _practices = _practiceManager.SelectPractices(100000);
            int actualResult = _practices.Count;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}