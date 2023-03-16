/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Add a team to a tournament
/// </summary>
using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TournamentManager : ITournamentManager
    {

        private ITournamentAccessor _tournamentAccessor = null;

        public TournamentManager()
        {
            _tournamentAccessor = new TournamentAccessor();
        }
        public TournamentManager(ITournamentAccessor tournamentAccessor)
        {
            _tournamentAccessor = tournamentAccessor;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Add a team to a tournament
        /// </summary>
        public int AddTeamToTournament(TournamentTeam tournamentTeam)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _tournamentAccessor.AddTeamToTournament(tournamentTeam);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot add team to the tournament");
            }
            return rowsAffected;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Selects all tournaments
        /// </summary>
        public List<Tournament> GetTournaments()
        {
            List<Tournament> tournaments = null;

            try
            {
                tournaments = _tournamentAccessor.GetTournaments();
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot read Tournaments");
            }
            return tournaments;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select tournament by teamID
        /// </summary>
        public List<TournamentTeam> GetTournamentTeamByID(int tournament_id)
        {
            List<TournamentTeam> tournaments = null;

            try
            {
                tournaments = _tournamentAccessor.GetTournamentTeamByID(tournament_id);
            }
            catch (Exception)
            {
                throw new ApplicationException("Tournament not found");
            }
            return tournaments;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove team from a tournament
        /// </summary>
        public int RemoveTeamToTournament(TournamentTeam tournamentTeam)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _tournamentAccessor.RemoveTeamToTournament(tournamentTeam);
            }
            catch (Exception)
            {
                throw new ApplicationException("Remove failed");
            }
            return rowsAffected;
        }
    }
}
