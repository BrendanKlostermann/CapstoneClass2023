/// <summary>
/// Created By: Jacob Lindauer
/// Date: 04/21/2023
/// 
/// Class handles member shedule
/// </summary>
using LogicLayer;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentation.Controllers
{
    public class ScheduleController : Controller
    {
        MasterManager _masterManager = null;
        public ScheduleController()
        {
            _masterManager = new MasterManager();
        }
        // GET: Schedule
        // Member needs to be signed in, retrieve member schedule events
        /// <summary>
        /// Created By: Jacob Lindauer 
        /// Date: 04/20/2023
        /// 
        /// View member schedule
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewSchedule()
        {
            var events = _masterManager.MemberManager.RetreiveMemberSchedule(100001); // Value is hard set until identity system is implemented

            return View(events);
        }

        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedule/Create
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

        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Schedule/Edit/5
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

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Schedule/Delete/5
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
