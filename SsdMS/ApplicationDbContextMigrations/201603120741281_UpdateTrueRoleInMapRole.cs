namespace SsdMS.ApplicationDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTrueRoleInMapRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrueRoles",
                c => new
                    {
                        TrueRoleID = c.Long(nullable: false, identity: true),
                        TrueRoleName = c.String(),
                        TrueRoleDescription = c.String(),
                        MapRoleID = c.Long(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.TrueRoleID)
                .ForeignKey("dbo.MapRoles", t => t.MapRoleID, cascadeDelete: true)
                .Index(t => t.MapRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrueRoles", "MapRoleID", "dbo.MapRoles");
            DropIndex("dbo.TrueRoles", new[] { "MapRoleID" });
            DropTable("dbo.TrueRoles");
        }
    }
}
