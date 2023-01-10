namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryPhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.FoodProducts",
                c => new
                    {
                        FoodProductId = c.Int(nullable: false, identity: true),
                        FoodProductName = c.String(),
                        FPCategoryId = c.Int(nullable: false),
                        FoodProductDescription = c.String(),
                        FoodProductPrice = c.Single(nullable: false),
                        FoodProductPhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.FoodProductId)
                .ForeignKey("dbo.FoodProducts", t => t.FPCategoryId)
                .Index(t => t.FPCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodProducts", "FPCategoryId", "dbo.FoodProducts");
            DropIndex("dbo.FoodProducts", new[] { "FPCategoryId" });
            DropTable("dbo.FoodProducts");
            DropTable("dbo.Categories");
        }
    }
}
