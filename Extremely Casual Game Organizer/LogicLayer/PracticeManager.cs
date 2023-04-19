using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataObjects;

namespace LogicLayer
{
    public class PracticeManager : IPracticeManager
    {
        private IPracticeAccessor _practiceAccessor = null;

        public PracticeManager()
        {
            _practiceAccessor = new PracticeAccessor();
        }

        public PracticeManager(IPracticeAccessor pa)
        {
            _practiceAccessor = pa;
        }
        public int CreatePractice(Practice practice)
        {
            int requestPractice = 0;
            try
            {
                requestPractice = _practiceAccessor.CreatePracticeByTeamID(practice);
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Error Creating Practice", ae);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Creating Practice", ex);
            }
            return requestPractice;
        }

        public int RemovePractice(Practice practice)
        {
            int requestPractice = 0;

            try
            {
                requestPractice = _practiceAccessor.deletePracticeByID(practice);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot remove the practice");
            }
            return requestPractice;
        }

        public List<Practice> SelectPractices(int teamID)
        {
            List<Practice> _practices = null;
            try
            {
                //_practiceAccessor = new PracticeAccessor();
                _practices = _practiceAccessor.SelectAllPractices(teamID);
                return _practices;
            }
            catch (ApplicationException up)
            {
                throw new ApplicationException("No practices in the system", up);
            }
        }
    }
}
