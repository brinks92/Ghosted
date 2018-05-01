namespace Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Project.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<Project.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true ;
        }

        protected override void Seed(Project.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.users.AddOrUpdate(
                m => m.UserID,
                new users()
                {
                    UserID = 1,
                    FirstName = "johnny",
                    LastName = "bell",
                    UserName = "kickass"
                });
        }
    }
}
