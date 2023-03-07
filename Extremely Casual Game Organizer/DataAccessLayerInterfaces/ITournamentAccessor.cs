/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the interface for the TournamentAccessor class.
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface ITournamentAccessor
    {
        List<Tournament> SelectAllTournaments();
        List<TournamentVM> SelectAllTournamentVMs();
    }
}
