namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeyProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LastAccess", c => c.DateTime());
            CreateIndex("dbo.Products", "ProductCategoryId");
            CreateIndex("dbo.Products", "SupplierId");
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            AlterColumn("dbo.Users", "LastAccess", c => c.DateTime(nullable: false));
        }
    }
}
