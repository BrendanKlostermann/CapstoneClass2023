using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IVenueManager
    {
        List<Venue> RetrieveAllVenues();
        int AddVenue(Venue venue);
        Dictionary<string, object> RetrieveZipCodeDetails(int zipcode);
    }
}
