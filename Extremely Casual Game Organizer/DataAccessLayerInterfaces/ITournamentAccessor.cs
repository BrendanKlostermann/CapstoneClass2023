﻿/// Brendan Klostermann
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
        int UpdateTournament(int memberid, Tournament tm);
        Tournament SelectTournamentByTournamentID(int id);
        int DeactivateTournament(int memberid, int tournamentID);

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
        /// Nick Vroom
        /// Created: 2023/04/11
        /// 
        /// Select details about a specific tournament by tournamentID
        /// </summary>
        Tournament SelectTournamentByID(int tournament_id);

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/22
        /// 
        /// Activate tournament 
        /// </summary>
        int ActivateTournament(int memberid, int tournamentID);


        List<TournamentRequest> SelectRequestsByTournamentID(int TournamentID);

        int UpdateTournamentRequest(int RequestID, string Status);

        int AddATournamentRequest(TournamentRequest request);

        /// <summary>
        /// Toney Hale
        /// Created: 2023/04/11
        /// 
        /// changing tournament registation for open or closed
        /// </summary>
        int openOrCloseTournamentRegistration(int tournament_id, bool active);
    }
}
