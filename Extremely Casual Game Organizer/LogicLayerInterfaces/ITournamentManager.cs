/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the interface for the TournamentManager class.
/// 
/// </summary>

/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
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

        bool EditTournament(int id, Tournament tm);

        Tournament RetrieveTournamentByTournamentID(int id);
        bool DeleteTournament(int id, int tournamentID);


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
