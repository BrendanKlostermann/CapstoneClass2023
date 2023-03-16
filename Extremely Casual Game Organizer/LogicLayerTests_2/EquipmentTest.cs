/// <summary>
/// Heritier Otiom
/// Created: 2023/03/07
/// 
/// </summary>
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
    public class EquipmentTest
    {

        private IEquipmentManager _equipmentManager = null;
        [TestInitialize]
        public void TestSetup()
        {
            // In order for this line to work you must have a Logic Layer Accessor setup to allow a DataAccessor Interface.
            // This will allow the unit test to route to your data fakes instead the actual database.

            _equipmentManager = new EquipmentManager(new FakeEquipmentAccessor());
        }

        [TestMethod]
        public void AddTeamEquipmentGood()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                Description = "Jerseys",
                EquipmentID = 1002,
                Quantity = 25,
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 2;
            int actualResult = _equipmentManager.AddTeamEquipment(equipmentList);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddTeamEquipmentBad()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                Description = "Jerseys",
                EquipmentID = 1002,
                Quantity = -25, // Bad quantity
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 1;
            int actualResult = _equipmentManager.AddTeamEquipment(equipmentList);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void UpdateTeamEquipmentGood()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                Description = "Jerseys",
                EquipmentID = 100,
                Quantity = 25, // Bad quantity
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 1;
            int actualResult = _equipmentManager.UpdateTeamEquipment(equipmentList);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void UpdateTeamEquipmentBad()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                Description = "Jerseys",
                EquipmentID = 100,
                Quantity = -25, // Bad quantity
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 0;
            int actualResult = _equipmentManager.UpdateTeamEquipment(equipmentList);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeleteTeamEquipmentGood()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                Description = "Jerseys",
                EquipmentID = 100,
                Quantity = 25, 
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 1;
            int actualResult = _equipmentManager.DeleteTeamEquipment(equipmentList);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void DeleteTeamEquipmentBad()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                Description = "Jerseys",
                EquipmentID = 123, // Bad Equipment ID
                Quantity = 25, 
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 0;
            int actualResult = _equipmentManager.DeleteTeamEquipment(equipmentList);

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetEquipmentListsByTeamIDGood()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                EquipmentID = 100,
                Description = "Ball",
                Quantity = 25,
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 1;
            List<Equipment> equipmentLists =  _equipmentManager.RetrieveEquipmentListsByTeamID(equipmentList.TeamID, equipmentList.Description);
            
            int actualResult = 0;
            if (equipmentLists.Count > 0) actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetEquipmentListsByTeamIDBad()
        {
            //Arrange
            Equipment equipmentList = new Equipment()
            {
                EquipmentID = 100,
                Description = "Jerseys", // It's not in the equipment list,
                Quantity = 25,
                SportID = 1009,
                TeamID = 1001,
                SportName = "Basketball"
            };

            //Act
            const int expectedResult = 0;
            List<Equipment> equipmentLists = _equipmentManager.RetrieveEquipmentListsByTeamID(equipmentList.TeamID, equipmentList.Description);

            int actualResult = 0;
            if (equipmentLists.Count > 0) actualResult = 1;

            //Test
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
