using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class TeamsController : Controller
    {
        TeamManager teamManager = new TeamManager();
        List<Team> teams = new List<Team>();
        List<string> sports = new List<string>();
        List<int> sportIds = new List<int>();
        int memberID = 100000;

        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        // GET: Create Team
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

        [HttpPost]
        public ActionResult CreateTeam(string TeamName, bool? Gender, string sportname)
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
    }
}