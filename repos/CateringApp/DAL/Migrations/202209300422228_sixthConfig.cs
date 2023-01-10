namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixthConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        pId = c.Int(nullable: false),
                        categId = c.Int(nullable: false),
                        qty = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Categories", t => t.categId, cascadeDelete: false)
                .ForeignKey("dbo.FoodProducts", t => t.pId, cascadeDelete: false)
                .Index(t => t.pId)
                .Index(t => t.categId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "pId", "dbo.FoodProducts");
            DropForeignKey("dbo.Inventories", "categId", "dbo.Categories");
            DropIndex("dbo.Inventories", new[] { "categId" });
            DropIndex("dbo.Inventories", new[] { "pId" });
            DropTable("dbo.Inventories");
        }
    }
}
