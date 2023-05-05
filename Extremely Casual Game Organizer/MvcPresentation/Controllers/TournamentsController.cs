using DataObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class TournamentsController : Controller
    {
        TournamentManager tournamentManager = new TournamentManager();
        TeamManager teamManager = new TeamManager();
        private List<Tournament> tournaments = null;
        private List<TournamentTeam> tournamentTeams = null;
        private List<TournamentTeamGame> tournamentGames = null;
        private List<Team> tournamentTeamname = new List<Team>();
        private List<TeamSport> teams = new List<TeamSport>();
        private MemberManager _memberManager = new MemberManager();
        private List<TournamentGenerateGames> games = new List<TournamentGenerateGames>();

        List<string> sports = new List<string>();
        List<int> sportIds = new List<int>();
        int memberID = 0;

        Tournament tournament = new Tournament();

        // GET: Tournament
        public ActionResult AllTournaments()
        {
            try
            {
                tournaments = tournamentManager.GetTournaments();
            }catch(Exception ex)
            {
                ViewBag.Message = ex;
            }

            return View(tournaments);
        }

        // GET: Tournament
        public ActionResult MemberTournaments()
        {
            try
            {
                memberID = GetUserID(User.Identity.Name);
                tournaments = tournamentManager.GetTournaments();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
            }
            ViewBag.Me = memberID;
            return View(tournaments);
        }
        

        // GET: Tournament Detail
        public ActionResult Details(int id, int? type, int? error)
        {
            try
            {

                memberID = GetUserID(User.Identity.Name);
                getSports();
                ViewBag.sports = sports;
                tournaments = tournamentManager.GetTournaments();
                tournament = tournaments.Where(b => b.TournamentID == id).First();
                tournamentTeams = tournamentManager.GetTournamentTeamByID(id);
                tournamentGames = tournamentManager.SelectTournamentTeamAndGame(id);

                getTournamentTeamName(tournamentTeams);
                getTeamGame(tournamentGames);

                ViewBag.TournamentTeams = tournamentTeamname;
                ViewBag.TournamentGames = games;
                ViewBag.NbreTeam = tournamentTeams.Count;
                ViewBag.NbreGame = tournamentGames.Count/2;
                ViewBag.Type = type;

                ViewBag.TeamError = (string)TempData["TeamError"];
                
                ViewBag.TeamError = TempData["TeamError"];

                ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userManager.FindById(User.Identity.GetUserId());
                if(user != null){
                    if (user.MemberID != tournament.MemberID)
                    {
                        ViewBag.NotOwner = "hidden";
                    }
                    else
                    {
                        ViewBag.IsOwner = "hidden";
                    }
                }
                else
                {
                    ViewBag.NotOwner = "hidden";
                    ViewBag.IsOwner = "hidden";
                }


                if (tournament != null)
                {
                    if (tournament.Gender == true) ViewBag.Gender = "Male";
                    else if (tournament.Gender == false) ViewBag.Gender = "Female";
                    else ViewBag.Gender = "Not specify";
                    ViewBag.Sportname = getSportName(tournament.SportID);
                }

                if (error == 2)
                {
                    ViewBag.Message = "Tournament updated successfully!";
                    ViewBag.Error = false;
                }
                else if(error == 1)
                {
                    ViewBag.Message = "An error has occurred!";
                    ViewBag.Error = true;
                }
                else
                {
                    ViewBag.Message = null;
                    ViewBag.Error = false;
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }


            ViewBag.TournamentID = id;
            ViewBag.Me = memberID;
            return View(tournament);
        }

        // GET: Tournament Create
        public ActionResult CreateTournament()
        {
            try
            {
                getSports();
                ViewBag.sports = sports;
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

        // GET: Tournament Create
        [HttpPost]
        public ActionResult CreateTournament(string name, string sportname, bool? gender, string description)
        {
            try
            {
                getSports();
                ViewBag.sports = sports;

                memberID = GetUserID(User.Identity.Name);
                int sport_id = 0;
                for (int item = 0; item < sports.Count; item++)
                {
                    if (sports[item] == sportname)
                    {
                        sport_id = sportIds[item];
                    }
                }

                Tournament tournament = new Tournament()
                {
                    Name = name,
                    SportID = sport_id,
                    Gender = gender,
                    Description = description,
                    MemberID = memberID
                };

                bool result = tournamentManager.CreateTournament(tournament);
                if (result == true)
                {
                    ViewBag.Error = false;
                    ViewBag.Message = "Tournament Created successfully!";
                }
                else
                {
                    ViewBag.Error = true;
                    ViewBag.Message = "An error has occurred!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = true;
            }

            return View();
        }

        // GET: Tournament Delete
        public ActionResult Delete(int id)
        {

            int error = 0;
            string message = "";

            try
            {
                getSports();
                ViewBag.sports = sports;

                memberID = GetUserID(User.Identity.Name);

                bool result = tournamentManager.DeleteTournament(memberID, id);
                if (result == true)
                {
                    message = "Tournament deleted successfully!";
                    error = 2;
                }
                else
                {
                    message = "An error has occurred!";
                    error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            ViewBag.Message = message;
            ViewBag.Error = error;

            return RedirectToAction("Details", new { 
                id = id,
                error = error
            });
        }

        // GET: Tournament Delete
        public ActionResult Activate(int id)
        {

            int error = 0;
            string message = "";

            try
            {
                getSports();
                ViewBag.sports = sports;

                memberID = GetUserID(User.Identity.Name);

                bool result = tournamentManager.ActivateTournament(memberID, id);
                if (result == true)
                {
                    message = "Tournament activated successfully!";
                    error = 2;
                }
                else
                {
                    message = "An error has occurred!";
                    error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            ViewBag.Message = message;
            ViewBag.Error = error;

            return RedirectToAction("Details", new
            {
                id = id,
                error = error
            });
        }

        // GET: Tournament Edit
        public ActionResult EditTournaments(int id)
        {
            try
            {
                getSports();
                ViewBag.sports = sports;

                tournaments = tournamentManager.GetTournaments();
                tournament = tournaments.Where(b => b.TournamentID == id).First();

                string sportname = "";
                for (int item = 0; item < sportIds.Count; item++)
                {
                    if (sportIds[item] == tournament.SportID)
                    {
                        sportname = sports[item];
                    }
                }

                ViewBag.sportname = sportname;

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View(tournament);
        }

        [HttpPost]
        public ActionResult EditTournaments(int id, string name, string sportname, bool? gender, string description)
        {

            memberID = GetUserID(User.Identity.Name);
            Tournament _tournament = new Tournament()
            {
                TournamentID = id,
                Name = name,
                Gender = gender,
                Description = description,
                MemberID = memberID,
            };

            try
            {
                getSports();
                ViewBag.sports = sports;

                int sport_id = 0;
                for (int item = 0; item < sports.Count; item++)
                {
                    if (sports[item] == sportname)
                    {
                        sport_id = sportIds[item];
                    }
                }

                _tournament.SportID = sport_id;
                ViewBag.sportname = sportname;

                bool result = tournamentManager.EditTournament(memberID, _tournament);
                if (result == true)
                {
                    ViewBag.Error = false;
                    ViewBag.Message = "Tournament Created successfully!";
                }
                else
                {
                    ViewBag.Error = true;
                    ViewBag.Message = "An error has occurred !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = true;
            }

            return View(_tournament);
        }

        // GET: Tournament Edit
        public ActionResult TournamentTeam(int id, int sport_id)
        {
            try
            {
                getSports();
                ViewBag.sports = sports;
                memberID = GetUserID(User.Identity.Name);

                tournaments = tournamentManager.GetTournaments();
                //teams = teamManager.();

                tournament = tournaments.Where(b => b.TournamentID == id).First();
                tournamentTeams = tournamentManager.GetTournamentTeamByID(id);

                getTournamentTeamName(tournamentTeams);
                getTeamName(sport_id);

                ViewBag.Name = tournament.Name;
                ViewBag.TournamentTeams = tournamentTeamname;
                ViewBag.NbreTeam = tournamentTeamname.Count;

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            ViewBag.TournamentID = id;
            ViewBag.SportID = sport_id;
            ViewBag.Me = memberID;
            @ViewBag.png = ".png";
            return View(teams);
        }


        // Remove a team from the tournament
        public ActionResult DeleteTeamFromTournament(int id, int sport_id, int team_id)
        {
            int result = 0;
            try
            {
                TournamentTeam tournamentTeam = new TournamentTeam()
                {
                    TournamentID = id,
                    TeamID = team_id
                };

                result = tournamentManager.RemoveTeamToTournament(tournamentTeam);
                if (result>0)
                {
                    ViewBag.Error = false;
                    ViewBag.Message = "Team deleted successfully!";
                }
                else
                {
                    ViewBag.Error = true;
                    ViewBag.Message = "An error has occurred!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return RedirectToAction("TournamentTeam", new
            {
                id = id,
                sport_id = sport_id
            });
        }


        // Add a team to the tournament
        public ActionResult AddTeamToTournament(int id, int sport_id, int team_id)
        {
            int result = 0;
            try
            {
                TournamentTeam tournamentTeam = new TournamentTeam()
                {
                    TournamentID = id,
                    TeamID = team_id
                };

                result = tournamentManager.AddTeamToTournament(tournamentTeam);
                if (result > 0)
                {
                    ViewBag.Error = false;
                    ViewBag.Message = "Team added successfully!";
                }
                else
                {
                    ViewBag.Error = true;
                    ViewBag.Message = "An error has occurred!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return RedirectToAction("TournamentTeam", new
            {
                id = id,
                sport_id = sport_id
            });
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This method will get the signed in member's id, then get all the teams they are part of and removes any
        /// that are not the same as the tournament sport.

        [Authorize]
        public ActionResult JoinTournament(int tournamentID)
        {
            try
            {

                ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userManager.FindById(User.Identity.GetUserId());


                TeamManager teamManager = new TeamManager();
                Tournament tournament = tournamentManager.RetrieveTournamentByTournamentID(tournamentID);

                List<Team> tempTeams = new List<Team>();
                List<Team> teams = new List<Team>();
                tempTeams = new TeamManager().RetrieveTeamsByMemberID(user.MemberID);
                foreach (var item in tempTeams)
                {
                    if (item.SportID == tournament.SportID)
                    {
                        teams.Add(item);
                    }
                }

                if (teams.Count < 1)
                {
                    TempData["TeamError"] = "You don't have any valid teams to join this tournament";
                    Tournament tourn = tournamentManager.RetrieveTournamentByTournamentID(tournamentID);
                    return RedirectToAction("Details", new { id = tournamentID });
                    
                }

                ViewBag.Tournament = tournament;
                ViewBag.Teams = teams;

                return View();
            }
            catch
            {
                return View("Error");
            }
            
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// HttpPost method for JoinTournament creates a tournamentrequest

        [HttpPost]
        public ActionResult JoinTournament(TournamentRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (tournamentManager.CreateATournamentRequest(request.TournamentID, request.TeamID))
                    {
                        return RedirectToAction("AllTournaments", "Tournaments");
                    }
                    else
                    {
                        
                        TempData["TeamError"] = "Could not add this team to the tournament.";
                        return RedirectToAction("Details", new { id = request.TournamentID });
                    }
                }
                catch
                {
                    ViewBag.Error = "Could not process request";
                    return View();
                }
            }

            return View("Error");
            
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/04/02
        /// 
        /// </summary>
        /// This method will open the view for the tournament admin to see all of the join requests for the tournament
        public ActionResult JoinRequests(int tournamentID, int? requestID, int?teamID, string acceptance)
        {
            List<TournamentRequest> requests = new List<TournamentRequest>();

            if(requestID.HasValue)
            {
                if (acceptance != "")
                {
                    if(acceptance == "Accept")
                    {
                        
                        TournamentTeam tournTeam = new TournamentTeam();
                        tournTeam.TeamID = (int)teamID;
                        tournTeam.TournamentID = tournamentID;
                        tournamentManager.AddTeamToTournament(tournTeam);
                        tournamentManager.UpdateTournamentRequestStatus((int)requestID, acceptance);
                    }
                    else
                    {
                        tournamentManager.UpdateTournamentRequestStatus((int)requestID, acceptance);
                   }
                }
            }

            requests = tournamentManager.RetrieveRequestByTournamentID(tournamentID);

            return View(requests);
        }

        

        






        // Helper Methods

        private void getSports()
        {
            try
            {
                List<string> _sports = teamManager.getSportName();
                foreach (string line in _sports)
                {
                    // Add them into the listbox
                    sports.Add(line.Substring(5));
                    sportIds.Add(Int32.Parse(line.Substring(0, 4)));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
        }

        private string getSportName(int sport_id)
        {
            string sportname = "";

            for(int item = 0; item < sportIds.Count-1; item++)
            {
                if(sportIds[item] == sport_id) sportname = sports[item];
            }
            return sportname;
        }

        private void getTeamName(int sport_id)
        {
            try
            {
                List<TeamSport> _teams = teamManager.getTeamByTeamName("", sport_id);

                foreach (TeamSport line in _teams)
                {
                    var item = tournamentTeams.Find(b => b.TeamID == line.TeamID);
                    // if the teams is already in the tournament, then skip it
                    if (item == null)
                    {
                        teams.Add(line);
                        string a = line.Name;
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
        }

        private void getTournamentTeamName(List<TournamentTeam> tournamentTeams)
        {
            try
            {
                List<TeamSport> _teams = teamManager.getTeamByTeamName("", 0);
                foreach (TeamSport line in _teams)
                {
                    var item = tournamentTeams.Find(id => id.TeamID == line.TeamID);
                    if (item != null)
                    {
                        Team team = new Team
                        {
                            TeamName = line.Name,
                            TeamID = line.TeamID,
                            Description = line.Description
                        };

                        tournamentTeamname.Add(team);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
        }

        private void getTeamGame(List<TournamentTeamGame> tournamentTeams)
        {
            try
            {
                List<TeamSport> _teams = teamManager.getTeamByTeamName("", 0);
                int ctr = 0;
                string teamname = "";

                foreach (TeamSport line in _teams)
                {
                    var item = tournamentTeams.Find(id => id.TeamID == line.TeamID);
                    if (item != null)
                    {
                        ctr++;

                        if (ctr == 2)
                        {
                            var team = new TournamentGenerateGames
                            {
                                Content = teamname + " VS " + line.Name
                            };

                            games.Add(team);
                            ctr = 0;
                        }

                        teamname = line.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
        }

        public int GetUserID(string email)
        {
            Member _member = new Member();
            try
            {
                if (email != "") _member = _memberManager.GetMemberByName(email).First();
                else _member.MemberID = 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return _member.MemberID;
        }

    }
}