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
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface ITournamentManager
    {
        List<Tournament> RetrieveAllTournamnets();
        List<TournamentVM> RetrieveAllTournamentVMs();

        bool CreateTournament(Tournament tm);
    }
}
