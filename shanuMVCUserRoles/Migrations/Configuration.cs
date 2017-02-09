namespace shanuMVCUserRoles.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<shanuMVCUserRoles.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "shanuMVCUserRoles.Models.ApplicationDbContext";
        }

        protected override void Seed(shanuMVCUserRoles.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            context.States.AddOrUpdate(s => s.StateId,

                new State() { StateId = 1, Name = "Rajasthan" },
                new State() { StateId = 2, Name = "Haryana" },
                new State() { StateId = 3, Name = "Delhi" });

            context.Cities.AddOrUpdate(c => c.CityId,

                new City() { StateId = 1, Name = "Ajmer" , CityId=1},
                new City() { StateId = 2, Name = "Bhiwani", CityId=2 },
                new City() { StateId = 3, Name = "NDelhi", CityId=3 },
                 new City() { StateId = 1, Name = "Jaipur", CityId = 4 },
                new City() { StateId = 2, Name = "Rohtak", CityId = 5 },
                new City() { StateId = 3, Name = "Motonagar", CityId = 6 });

            context.BloodGroups.AddOrUpdate(b => b.BloodGroupId,
                new BloodGroup() { BloodGroupId = 1, Name = "B+" },
                new BloodGroup() { BloodGroupId = 1, Name = "O+" });
        }
    }
}
