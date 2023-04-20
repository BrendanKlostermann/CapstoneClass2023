using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

//Created by Nick Vroom
namespace DataAccessLayerFakes
{
    public class PracticeAccessorFakes : IPracticeAccessor
    {
        List<Practice> _practices = null;
        public PracticeAccessorFakes()
        {
            _practices = new List<Practice>()
            {
                new Practice{
                    PracticeID = 10002,
                    TeamID = 1000,
                    Location = "Test Location1",
                    DateAndTime = new DateTime(2020, 08, 10),
                    Description = "Test Desc",
                    ZIP = 50219
                }
            };
        }
        public int CreatePracticeByTeamID(Practice practice) //practice_id is an identity
        {

            if (practice.Location != null && practice.DateAndTime != null && practice.Description != null)
            {
                _practices.Add(practice);
                return _practices.Count;
            }
            else
            {
                return 0;
            }
        }

        public int deletePracticeByID(Practice practiceID)
        {
            if(practiceID.Location != null && practiceID.DateAndTime != null && practiceID.Description != null)
            {
                _practices.Remove(practiceID);
                return _practices.Count;
            }
            else
            {
                return 0;
            }
        }

        public List<Practice> SelectAllPractices(int teamID)
        {
            List<Practice> practices = new List<Practice>();
            Practice fakePractice = _practices.Find(x => x.TeamID == teamID);
            practices.Add(fakePractice);
            return practices;
        }
    }
}
