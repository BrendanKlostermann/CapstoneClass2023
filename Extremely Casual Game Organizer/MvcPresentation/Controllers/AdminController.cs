using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcPresentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MvcPresentation.Controllers
{
    /// <summary>
    /// Michael Haring
    /// Created: 2023/04/25
    /// 
    /// Controller for admin portal
    /// 
    /// </summary>
    public class AdminController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager userManager;

        // GET: Admin
        public ActionResult Index()
        {
            // return View(db.ApplicationUsers.ToList());
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return View(userManager.Users.OrderBy(n => n.FamilyName).ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser applicationUser = userManager.Users.First(u => u.Id == id);

            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            // get a list of roles the user has and put them into a viewbag as roles
            // along with a list of roles the user doesn't have as noRoles
            var usrMgr = new LogicLayer.MemberManager();
            var allRoles = usrMgr.RetrieveAllRoles();

            var roles = userManager.GetRoles(id);
            var noRoles = allRoles.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View(applicationUser);
        }

        // Temporarily commented out
        // Possibly can be modified to represent other functionality I need to work on later

        //    // GET: Admin/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Admin/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "Id,MemberID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.ApplicationUsers.Add(applicationUser);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(applicationUser);
        //    }

        //    // GET: Admin/Edit/5
        //    public ActionResult Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //        if (applicationUser == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(applicationUser);
        //    }

        //    // POST: Admin/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Id,MemberID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(applicationUser).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(applicationUser);
        //    }

        //    // GET: Admin/Delete/5
        //    public ActionResult Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //        if (applicationUser == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(applicationUser);
        //    }

        //    // POST: Admin/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(string id)
        //    {
        //        ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //        db.ApplicationUsers.Remove(applicationUser);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

        /// <summary>
        /// Michael Haring
        /// Created: 05/01/2023
        /// 
        /// Adds roles to members
        /// </summary>
        public ActionResult AddRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            userManager.AddToRole(id, role);

            // get a list of roles the user has and put them into a viewbag as roles
            // along with a list of roles the user doesn't have as noRoles
            var usrMgr = new LogicLayer.MemberManager();
            var allRoles = usrMgr.RetrieveAllRoles();

            var roles = userManager.GetRoles(id);
            var noRoles = allRoles.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View("Details", user);
        }

        public ActionResult RemoveRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            // code to prevent removing the last administrator
            if (role == "Administrator")
            {
                var adminUsers = userManager.Users.ToList()
                    .Where(u => userManager.IsInRole(u.Id, "Administrator"))
                    .ToList().Count();
                if (adminUsers < 2)
                {
                    ViewBag.Error = "Cannot remove last administrator.";
                }
                else
                {
                    userManager.RemoveFromRoleAsync(id, role).Wait();
                }
            }
            else
            {
                userManager.RemoveFromRoleAsync(id, role).Wait();
            }

            // get a list of roles the user has and put them into a viewbag as role
            // along with a list of roles the user doesn't have as noRoles
            var usrMgr = new LogicLayer.MemberManager();
            var allRoles = usrMgr.RetrieveAllRoles();

            var roles = userManager.GetRoles(id);
            var noRoles = allRoles.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View("Details", user);
        }
    }
}
