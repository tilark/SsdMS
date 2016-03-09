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
            //   new Department { DepartmentID = 1, DepartmentName = "Admin" }
            //   );
            //context.SaveChanges();

            //context.Duties.AddOrUpdate(
            //    new Duty { DutyID = 1, DutyName = "Admin" }
            //    );
            //context.SaveChanges();

            //context.Professions.AddOrUpdate(
            //    new Profession { ProfessionID = 1, ProfessionName = "Admin" }
            //    );
            //context.SaveChanges();

            //var department = new Department();
            //department.DepartmentName = "Admin";
            //var duty = context.Duties.Find(1);
            //var profession = context.Professions.Find(1);
            //context.InfoUsers.AddOrUpdate(
            //    new InfoUser { InfoUserID = 1, UserName = "Admin", Profession = profession, BirthDate = DateTime.Now, ProfessionID = profession.ProfessionID }
            //    );
            //context.SaveChanges();
            //var infouser = context.InfoUsers.Find(6);
            //context.DepartmentDuties.AddOrUpdate(
            //    new DepartmentDuty {  DepartmentID = department.DepartmentID, DutyID = duty.DutyID, InfoUserID = infouser.InfoUserID, Department = department, Duty = duty, InfoUser = infouser }
            //    );
            //context.SaveChanges();
        }
    }
}
