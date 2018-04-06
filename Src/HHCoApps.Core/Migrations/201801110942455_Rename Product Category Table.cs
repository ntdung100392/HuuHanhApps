namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProductCategoryTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductCategories", newName: "Categories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Categories", newName: "ProductCategories");
        }
    }
}
