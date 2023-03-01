using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataObjects;
using DataAccessLayer;
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class SportManager : ISportManager
    {
        ISportAccessor _sportAccessor = null;

        public SportManager()
        {
            _sportAccessor = new SportAccessor();
        }
        public SportManager(ISportAccessor ta)
        {
            _sportAccessor = ta;
        }
        public List<Sport> RetrieveAllSports()
        {
            List<Sport> sportList = null;

            try
            {
                sportList = _sportAccessor.SelectAllSports();

                if (sportList == null)
                {
                    throw new ApplicationException("No sports found");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to retrieve sport list", ex);
            }

            return sportList;
        }
    }
}
