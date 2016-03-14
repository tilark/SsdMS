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
            //context.Departments.AddOrUpdate(
            //  new Department { DepartmentName = "Departmet1" },
            //  new Department { DepartmentName = "Departmet2" }
            //  );
            //context.SaveChanges();

            //context.Duties.AddOrUpdate(
            //    new Duty { DutyName = "Duty1" },
            //    new Duty { DutyName = "Duty2" }
            //    );
            //context.SaveChanges();

            //context.Professions.AddOrUpdate(
            //    new Profession { ProfessionName = "Profession1" },
            //    new Profession { ProfessionName = "Profession2" }
            //    );
            //context.SaveChanges();

        }
    }
}
