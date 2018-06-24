namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLogTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logs", "CreatedDate");
            DropColumn("dbo.Logs", "CreatedBy");
            DropColumn("dbo.Logs", "ModifiedDate");
            DropColumn("dbo.Logs", "ModifiedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "ModifiedBy", c => c.String());
            AddColumn("dbo.Logs", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Logs", "CreatedBy", c => c.String());
            AddColumn("dbo.Logs", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
