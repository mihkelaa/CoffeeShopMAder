namespace CoffeeShop.Migrations
{
    using CoffeeShop.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeeShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CoffeeShop.Models.ApplicationDbContext";
        }

        protected override void Seed(CoffeeShop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Kohviautomaat.AddOrUpdate(r => r.JoogiNimi,
                new Kohviautomaat
                {
                    JoogiNimi = "Kohvi"
                },
                new Kohviautomaat
                {
                    JoogiNimi = "Tee"
                },
                new Kohviautomaat
                {
                    JoogiNimi = "Kakao"
                });
            SeedMembership(context);
        }
        private void SeedMembership(CoffeeShop.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };
                manager.Create(role);
            }
            if (!context.Users.Any(r => r.Email == "admin@hotmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@hotmail.com", Email = "admin@hotmail.com" };
                manager.Create(user, "admin.");
                manager.AddToRole(user.Id, "admin");
            }
        }
    }
}
