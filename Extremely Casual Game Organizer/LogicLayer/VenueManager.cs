using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class VenueManager : IVenueManager
    {
        IVenueAccessor _venueAccessor = null;
        public VenueManager()
        {
            _venueAccessor = new VenueAccessor();
        }
        public VenueManager(IVenueAccessor ga)
        {
            _venueAccessor = ga;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method inserts venue into venue table
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        public int AddVenue(Venue venue)
        {
            int result = 0;

            try
            {
                result = _venueAccessor.InsertVenue(venue);
                if (result == 0)
                {
                    throw new ApplicationException("Venue not added");
                }
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Error adding Venue", ex);
            }

            return result;
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method returns all venues
        /// </summary>
        /// <returns></returns>
        public List<Venue> RetrieveAllVenues()
        {
            List<Venue> venueList = null;

            try
            {
                venueList = _venueAccessor.SelectAllVenues();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error retreiving venue list", ex);
            }
            return venueList;
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/12/2023
        /// 
        /// Method returns zip code information
        /// </summary>
        public Dictionary<string, object> RetrieveZipCodeDetails(int zipcode)
        {
            Dictionary<string, object> zipcodeDetails = null;

            try
            {
                zipcodeDetails = _venueAccessor.SelectZipCodeDetails(zipcode);

                if (zipcodeDetails == null || zipcodeDetails.Count == 0)
                {
                    throw new ApplicationException("Invalid zipcode");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error retireving zipcode details", ex);
            }

            return zipcodeDetails;

        }
    }
}
