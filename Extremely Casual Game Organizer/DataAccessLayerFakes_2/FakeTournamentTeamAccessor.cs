
/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Fake Tournament Team Accessor
/// </summary>
using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{

    public class FakeTournamentTeamAccessor : ITournamentAccessor
    {

        List<Tournament> _tournaments = new List<Tournament>();


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Constructor
        /// </summary>
        public FakeTournamentTeamAccessor()
        {
            _tournamentTeams.Add(new TournamentTeam()
            {
                TournamentID = 100,
                TeamID = 1001
            });

            _tournaments.Add(new Tournament()
            {
                Description = "This is a tournament of NBA PlayOffs",
                TournamentID = 100,
                MemberID = 1000,
                SportID = 1009,
                Active = true,
                Gender = true,
                Name = "NBA PlayOffs"
            });
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Insert team to a tournament
        /// </summary>
        public int AddTeamToTournament(TournamentTeam tournamentTeam)
        {
            if (tournamentTeam.TeamID>0 && tournamentTeam.TournamentID>0)
            {
                _tournamentTeams.Add(tournamentTeam);
            }

            return _tournamentTeams.Count;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select All tournaments
        /// </summary>
        public List<Tournament> GetTournaments()
        {
            return _tournaments;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Select tournament team by tournament_ID
        /// </summary>
        public List<TournamentTeam> GetTournamentTeamByID(int tournament_id)
        {
            var tournaments = _tournamentTeams.Where(b => b.TournamentID == tournament_id).ToList();

            if (tournaments == null)
            {
                throw new ApplicationException("Tournament not found.");
            }

            return tournaments;
        }



        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove a team from tournament
        /// </summary>
        public int RemoveTeamToTournament(TournamentTeam tournamentTeam)
        {
            var team = _tournamentTeams.Where(b => b.TournamentID == tournamentTeam.TournamentID
                && b.TeamID == tournamentTeam.TeamID).ToList();

            if (team == null || team.Count <= 0)
            {
                return 0;
            }

            int num = _tournamentTeams.FindIndex(b => b.TournamentID == tournamentTeam.TournamentID
                && b.TeamID == tournamentTeam.TeamID);
            _tournamentTeams.Remove(_tournamentTeams[num]);
            return 1;
        }
    }
}
