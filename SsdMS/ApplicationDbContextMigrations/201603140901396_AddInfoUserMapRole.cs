namespace SsdMS.ApplicationDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInfoUserMapRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InfoUsers", "MapRoleID", "dbo.MapRoles");
            DropIndex("dbo.InfoUsers", new[] { "MapRoleID" });
            CreateTable(
                "dbo.InfoUserMapRoles",
                c => new
                    {
                        InfoUserMapRoleID = c.Long(nullable: false, identity: true),
                        InfoUserID = c.Long(nullable: false),
                        MapRoleID = c.Long(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.InfoUserMapRoleID)
                .ForeignKey("dbo.InfoUsers", t => t.InfoUserID, cascadeDelete: true)
                .ForeignKey("dbo.MapRoles", t => t.MapRoleID, cascadeDelete: false)
                .Index(t => t.InfoUserID)
                .Index(t => t.MapRoleID);
            
            DropColumn("dbo.InfoUsers", "MapRoleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InfoUsers", "MapRoleID", c => c.Long(nullable: false));
            DropForeignKey("dbo.InfoUserMapRoles", "MapRoleID", "dbo.MapRoles");
            DropForeignKey("dbo.InfoUserMapRoles", "InfoUserID", "dbo.InfoUsers");
            DropIndex("dbo.InfoUserMapRoles", new[] { "MapRoleID" });
            DropIndex("dbo.InfoUserMapRoles", new[] { "InfoUserID" });
            DropTable("dbo.InfoUserMapRoles");
            CreateIndex("dbo.InfoUsers", "MapRoleID");
            AddForeignKey("dbo.InfoUsers", "MapRoleID", "dbo.MapRoles", "MapRoleID", cascadeDelete: true);
        }
    }
}
