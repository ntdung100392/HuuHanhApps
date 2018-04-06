namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHomeTown : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "HomeTownId", "dbo.HomeTowns");
            DropIndex("dbo.Suppliers", new[] { "HomeTownId" });
            AddColumn("dbo.Suppliers", "HomeTown", c => c.String());
            DropColumn("dbo.Suppliers", "HomeTownId");
            DropTable("dbo.HomeTowns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HomeTowns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Suppliers", "HomeTownId", c => c.Int(nullable: false));
            DropColumn("dbo.Suppliers", "HomeTown");
            CreateIndex("dbo.Suppliers", "HomeTownId");
            AddForeignKey("dbo.Suppliers", "HomeTownId", "dbo.HomeTowns", "Id", cascadeDelete: true);
        }
    }
}
