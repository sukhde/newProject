namespace SBlogPostApplication.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SBlogPostApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SBlogPostApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SBlogPostApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            // Create objects to manage Roles and Users.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Check if Roles already exist on the database/
            //If not, create them.
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            ApplicationUser adminUser = null;
            ApplicationUser moderatorUser = null;
            ApplicationUser User = null;

            //Check if user exists on the database.
            //If not, create it. 
            if (!context.Users.Any(p => p.UserName == "admin@myblogapp.com"))
            {
                adminUser = new ApplicationUser();
                adminUser.UserName = "admin@myblogapp.com";
                adminUser.Email = "admin@myblogapp.com";
                adminUser.FirstName = "Admin";
                adminUser.LastName = "User";
                adminUser.DisplayName = "Admin User";

                userManager.Create(adminUser, "Deep21@");
            }
            else
            {
                //Get user from the database
                adminUser = context.Users.Where(p => p.UserName == "admin@myblogapp.com")
                    .FirstOrDefault();
            }

            if (!context.Users.Any(p => p.UserName == "aksay@myblogapp.com"))
            {
                moderatorUser = new ApplicationUser();
                moderatorUser.UserName = "aksay@myblogapp.com";
                moderatorUser.Email = "aksay@myblogapp.com";
                moderatorUser.FirstName = "Moderator";
                moderatorUser.LastName = "User";
                moderatorUser.DisplayName = "Moderator User";

                userManager.Create(moderatorUser, "Password-1");
            }
            else
            {
                moderatorUser = context.Users.Where(p => p.UserName == "aksay@myblogapp.com")
                    .FirstOrDefault();
            }

            if (!context.Users.Any(p => p.UserName == "amn@myblogapp.com"))
            {
                User = new ApplicationUser();
                User.UserName = "amn@myblogapp.com";
                User.Email = "amn@myblogapp.com";
                User.FirstName = "my";
                User.LastName = "User";
                User.DisplayName = "my User";

                userManager.Create(User, "Password-1");
            }
            else
            {
                User = context.Users.Where(p => p.UserName == "amn@myblogapp.com")
                    .FirstOrDefault();
            }

            //Check if the adminUser is already on the Admin role
            //If not, add it.
            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }
            if (!userManager.IsInRole(moderatorUser.Id, "Moderator"))
            {
                userManager.AddToRole(moderatorUser.Id, "Moderator");
            }
            if (!userManager.IsInRole(User.Id, "User"))
            {
                userManager.AddToRole(User.Id, "User");
            }
        }
    }
}

 
   
