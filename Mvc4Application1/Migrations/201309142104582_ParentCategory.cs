namespace Andriy.Mvc4Application1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopCategories", "ShopCategory_CategoryId", "dbo.ShopCategories");
            DropIndex("dbo.ShopCategories", new[] { "ShopCategory_CategoryId" });
            AddColumn("dbo.ShopCategories", "ParentCategory_CategoryId", c => c.Int());
            AddForeignKey("dbo.ShopCategories", "ParentCategory_CategoryId", "dbo.ShopCategories", "CategoryId");
            CreateIndex("dbo.ShopCategories", "ParentCategory_CategoryId");
            DropColumn("dbo.ShopCategories", "ShopCategory_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShopCategories", "ShopCategory_CategoryId", c => c.Int());
            DropIndex("dbo.ShopCategories", new[] { "ParentCategory_CategoryId" });
            DropForeignKey("dbo.ShopCategories", "ParentCategory_CategoryId", "dbo.ShopCategories");
            DropColumn("dbo.ShopCategories", "ParentCategory_CategoryId");
            CreateIndex("dbo.ShopCategories", "ShopCategory_CategoryId");
            AddForeignKey("dbo.ShopCategories", "ShopCategory_CategoryId", "dbo.ShopCategories", "CategoryId");
        }
    }
}
