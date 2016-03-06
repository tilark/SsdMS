namespace SsdMS.ApplicationDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataSize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentDescrip", c => c.String());
            AlterColumn("dbo.Duties", "DutyName", c => c.String(maxLength: 50));
            AlterColumn("dbo.InfoUsers", "Sex", c => c.String(maxLength: 20));
            AlterColumn("dbo.InfoUsers", "Phone1", c => c.String(maxLength: 30));
            AlterColumn("dbo.InfoUsers", "Phone2", c => c.String(maxLength: 30));
            AlterColumn("dbo.InfoUsers", "Phone3", c => c.String(maxLength: 30));
            AlterColumn("dbo.InfoUsers", "Phone4", c => c.String(maxLength: 30));
            AlterColumn("dbo.InfoUsers", "Phone5", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InfoUsers", "Phone5", c => c.String(maxLength: 11));
            AlterColumn("dbo.InfoUsers", "Phone4", c => c.String(maxLength: 11));
            AlterColumn("dbo.InfoUsers", "Phone3", c => c.String(maxLength: 11));
            AlterColumn("dbo.InfoUsers", "Phone2", c => c.String(maxLength: 11));
            AlterColumn("dbo.InfoUsers", "Phone1", c => c.String(maxLength: 11));
            AlterColumn("dbo.InfoUsers", "Sex", c => c.String(maxLength: 4));
            AlterColumn("dbo.Duties", "DutyName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Departments", "DepartmentDescrip", c => c.String(maxLength: 30));
        }
    }
}
