namespace SsdMS.ApplicationDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInfoUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentDuties",
                c => new
                    {
                        DepartmentDutyID = c.Long(nullable: false, identity: true),
                        DepartmentID = c.Long(nullable: false),
                        DutyID = c.Long(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        InfoUser_InfoUserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentDutyID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Duties", t => t.DutyID, cascadeDelete: true)
                .ForeignKey("dbo.InfoUsers", t => t.InfoUser_InfoUserId, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.DutyID)
                .Index(t => t.InfoUser_InfoUserId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 50),
                        DepartmentPhone1 = c.String(maxLength: 30),
                        DepartmentPhone2 = c.String(maxLength: 30),
                        DepartmentPhone3 = c.String(maxLength: 30),
                        DepartmentPhone4 = c.String(maxLength: 30),
                        DepartmentDescription = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Duties",
                c => new
                    {
                        DutyID = c.Long(nullable: false, identity: true),
                        DutyName = c.String(maxLength: 50),
                        DutyDescription = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DutyID);
            
            CreateTable(
                "dbo.InfoUsers",
                c => new
                    {
                        InfoUserId = c.Long(nullable: false, identity: true),
                        EmployeeNo = c.String(maxLength: 20),
                        UserName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        IDCard = c.String(maxLength: 30),
                        Address = c.String(),
                        Sex = c.String(maxLength: 20),
                        Phone1 = c.String(maxLength: 30),
                        Phone2 = c.String(maxLength: 30),
                        Phone3 = c.String(maxLength: 30),
                        Phone4 = c.String(maxLength: 30),
                        Phone5 = c.String(maxLength: 30),
                        Email = c.String(maxLength: 100),
                        InfoUserDescription = c.String(),
                        ProfessionID = c.Long(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.InfoUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Professions", t => t.ProfessionID, cascadeDelete: true)
                .Index(t => t.ProfessionID)
                .Index(t => t.ApplicationUser_Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        ProfessionID = c.Long(nullable: false, identity: true),
                        ProfessionName = c.String(maxLength: 50),
                        ProfessionDescription = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DepartmentDuties", "InfoUser_InfoUserId", "dbo.InfoUsers");
            DropForeignKey("dbo.InfoUsers", "ProfessionID", "dbo.Professions");
            DropForeignKey("dbo.InfoUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DepartmentDuties", "DutyID", "dbo.Duties");
            DropForeignKey("dbo.DepartmentDuties", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.InfoUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.InfoUsers", new[] { "ProfessionID" });
            DropIndex("dbo.DepartmentDuties", new[] { "InfoUser_InfoUserId" });
            DropIndex("dbo.DepartmentDuties", new[] { "DutyID" });
            DropIndex("dbo.DepartmentDuties", new[] { "DepartmentID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Professions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.InfoUsers");
            DropTable("dbo.Duties");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartmentDuties");
        }
    }
}
