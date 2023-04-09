using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class SearchController : Controller
    {
        TeamManager teamManager = new TeamManager();
        SportManager sportManager = new SportManager();
        List<TeamSport> teams = new List<TeamSport>();
        List<string> sports = new List<string>();
        List<int> sportIds = new List<int>();

        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            try
            {
                getSports();
                ViewBag.sports = sports;

                teams = teamManager.getTeamByTeamName("", 0);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            ViewBag.png = ".png";
            return View(teams);
        }

        [HttpPost]
        public ActionResult Search(string teamname, string sport)
        {
            try
            {
                getSports();
                ViewBag.sports = sports;

                int sport_id = 0;
                for (int item = 0; item < sports.Count; item++)
                {
                    if (sports[item] == sport)
                    {
                        sport_id = sportIds[item];
                    }
                }

                teams = teamManager.getTeamByTeamName(teamname, sport_id);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            ViewBag.png = ".png";
            ViewBag.sport = sport;
            ViewBag.teamname = teamname;
            return View(teams);
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