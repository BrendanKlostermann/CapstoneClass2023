using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using System.Data;
using LogicLayer;

namespace MvcPresentation.Controllers
{
    public class GamesController : Controller
    {
        MasterManager _masterManager;
        public GamesController()
        {
            _masterManager = new MasterManager();
        }
        // GET: Games
        public ActionResult AllGames()
        {
            try
            {
                DataTable gameList = _masterManager.GameManager.ViewAllGames();

                return View(gameList);
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DataRow details = _masterManager.GameManager.ViewGameDetails(id);

                // Load Team Data and Rosters. Should only be 2 results per game
                var teams = _masterManager.GameRosterManager.RetrieveGameRoster(id).Select(x => x.TeamID).Distinct();

                Team team1 = _masterManager.TeamManager.RetrieveTeamByTeamID(teams.First());
                Team team2 = _masterManager.TeamManager.RetrieveTeamByTeamID(teams.Last());

                var team1Roster = from player in _masterManager.GameRosterManager.RetrieveGameRoster(id) where player.TeamID.Equals(team1.TeamID) select player;

                var team2Roster = from player in _masterManager.GameRosterManager.RetrieveGameRoster(id) where player.TeamID.Equals(team2.TeamID) select player;

                var gameScores = _masterManager.GameManager.RetreiveScoresByGameID(id);

                ViewBag.Team1 = team1;
                ViewBag.Team2 = team2;
                ViewBag.Team1Roster = team1Roster;
                ViewBag.Team2Roster = team2Roster;

                Score team1Score = (from score in gameScores where score.TeamID == team1.TeamID select score).First();
                Score team2Score = (from score in gameScores where score.TeamID == team2.TeamID select score).First();

                if (team1Score != null && team2Score != null)
                {
                    if (team1Score.TeamScore % 1 == 0 || team2Score.TeamScore % 1 == 0)
                    {
                        if (team1Score.TeamScore % 1 == 0)
                        {
                            ViewBag.Team1Score = Convert.ToInt32(team1Score.TeamScore);
                        }
                        if (team2Score.TeamScore % 1 == 0)
                        {
                            ViewBag.Team2Score = Convert.ToInt32(team2Score.TeamScore);
                        }
                    }
                    else
                    {
                        ViewBag.Team1Score = team1Score.TeamScore;
                        ViewBag.Team2Score = team2Score.TeamScore;
                    }
                }
                // Placeholder until implemented

                return View(details);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
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

        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Games/Edit/5
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

        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Games/Delete/5
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
