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
/// Add a team to a tournament
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
        /// this method takes in a tournament object from the presentation layer and passes it to the 
        /// data access layer to add it to the database.
        public bool CreateTournament(Tournament tm)
        {
            try
            {
                if (_tournamentAccessor.InsertTournament(tm) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Error adding new tournament.", ex);
            }

        }
        /// <summary>
        /// Nick Vroom
        /// Created: 2023/04/10
        /// 
        /// </summary>
        /// this method calls to get a Tournament object by its ID
        /// then, it returns the object.
        public Tournament SelectTournament(int tournament_id)
        {
            Tournament requestTournament = new Tournament();
            try
            {
                requestTournament = _tournamentAccessor.SelectTournamentByID(tournament_id);
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Error viewing tournament", ae);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error viewing tournament", ex);
            }
            return requestTournament;
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
            

            try
            {
                tournaments = _tournamentAccessor.SelectAllTournamentVMs();

                foreach (TournamentVM tourn in tournaments)
                {
                    if (tourn.GenderBool == true)
                    {
                        tourn.Gender = "Male";
                    }
                    if (tourn.GenderBool == false)
                    {
                        tourn.Gender = "Female";
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Error retireving tournament list", ex);
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
            try
            {
                return _tournamentAccessor.SelectAllTournaments();
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Error retireving tournament list", ex);
            }
            
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// this method calls the UpdateTournament method in the accessor class
        /// it returns true or false depending on if the correct number of lines effected is returned.
        public bool EditTournament(int memberid, Tournament tm)
        {
            try
            {
                int count = _tournamentAccessor.UpdateTournament(memberid, tm);
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Tournament could not be updated.", ex);
            }


        } // end EditTournament


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// This method is used to deactivate a tournament in the database. returns true or false
        /// depending if the correct amount lines are changed.
        public bool DeleteTournament(int memberid, int tournamentID)
        {
            try
            {
                _tournamentAccessor = new TournamentAccessor();
                if (1 == _tournamentAccessor.DeactivateTournament(memberid, tournamentID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting tournament", ex);
            }
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
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method takes in an id number and will return a Tournament object that has the same id
        public Tournament RetrieveTournamentByTournamentID(int id)
        {
            try
            {
                return _tournamentAccessor.SelectTournamentByTournamentID(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding tournament", ex);
            }
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
        
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/20
        /// 
        /// Select tournament game
        /// </summary>
        public List<TournamentTeamGame> SelectTournamentTeamAndGame(int tournament_id)
        {
            List<TournamentTeamGame> tournaments = null;

            try
            {
                tournaments = _tournamentAccessor.SelectTournamentTeamAndGame(tournament_id);
            }
            catch (Exception)
            {
                throw new ApplicationException("Tournament not found");
            }
            return tournaments;
        }

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/20
        /// 
        /// Insert tournament game
        /// </summary>
        public int InsertTournamentGame(TournamentGenerateGames tournamentGenerateGames)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _tournamentAccessor.InsertTournamentGame(tournamentGenerateGames);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot add these games to the tournament");
            }
            return rowsAffected;
        }

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/20
        /// 
        /// Delete tournament game
        /// </summary>
        public int deleteTournamentGameGenerated(int tournament_id)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _tournamentAccessor.deleteTournamentGameGenerated(tournament_id);
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot add these games to the tournament");
            }
            return rowsAffected;
        }

    }
}
