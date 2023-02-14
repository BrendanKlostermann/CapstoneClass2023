using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class LeagueManager : ILeagueManager
    {
        private ILeagueAccessor _leagueAccessor = null;

        public LeagueManager()
        {
            _leagueAccessor = new LeagueAccessor();
        }

        public LeagueManager(ILeagueAccessor la)
        {
            _leagueAccessor = la;
        }

       
        public List<League> RetrieveListOfLeagues()
        {
            return _leagueAccessor.SelectListOfLeagues();

        }
    }
}
