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
