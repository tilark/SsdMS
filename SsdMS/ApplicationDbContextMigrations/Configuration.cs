namespace SsdMS.ApplicationDbContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SsdMS.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<SsdMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"ApplicationDbContextMigrations";
        }

        protected override void Seed(SsdMS.Models.ApplicationDbContext context)
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
            //     
            context.Departments.AddOrUpdate(
                new Department { DepartmentName = "Admin" }
                );
            context.SaveChanges();

            context.Duties.AddOrUpdate(
                new Models.Duty { DutyName = "Admin" }
                );
            context.Professions.AddOrUpdate(
                new Models.Profession { ProfessionName = "Admin" }
                );
            context.SaveChanges();

            //context.InfoUsers.AddOrUpdate(
            //    new Models.InfoUser { UserName = "Admin", ProfessionID = 1, }
            //    );
            //context.SaveChanges();
            //context.DepartmentDuties.AddOrUpdate(
            //    new Models.DepartmentDuty {  DutyID = 1, DepartmentID = 1, InfoUser = context.InfoUsers.Find(1) }
            //    );
            //context.SaveChanges();

        }
    }
}
