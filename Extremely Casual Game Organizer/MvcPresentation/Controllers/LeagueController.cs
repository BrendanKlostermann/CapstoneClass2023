using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class LeagueController : Controller
    {
        LeagueManager leagueManager = new LeagueManager();
        private List<LeagueGridVM> leagues = null;
        int memberID;

        // GET: League
        public ActionResult AllLeagues()
        {
            try
            {
                leagues = leagueManager.RetrieveListOfLeaguesForGrid();
                if (TempData["userError"] != null)
                {
                    ViewBag.UserError = TempData["userError"].ToString();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
            }

            return View(leagues);
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: League/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: League/Edit/5
        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/04/25
        /// 
        /// </summary>
        /// This Action Result is for editing a league, it will check signed in users memberID against the memberID contained by the league
        /// to determine if they are allowed to edit
        /// if not they are sent back to the list of leagues and given an error message
        /// 
        //[Authorize]
        public ActionResult Edit(string id)
        {

            try
            {
                List<Sport> sports = new SportManager().RetrieveAllSports();
                League league = leagueManager.RetrieveLeagueByLeagueID(int.Parse(id));
                if (memberID == league.MemberID)
                {
                    Session["oldLeague"] = league;
                    LeagueVM leaguevm = leagueManager.ConvertToLeagueVM(league);
                    ViewBag.Sports = sports;
                    return View(leaguevm);
                }
                else
                {
                    TempData["userError"] = "You do not own this league and can not make changes";
                    return RedirectToAction("AllLeagues");
                }

            }
            catch
            {
                ViewBag.Error = "Could not find league";
                return View("Error");
            }

        }

        // POST: League/Edit/5
        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/04/25
        /// 
        /// </summary>
        /// This is the Post Action Result for updating a league, the user will enter the data they wish to edit and select save
        /// this method checks if the Model is correct and attempt to save the changes to the database.
        [HttpPost]
        public ActionResult Edit(LeagueVM league)
        {
            if (ModelState.IsValid)
            {
                var oldLeague = Session["oldLeague"] as League;
                League newLeague = new League()
                {
                    LeagueID = league.LeagueID,
                    SportID = league.SportID,
                    LeagueDues = league.LeagueDues,
                    Active = league.Active,
                    MemberID = league.MemberID,
                    Gender = league.Gender,
                    Description = league.Description,
                    Name = league.Name,
                    MaxNumOfTeams = league.MaxNumOfTeams
                };

                leagueManager.EditLeague(oldLeague, newLeague);

                Session.Remove("oldLeague");


                return RedirectToAction("AllLeagues");
            }

            return View("Error");
        }

        // GET: League/Delete/5

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/04/25
        /// 
        /// </summary>
        /// This Action Result is for deactivating a league, it will check signed in users memberID against the memberID contained 
        /// by the league to determine if they are allowed to edit
        /// if not they are sent back to the list of leagues and given an error message
        /// 

        //[Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                League league = leagueManager.RetrieveLeagueByLeagueID(int.Parse(id));

                if (memberID == league.MemberID)
                {
                    return View(league);
                }
                else
                {
                    TempData["userError"] = "You do not own this league and can not delete it.";
                    return RedirectToAction("AllLeagues");
                }
            }
            catch
            {
                ViewBag.Error = "Could not find league";
                return View("Error");
            }

        }

        // POST: League/Delete/5

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/04/25
        /// 
        /// </summary>
        /// This is the Post Action Result for deactivating a league, if the user selects confirm it will run the 
        /// leaguemanager method to deactivate the league

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            League league = leagueManager.RetrieveLeagueByLeagueID((int)id);
            if (id != null)
            {
                try
                {
                    leagueManager.RemoveLeague((int)id);

                    return RedirectToAction("AllLeagues");

                }
                catch
                {
                    ViewBag.Error = "Could not deactivate league";
                    return View("Error");
                }
            }
            return View("Error");
        }
    }
}
