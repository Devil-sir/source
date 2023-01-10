namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodProducts", "FPCategoryId", "dbo.FoodProducts");
            AddForeignKey("dbo.FoodProducts", "FPCategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodProducts", "FPCategoryId", "dbo.Categories");
            AddForeignKey("dbo.FoodProducts", "FPCategoryId", "dbo.FoodProducts", "FoodProductId");
        }
    }
}
