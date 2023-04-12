using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class VenueAccessorFake : IVenueAccessor
    {
        public List<Venue> SelectAllVenues()
        {
            throw new NotImplementedException();
        }
    }
}
