using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class VenueAccessorFake : IVenueAccessor
    {
        List<Venue> _venueList = null;
        DataTable _zipCodes = null;
        public VenueAccessorFake()
        {
            _venueList = new List<Venue>()
            {
                new Venue()
                {
                    VenueID = 1000, VenueName = "NewVenue", Parking = "", Description = "Best Venue", ZipCode = 52402, City = "", State = ""
                },
                new Venue()
                {
                    VenueID = 1001, VenueName = "MehVenue", Parking = "", Description = "Meh Venue", ZipCode = 52402, City = "", State = ""
                },
                new Venue()
                {
                    VenueID = 1002, VenueName = "OkVenue", Parking = "", Description = "Ok Venue", ZipCode = 52402, City = "", State = ""
                },
                  new Venue()
                {
                    VenueID = 1003, VenueName = "OldVenue", Parking = "", Description = "Old Venue", ZipCode = 52402, City = "", State = ""
                }
            };

            _zipCodes = new DataTable();
            _zipCodes.Columns.Add("ZipCode", typeof(int));
            _zipCodes.Columns.Add("City", typeof(string));
            _zipCodes.Columns.Add("State", typeof(string));

            _zipCodes.Rows.Add(52310, "Monticello", "IA");
            _zipCodes.Rows.Add(52402, "Cedar Rapids", "IA");
            _zipCodes.Rows.Add(52404, "Cedar Rapids", "IA");


        }
        public int InsertVenue(Venue venue)
        {
            int result = 0;

            int preCount = _venueList.Count;

            if (venue != null)
            {
                _venueList.Add(venue);
            }

            int postCount = _venueList.Count;

            result = postCount - preCount;

            return result;
        }

        public List<Venue> SelectAllVenues()
        {
            return _venueList;
        }

        public Dictionary<string, object> SelectZipCodeDetails(int zipcode)
        {
            Dictionary<string, object> returnList = new Dictionary<string, object>();

            foreach (var row in _zipCodes.AsEnumerable())
            {
                if ((int)row[0] == zipcode)
                {
                    returnList.Add("ZipCode", row[0]);
                    returnList.Add("City", row[1]);
                    returnList.Add("State", row[2]);
                }
            }

            return returnList;
        }
    }
}
