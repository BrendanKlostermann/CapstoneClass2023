using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
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
        private List<Team> teams = new List<Team>();
        private List<TournamentGenerateGames> games = new List<TournamentGenerateGames>();

        List<string> sports = new List<string>();
        List<int> sportIds = new List<int>();
        int memberID = 100000;

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

        // GET: Tournament Detail
        public ActionResult Details(int id, int? type)
        {
            try
            {
                getSports();
                ViewBag.sports = sports;
                tournaments = tournamentManager.GetTournaments();
                tournament = tournaments.Where(b => b.TournamentID == id).First();
                tournamentTeams = tournamentManager.GetTournamentTeamByID(id);
                tournamentGames = tournamentManager.SelectTournamentTeamAndGame(id);

                getTeamName(tournamentTeams);
                getTeamGame(tournamentGames);

                ViewBag.TournamentTeams = teams;
                ViewBag.TournamentGames = games;
                ViewBag.NbreTeam = tournamentTeams.Count;
                ViewBag.NbreGame = tournamentGames.Count/2;
                ViewBag.Type = type;



                if (tournament != null)
                {
                    if (tournament.Gender == true) ViewBag.Gender = "Male";
                    else if (tournament.Gender == false) ViewBag.Gender = "Female";
                    else ViewBag.Gender = "Not specify";
                    ViewBag.Sportname = getSportName(tournament.SportID);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            ViewBag.TournamentID = id;
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
            return View();
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

            Tournament _tournament = new Tournament()
            {
                Name = name,
                Gender = gender,
                Description = description,
                MemberID = memberID
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

                //bool result = tournamentManager.Update(tournament);
                bool result = false;
                if (result == true)
                {
                    ViewBag.Error = false;
                    ViewBag.Message = "Tournament Created successfully!";
                }
                else
                {
                    ViewBag.Error = true;
                    ViewBag.Message = "sp_update_tournament not found!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = true;
            }

            return View(_tournament);
        }

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

        private void getTeamName(List<TournamentTeam> tournamentTeams)
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
                            TeamID = line.TeamID
                        };

                        teams.Add(team);
                    }
                }
            }
            catch(Exception ex)
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
    }
}