namespace SsdMS.ApplicationDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeStamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DepartDuties", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Departments", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Duties", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.InfoUsers", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Professions", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professions", "TimeStamp");
            DropColumn("dbo.InfoUsers", "TimeStamp");
            DropColumn("dbo.Duties", "TimeStamp");
            DropColumn("dbo.Departments", "TimeStamp");
            DropColumn("dbo.DepartDuties", "TimeStamp");
        }
    }
}
