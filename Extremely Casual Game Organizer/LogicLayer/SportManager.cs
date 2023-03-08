using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DataAccessLayer;
using DataObjects;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class SportManager : ISportManager
    {
        ISportAccessor _sportAccessor;

        public SportManager()
        {
            _sportAccessor = new SportAccessor();
        }

        public SportManager(ISportAccessor sportAccessor)
        {
            _sportAccessor = sportAccessor;
        }

        public List<Sport> RetrieveAllSports()
        {
            List<Sport> sports = new List<Sport>();

            try
            {
                sports = _sportAccessor.SelectAllSports();
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("Failed loading sport list", ex);
            }

            return sports;
        }
    }
}
