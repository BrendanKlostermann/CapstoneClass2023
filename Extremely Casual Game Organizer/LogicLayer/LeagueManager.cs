/// <LeagueManager>
/// Alex Korte & Elijah Morgan & Brendan Klostermann
/// Created: 2023/02/05 & 2023/02/28 & 2023/02/20
/// 
/// </summary>
/// This class Used to create the league manager,, getting a list of all
/// leagues, teams on leagues, and remove a team from a league
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class LeagueManager : ILeagueManager
    {
        private ILeagueAccessor _leagueAccessor = null;

        public LeagueManager()
        {
            _leagueAccessor = new LeagueAccessor();
        }

        public LeagueManager(ILeagueAccessor leagueAccessor)
        {
            _leagueAccessor = leagueAccessor;
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to get a list of teams in a specific league through leagueID
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public List<Team> GetAListOfTeamsByLeagueID(int leagueID)
        {
            try
            {
                List<Team> _returnedList = _leagueAccessor.SelectATeamByLeagueID(leagueID);
                if (_returnedList == null || _returnedList.Count == 0)
                {
                    throw new ArgumentException("There was no data to load");
                }
                else
                {
                    return _returnedList;
                }
            }
            catch (ApplicationException up)
            {
                throw new ApplicationException("Failed to populate list", up);
            }
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to get a list of all leagues (as objects)
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public List<League> GetListOfLeagues()
        {
            try
            {
                return _leagueAccessor.SelectAllLeagues();
            }
            catch (ApplicationException up)
            {
                throw new ApplicationException("List failed to populate", up);
            }
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/01/24
        /// 
        /// Actual summary of the class if needed.
        /// </summary>
        /// A method to remove a specific team from a specific league
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int RemoveATeamFromALeagueByTeamIDAndLeagueID(int teamID, int leagueID)
        {
            int results = 0;
            try
            {
                results = _leagueAccessor.RemoveATeamFromALeague(teamID, leagueID);
                if (results == 0)
                {
                    throw new ArgumentException("Invalid input error");
                }
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("Invalid input error", up);
            }
            catch (ApplicationException up)
            {
                throw up;
            }
            return results;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/26/02
        /// 
        /// Method is going to get a list of league objects from LeagueAccessor based on TeamID provided
        /// </summary>
        /// <param name="team_id"></param>
        /// Updated By: Jacob Lindauer
        /// Date: 2023/07/03
        /// 
        /// Removed the exception catching for null league list. Some teams will not be in any leagues when viewing the team details page.
        /// <returns></returns>
        public List<League> RetrieveLeagueListByTeamID(int team_id)
        {
            List<League> leagueList = null;

            try
            {
                leagueList = _leagueAccessor.SelectLeaguesByTeamID(team_id);
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Error retrieving League List", ex);
            }

            return leagueList;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Retrieves a list of active leagues.
        /// 
        /// <param name="active">a boolean set to true so that we can retrieve the active Leagues</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>All active Leagues</returns>
        public List<League> RetrieveLeagueByActiveStatus(bool active = true)
        {
            List<League> leagues = new List<League>();

            try
            {
                leagues = _leagueAccessor.SelectLeagueByActiveStatus(active);
            }
            catch (Exception)
            {
                throw;
            }

            return leagues;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects a League by a LeagueID.
        /// 
        /// <param name="leagueID">The LeagueID for the League we want</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>A league with a LeagueID matching the parameter's value</returns>
        public League RetrieveLeagueByLeagueID(int leagueID)
        {
            League league = new League();

            try
            {
                league = _leagueAccessor.SelectLeagueByLeagueID(leagueID);
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("Invalid league ID", up);
            }

            return league;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects all leagues.
        /// 
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>All Leagues</returns>
        public List<League> RetrieveAllLeagues()
        {
            List<League> leagues = new List<League>();

            try
            {
                leagues = _leagueAccessor.SelectAllLeagues();
            }
            catch (ApplicationException up)
            {
                throw new ApplicationException("Error, please try again later", up);
            }

            return leagues;
        }

        // Elijah M. is currently working on this
        ///// <summary>
        ///// Elijah
        ///// Created: 2023/02/28
        ///// 
        ///// Edits the registration status of the league.
        ///// 
        ///// <param name="oldLeague">A League that is passed to obtain the old data</param>
        ///// <param name="newLeague">A League that is passed input the new data</param>
        ///// <exception cref="SQLException">Data not found</exception>
        ///// <returns>An updated League</returns>
        //public bool EditLeagueRegistration(League oldLeague, League newleague)
        //{
        //    bool result = false;
        //    try
        //    {
        //        result = (1 == _leagueAccessor.UpdateLeagueRegistrationByLeagueIDByActive(oldLeague, newleague));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Edits a League.
        /// 
        /// <param name="oldLeague">A League that is passed to obtain the old data</param>
        /// <param name="newLeague">A League that is passed input the new data</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>An eddited League</returns>
        public bool EditLeague(League oldLeague, League newLeague)
        {
            bool result = false;
            try
            {
                result = (1 == _leagueAccessor.UpdateLeague(oldLeague, newLeague));
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("invalid ids", up);
            }
            // look into making an exception if dues is too high
            // look into exception if league name is too long
            // add an if statement for profanity filter
            return result;
        }

        // Elijah M. is currently working on this
        ///// <summary>
        ///// Elijah
        ///// Created: 2023/02/28
        ///// 
        ///// Edits the active status of the League.
        ///// 
        ///// <param name="active">a boolean set to true so that we can retrieve the active Leagues</param>
        ///// <exception cref="SQLException">Data not found</exception>
        ///// <returns>An updated League</returns>
        //public bool EditLeagueActiveStatus(bool active)
        //{
        //    bool result = false;
        //    try
        //    {
        //        //result = _leagueAccessor.UpdateLeagueActiveStatus(active);
        //        // make an if statement to check rows affected (1 row affected = true)
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}



        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method calls the LeagueAccessor method SelectListOfLeagues and returns it to the 
        /// presentation layer. 
        /// </summary>
        /// 
        /// <returns>List of League objects</returns>
        public List<League> RetrieveListOfLeagues()
        {
            List<League> leagueList = null;
            try
            {
                leagueList = _leagueAccessor.SelectAllLeagues();
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed loading League list", ex);
            }

            return leagueList;
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method calls the LeagueAccessor method SelectLeaguesForGrid and returns it to the 
        /// presentation layer to be used in the data grid view. 
        /// </summary>
        /// 
        /// <returns>List of LeagueGridVM objects</returns>
        public List<LeagueGridVM> RetrieveListOfLeaguesForGrid()
        {
            List<LeagueGridVM> leagueList = null;
            try
            {
                leagueList = _leagueAccessor.SelectLeaguesForGrid();
                foreach (var league in leagueList)
                {
                    if (league.GenderBool == true)
                    {
                        league.Gender = "Male";
                    }
                    else if (league.GenderBool == false)
                    {
                        league.Gender = "Female";
                    }
                }

            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed loading League list", ex);
            }

            return leagueList;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Selects a League with the associated SportID.
        /// 
        /// <param name="sportID">The SportID we are looking for from all Leagues</param>
        /// <exception cref="SQLException">Data not found</exception>
        /// <returns>An list of League's with the wanted SportID</returns>
        public League RetrieveLeagueBySportID(int sportID)
        {
            League leagues = new League();

            try
            {
                leagues = _leagueAccessor.SelectLeaguesBySportID(sportID);
            }
            catch (ArgumentException up)
            {
                throw new ArgumentException("Sport ID is invalid", up);
            }

            return leagues;
        }

        /// <summary>
        /// Rith
        /// method to call add a league method and pass results to the presentation layer
        /// </summary>
        public int AddLeague(League league)
        {
            int leagueID;
            try
            {

                leagueID = _leagueAccessor.AddALeague(league);
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed adding league", ex);
            }
            return leagueID;
        }

        /// <summary>
        /// Rith
        /// method to call the remove a league method and pass results to the presentation layer
        /// </summary>
        public bool RemoveLeague(int LeagueID)
        {
            bool success = false;
            if (1 == _leagueAccessor.RemoveALeague(LeagueID))
            {
                success = true;
            }
            return success;
        }

        /// <summary>
        /// Rith
        /// method to call the change registration method and pass results to the presentation layer
        /// </summary>
        public bool ChangeRegistration(int LeagueID, bool OpenOrClose)
        {
            bool success = false;
            try
            {

                if (1 == _leagueAccessor.ChangeLeagueRegistration(LeagueID, OpenOrClose))
                {
                    success = true;
                }
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("Failed changing registration", ex);
            }
            return success;
        }

        /// <summary>
        /// Rith
        /// method to call method that retrieves a list of leagues and passes the results to the presentation layer
        /// </summary>
        public List<League> RetrieveLeagueListByMemberID(int MemberID)
        {
            List<League> leagueList;
            try
            {
                leagueList = _leagueAccessor.SelectLeaguesByMemberID(MemberID);
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed loading League list", ex);
            }

            return leagueList;
        }

        /// <summary>
        /// Rith
        /// method to call update league method and pass results to the presentation layer
        /// </summary>
        public bool UpdateALeague(League league)
        {
            bool success = false;
            try
            {

                if (1 == _leagueAccessor.UpdateALeague(league))
                {
                    success = true;
                }
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed updating league", ex);
            }
            return success;
        }
        public List<LeagueRequest> RetrieveRequestsByLeagueID(int LeagueID)
        {
            List<LeagueRequest> requestList;
            try
            {
                requestList = _leagueAccessor.SelectRequestsByLeagueID(LeagueID);
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed loading League list", ex);
            }

            return requestList;
        }

        /// <summary>
        /// Elijah
        /// method to add league items into leagueVM
        /// </summary>
        public LeagueVM ConvertToLeagueVM(League league)
        {
            SportManager sportManager = new SportManager();

            LeagueVM leagueVM = new LeagueVM();

            leagueVM.LeagueID = league.LeagueID;
            leagueVM.SportID = league.SportID;
            leagueVM.LeagueDues = league.LeagueDues;
            leagueVM.Active = league.Active;
            leagueVM.MemberID = league.MemberID;
            leagueVM.Gender = league.Gender;
            leagueVM.Description = league.Description;
            leagueVM.Name = league.Name;
            leagueVM.MaxNumOfTeams = league.MaxNumOfTeams;

            leagueVM.SportName = sportManager.RetrieveSportBySportID(leagueVM.SportID);

            if (league.Gender == true)
            {
                leagueVM.genderAsText = "Male";
            }
            if (league.Gender == false)
            {
                leagueVM.genderAsText = "Female";
            }
            if (league.Gender == null)
            {
                leagueVM.genderAsText = "Undefined";
            }


            return leagueVM;
        }

        public bool UpdateRequestStatus(int RequestID, string Status)
        {
            bool success = false;
            try
            {

                if (1 == _leagueAccessor.UpdateRequestStatus(RequestID, Status))
                {
                    success = true;
                }
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed updating status", ex);
            }
            return success;
        }

        public bool AddRequest(LeagueRequest request)
        {

            bool success = false;
            try
            {

                if (1 == _leagueAccessor.AddARequest(request))
                {
                    success = true;
                }
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed adding request", ex);
            }
            return success;
        }

        public bool AddTeamToLeague(int TeamID, int LeagueID)
        {
            bool success = false;
            try
            {

                if (1 == _leagueAccessor.AddTeamToLeague(TeamID, LeagueID))
                {
                    success = true;
                }
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("Failed adding team to league", ex);
            }
            return success;
        }

        public List<Team> RetrieveNotRequestedTeams(int MemberID, int LeagueID)
        {
            List<Team> alreadyAccepted = GetAListOfTeamsByLeagueID(LeagueID);
            List<LeagueRequest> leagueRequests = RetrieveRequestsByLeagueID(LeagueID);
            TeamManager teamManager = new TeamManager();
            List<Team> _teams = teamManager.RetrieveTeamsByMemberID(MemberID);
            List<Team> teams = new List<Team>();
            bool requested = false;
            foreach (Team team in _teams)
            {
                foreach (LeagueRequest leagueRequest in leagueRequests)

                    if (team.TeamID == leagueRequest.TeamID)
                    {
                        requested = true;
                    }
                foreach (Team existingTeam in alreadyAccepted)
                {
                    if (team.TeamID == existingTeam.TeamID)
                    {
                        requested = true;
                    }
                }

                if (!requested)
                {
                    teams.Add(team);
                }
                requested = false;
            }
            return teams;
        }

        public List<LeagueRequestVM> RetrieveLeagueRequestVMs(List<LeagueRequest> LeagueRequests)
        {
            List<LeagueRequestVM> leagueRequestVMs = new List<LeagueRequestVM>();
            TeamManager teamManager = new TeamManager();
            foreach (LeagueRequest leagueRequest in LeagueRequests)
            {
                leagueRequestVMs.Add(new LeagueRequestVM { RequestID = leagueRequest.RequestID, Status = leagueRequest.Status, TeamName = teamManager.RetrieveTeamByTeamID(leagueRequest.LeagueID).TeamName });
            }
            return leagueRequestVMs;
        }
    }
}
