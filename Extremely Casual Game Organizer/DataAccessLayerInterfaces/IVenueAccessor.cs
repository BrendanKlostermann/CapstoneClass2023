﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IVenueAccessor
    {
        List<Venue> SelectAllVenues();
        int InsertVenue(Venue venue);
        Dictionary<string, object> SelectZipCodeDetails(int zipcode);
    }
}
