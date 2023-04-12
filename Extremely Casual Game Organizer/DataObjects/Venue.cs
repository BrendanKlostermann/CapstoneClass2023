using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Venue
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string Parking { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
