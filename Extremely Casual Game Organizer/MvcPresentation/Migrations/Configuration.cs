namespace MvcPresentation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MvcPresentation.Models;
    using LogicLayer;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcPresentation.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcPresentation.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            const string admin = "Admin@company.com";
            const string adminPassword = "P@ssw0rd";

            // Note: There is purposely no using statement for LogicLayer. This is to force
            // programmers to use the fully qualified name for our internal UserManager, to
            // keep it clear that this is not the Identity systems UserManager class.

            LogicLayer.MemberManager userMgr = new LogicLayer.MemberManager();
            var roles = userMgr.RetrieveAllRoles();
            foreach (var role in roles)
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = role });
            }
            if (!roles.Contains("Admin"))
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Admin" });
                // Note: Even though Administrator should be in the list of roles, this check is to
                // remove any risk of it being missing due to deletion from the internal database
            }

            if (!context.Users.Any(u => u.UserName == admin))
            {
                var user = new ApplicationUser()
                {
                    UserName = admin,
                    Email = admin
                };

                IdentityResult result = userManager.Create(user, adminPassword);
                context.SaveChanges(); // updates the database

                // This code will add the Administrator role to admin
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                    context.SaveChanges();
                }
            }
        }
    }
}
