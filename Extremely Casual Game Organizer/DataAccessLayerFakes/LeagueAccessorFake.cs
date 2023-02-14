using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class LeagueAccessorFake : ILeagueAccessor
    {
        List<League> _leagues = null;
        public LeagueAccessorFake()
        {
            _leagues = new List<League>();
            League league1 = new League(100000, 100000, 12.34m, true, "test 1");
            _leagues.Add(league1);
            League league2 = new League(100001, 100001, 34.34m, false, "test 2");
            _leagues.Add(league2);
            League league3 = new League(100002, 100002, 132.34m, true, "test 3");
            _leagues.Add(league3);
        }

        public List<League> SelectListOfLeagues()
        {
            return _leagues;
        }
    }
}
