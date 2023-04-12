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
    }
}
