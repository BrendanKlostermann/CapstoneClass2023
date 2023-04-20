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
        /// Nick Vroom
        /// Created: 2023/04/10
        /// 
        /// Get a specific tournament
        /// </summary>
        Tournament SelectTournament(int tournament_id);


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

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Get all tournament team by tournamentID
        /// </summary>
        List<TournamentTeamGame> SelectTournamentTeamAndGame(int tournament_id);


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/22
        /// 
        /// Insert tournament games
        /// </summary>
        int InsertTournamentGame(TournamentGenerateGames tournamentGenerateGames);

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/22
        /// 
        /// delete tournament games that it's genereated so that we can generate new games
        /// </summary>
        int deleteTournamentGameGenerated(int tournament_id);

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/22
        /// 
        /// Activate tournament 
        /// </summary>
        bool ActivateTournament(int memberid, int tournamentID);
    }
}
