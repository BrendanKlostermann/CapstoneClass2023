/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the interface for the TournamentManager class.
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayer;
using DataObjects;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class TournamentManager : ITournamentManager
    {
        ITournamentAccessor _tournamentAccessor = null;
        TournamentAccessorFakes _tournamentAccessorFakes = null;

        public TournamentManager()
        {
            _tournamentAccessor = new TournamentAccessor();
        }

        public TournamentManager(ITournamentAccessor ta)
        {
            _tournamentAccessor = ta;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method calls to get a list of TournamentVM objects, checks to see which gender should be
        /// set for each item in the list and sets it accordingly, then returns the modified list.
        public List<TournamentVM> RetrieveAllTournamentVMs()
        {
            List<TournamentVM> tournaments = new List<TournamentVM>();
            tournaments = _tournamentAccessor.SelectAllTournamentVMs();
            foreach(TournamentVM tourn in tournaments)
            {
                if(tourn.GenderBool == true)
                {
                    tourn.Gender = "Male";
                }
                if(tourn.GenderBool == false)
                {
                    tourn.Gender = "Female";
                }
            }
            return tournaments;
        }
        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method calls the SelectAllTournaments method in the accessor and 
        /// returns a list of tournament objects
        public List<Tournament> RetrieveAllTournamnets()
        {
            return _tournamentAccessor.SelectAllTournaments();
        }
    
    }
}
