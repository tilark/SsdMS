namespace SsdMS.ApplicationDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartDuties",
                c => new
                    {
                        DepartDutyID = c.Long(nullable: false, identity: true),
                        DepartmentID = c.Long(nullable: false),
                        DutyID = c.Long(nullable: false),
                        InfoUser_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.DepartDutyID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Duties", t => t.DutyID, cascadeDelete: true)
                .ForeignKey("dbo.InfoUsers", t => t.InfoUser_UserId)
                .Index(t => t.DepartmentID)
                .Index(t => t.DutyID)
                .Index(t => t.InfoUser_UserId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentPhone1 = c.String(),
                        DepartmentPhone2 = c.String(),
                        DepartmentPhone3 = c.String(),
                        DepartmentPhone4 = c.String(),
                        DepartmentDescrip = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Duties",
                c => new
                    {
                        DutyID = c.Long(nullable: false, identity: true),
                        DutyName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.DutyID);
            
            CreateTable(
                "dbo.InfoUsers",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        EmployeeNo = c.String(),
                        UserName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Sex = c.String(maxLength: 4),
                        Phone1 = c.String(maxLength: 11),
                        Phone2 = c.String(maxLength: 11),
                        Phone3 = c.String(maxLength: 11),
                        Phone4 = c.String(maxLength: 11),
                        Phone5 = c.String(maxLength: 11),
                        Email = c.String(),
                        DepartDutyID = c.Long(nullable: false),
                        ProfessionID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Professions", t => t.ProfessionID, cascadeDelete: true)
                .Index(t => t.ProfessionID);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        ProfessionID = c.Long(nullable: false, identity: true),
                        ProfessionName = c.String(),
                    })
                .PrimaryKey(t => t.ProfessionID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        InfoUser_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InfoUsers", t => t.InfoUser_UserId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.InfoUser_UserId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "InfoUser_UserId", "dbo.InfoUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.InfoUsers", "ProfessionID", "dbo.Professions");
            DropForeignKey("dbo.DepartDuties", "InfoUser_UserId", "dbo.InfoUsers");
            DropForeignKey("dbo.DepartDuties", "DutyID", "dbo.Duties");
            DropForeignKey("dbo.DepartDuties", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "InfoUser_UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.InfoUsers", new[] { "ProfessionID" });
            DropIndex("dbo.DepartDuties", new[] { "InfoUser_UserId" });
            DropIndex("dbo.DepartDuties", new[] { "DutyID" });
            DropIndex("dbo.DepartDuties", new[] { "DepartmentID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Professions");
            DropTable("dbo.InfoUsers");
            DropTable("dbo.Duties");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartDuties");
        }
    }
}
