using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class SportAccessorFakes : ISportAccessor
    {
        private List<Sport> fakeSports = new List<Sport>();

        public SportAccessorFakes()
        {
            fakeSports.Add(new Sport()
            {
                SportId = 9999,
                Description = "Soccer"
            });
            fakeSports.Add(new Sport()
            {
                SportId = 1000,
                Description = "Football"
            });
            fakeSports.Add(new Sport()
            {
                SportId = 9998,
                Description = "Magic The Gathering"
            });
            fakeSports.Add(new Sport()
            {
                SportId = 9997,
                Description = "Baseball"
            });
        }

        public List<Sport> SelectAllSports()
        {
            return fakeSports;
        }
        
    }
}
