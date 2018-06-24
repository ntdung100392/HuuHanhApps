namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Status");
        }
    }
}
