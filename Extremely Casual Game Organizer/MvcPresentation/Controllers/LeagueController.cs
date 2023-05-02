using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Elijah Morgan
/// Created: 2023/4/11/
/// 
/// A controller for the League section of the MVC
/// </summary>
///
/// <remarks>
/// Elijah Morgan
/// Updated: 2023/4/18
/// 
/// Added a view to view all leagues and league details
/// </remarks>
/// <remarks>
/// Elijah Morgan
/// Updated: 2023/4/25
/// 
/// Added a view create a league
/// </remarks>

namespace MvcPresentation.Controllers
{
    public class LeagueController : Controller
    {
        LeagueManager leagueManager = new LeagueManager();
        private List<LeagueGridVM> leagues = null;
        private ILeagueManager _leagueManager;
        private ISportManager _sportManager;
        /*const int memberID = 100000;*/

        // GET: League
        public ActionResult AllLeagues()
        {
            try
            {
                leagues = leagueManager.RetrieveListOfLeaguesForGrid();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
            }

            return View(leagues.OrderBy(l => l.SportName));
        }

        // GET: League/Details/5
        public ActionResult Details(string id)
        {
            int leagueID = int.Parse(id);
            League league = leagueManager.RetrieveLeagueByLeagueID(leagueID);

            LeagueVM leagueVM = leagueManager.ConvertToLeagueVM(league);

            return View(leagueVM);
        }

        // GET: League/Create
        public ActionResult CreateLeague()
        {
            try
            {
                ViewBag.GenderList = new List<string>() { "Open to All", "Male", "Female" };
                SportManager _sportManager = new SportManager();
                ViewBag.SportList = _sportManager.RetrieveAllSports();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message + "<br /><br />" + ex.InnerException.Message;
                return View("Error");
            }
        }

        // POST: League/Create
        [HttpPost]
        public ActionResult CreateLeague(LeagueVM l)
        {
            try
            {
                // TODO: Add insert logic here
                League league = new League();

                if (ModelState.IsValid)
                {
                    /*league.MemberID = memberID;*/
                    switch (l.AssignedGender)
                    {
                        case "Open to All":
                            league.Gender = null;
                            break;
                        case "Male":
                            league.Gender = true;
                            break;
                        case "Female":
                            league.Gender = false;
                            break;
                        default:
                            break;
                    }
                    league.Name = l.Name;
                    league.Description = l.Description;
                    league.SportID = l.SportID;
                    league.MaxNumOfTeams = l.MaxNumOfTeams;
                    league.LeagueDues = l.LeagueDues;
                }

                int createdLeagues = leagueManager.AddLeague(league);
                if (createdLeagues != 0)
                {
                    ViewBag.Error = false;
                    ViewBag.Message = "League Created successfully!";
                    return RedirectToAction("AllLeagues");
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

            try
            {
                ViewBag.GenderList = new List<string>() { "Open to All", "Male", "Female" };
                SportManager _sportManager = new SportManager();
                ViewBag.SportList = _sportManager.RetrieveAllSports();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message + "<br /><br />" + ex.InnerException.Message;
                return View("Error");
            }
        }

        // GET: League/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: League/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: League/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: League/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
