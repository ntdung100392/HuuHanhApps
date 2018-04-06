namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProductCategorytoCategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "ProductCategoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_ProductCategoryId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_ProductCategoryId");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "ProductCategoryId");
        }
    }
}
