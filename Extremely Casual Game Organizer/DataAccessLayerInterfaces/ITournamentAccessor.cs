/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the interface for the TournamentAccessor class.
/// 
/// </summary>

/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
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
        int InsertTournament(Tournament tm);

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all tournaments
        /// </summary>
        List<Tournament> GetTournaments();


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all tournament team by tournamentID
        /// </summary>
        List<TournamentTeam> GetTournamentTeamByID(int tournament_id);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Insert a team to a tournament
        /// </summary>
        int AddTeamToTournament(TournamentTeam tournamentTeam);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove a team from a tournament
        /// </summary>
        int RemoveTeamToTournament(TournamentTeam tournamentTeam);
    }
}
