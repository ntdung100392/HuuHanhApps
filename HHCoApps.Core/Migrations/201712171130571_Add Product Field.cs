namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        DOB = c.DateTime(),
                        HomeTown = c.Int(nullable: false),
                        IsOrganization = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        TaxCode = c.String(),
                        DirectorName = c.String(),
                        HomeTown = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Name = c.String(),
                        ProductCategoryId = c.Int(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssuedDate = c.DateTime(nullable: false),
                        ExpiredDate = c.DateTime(),
                        Stock = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserCode", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "MiddleName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            DropColumn("dbo.Users", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FullName", c => c.String());
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "MiddleName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "UserCode");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
        }
    }
}
