using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using LogicLayerInterfaces;
using LogicLayer;
using DataObjects;
using DataAccessLayerFakes;
using System.Linq;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class VenueManagerTests
    {
        IVenueManager _venueManager = null;
        [TestInitialize]
        public void TestSetup()
        {
            _venueManager = new VenueManager(new VenueAccessorFake());
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestAddingVenue()
        {
            Venue newVenue = new Venue() { VenueID = 1004, VenueName = "NewestVenue", Parking = "", Description = "Good Venue", ZipCode = 52405, City = "", State = "" };
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _venueManager.AddVenue(newVenue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorAddingVenue()
        {
            Venue newVenue = null;
            const int expectedResult = 1;
            int actualResult = 0;

            actualResult = _venueManager.AddVenue(newVenue);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestRetrievingAllVenues()
        {
            const int expectedResult = 4;
            int actualResult = 0;

            actualResult = _venueManager.RetrieveAllVenues().Count();

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        public void TestRetrievingZipCodeDetails()
        {
            const int source = 52310;
            const string expectedResult = "Monticello";
            string actualResult = "";

            actualResult = _venueManager.RetrieveZipCodeDetails(source)["City"].ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        ///<summary>
        ///Created By: Jacob Lindauer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestErrorRetrievingZipCodeDetailsWithInvalidZipCode()
        {
            const int source = 0;
            const string expectedResult = "Monticello";
            string actualResult = "";

            actualResult = _venueManager.RetrieveZipCodeDetails(source)["City"].ToString();

        }
    }
}
