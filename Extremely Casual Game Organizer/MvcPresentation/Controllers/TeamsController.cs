using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace MvcPresentation.Controllers
{
    public class TeamsController : Controller
    {
        TeamManager teamManager = new TeamManager();
        List<Team> teams = new List<Team>();
        List<string> sports = new List<string>();
        List<int> sportIds = new List<int>();


        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        // GET: Team
        /// <summary>
        // Heritier Otiom
        /// </summary>
        public ActionResult Details(int id)
        {
            teams = teamManager.RetrieveAllTeams();
            Team team = teams.Find(x => x.TeamID == id);
            return View(team);
        }

        // GET: Create Team
        /// <summary>
        // Heritier Otiom
        /// </summary>
        public ActionResult CreateTeam()
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

        /// <summary>
        // Heritier Otiom
        /// </summary>
        [HttpPost]
        public ActionResult CreateTeam(string TeamName, bool? Gender, string sportname)
        {

            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            int memberID = user.MemberID;
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

                if (Gender != true) Gender = false;

                Team team = new Team()
                {
                    TeamName = TeamName,
                    Gender = Gender,
                    SportID = sport_id,
                    MemberID = memberID
                };

                int result = teamManager.AddTeam(team);
                if (result > 0)
                {
                    ViewBag.Message = "Team created successfully!";
                    ViewBag.Error = false;
                }
                else
                {
                    ViewBag.Message = "An error has occurred!";
                    ViewBag.Error = true;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
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

        // GET: RetriveAllTeams
        /// <summary>
        /// /// Garion Opiola
        /// Created: 2023/04/08
        /// gets all teams for controller
        /// </summary>
        public ActionResult AllTeams()
        {
            try
            {
                teams = teamManager.RetrieveAllTeams();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
            }

            return View(teams);
        }

        // GET: Team Deactivate
        /// <summary>
        /// /// Garion Opiola
        /// Created: 2023/04/16
        /// deactivate team for WEB app
        /// </summary>
        public ActionResult Deactivate(int team_id)
        {
            int result = 0;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            int memberID = user.MemberID;

            try
            {
                result = teamManager.RemoveOwnTeam(team_id, memberID);
                if (result > 0)
                {
                    ViewBag.Error = false;
                    ViewBag.Message = "Team deavtivated successfully!";
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

            return RedirectToAction("AllTeams", new
            {
                memberID = memberID,
            });
            return View();
        }
    }
}