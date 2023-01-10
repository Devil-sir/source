namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thridConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoodProductId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.FoodProducts", t => t.FoodProductId, cascadeDelete: true)
                .Index(t => t.FoodProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "FoodProductId", "dbo.FoodProducts");
            DropIndex("dbo.Purchases", new[] { "FoodProductId" });
            DropTable("dbo.Purchases");
        }
    }
}
