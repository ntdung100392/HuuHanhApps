namespace HHCoApps.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHomeTown : DbMigration
    {
        public override void Up()
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
            AddColumn("dbo.Suppliers", "Note", c => c.String());
            CreateIndex("dbo.Suppliers", "HomeTownId");
            AddForeignKey("dbo.Suppliers", "HomeTownId", "dbo.HomeTowns", "Id", cascadeDelete: true);
            DropColumn("dbo.Suppliers", "HomeTown");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "HomeTown", c => c.Int(nullable: false));
            DropForeignKey("dbo.Suppliers", "HomeTownId", "dbo.HomeTowns");
            DropIndex("dbo.Suppliers", new[] { "HomeTownId" });
            DropColumn("dbo.Suppliers", "Note");
            DropColumn("dbo.Suppliers", "HomeTownId");
            DropTable("dbo.HomeTowns");
        }
    }
}
