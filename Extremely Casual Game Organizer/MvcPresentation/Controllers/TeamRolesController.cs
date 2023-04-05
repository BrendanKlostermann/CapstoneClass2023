using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace MvcPresentation.Controllers
{
    public class TeamRolesController : Controller
    {
        ITeamRolesManager _teamRolesManager = null;

        public TeamRolesController()
        {
            _teamRolesManager = new TeamRolesManager();
        }

        public TeamRolesController(ITeamRolesManager teamRolesManager)
        {
            _teamRolesManager = teamRolesManager;
        }

        // GET: Team
        public ActionResult Index()
        {
            IEnumerable<TeamRoles> teamRoles = _teamRolesManager.RetrieveTeamRoles();

            return View(teamRoles);
        }


    }
}