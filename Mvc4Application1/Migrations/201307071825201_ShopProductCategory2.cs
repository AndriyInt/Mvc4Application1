namespace Mvc4Application1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopProductCategory2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ShopCategory_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.ShopCategories", t => t.ShopCategory_CategoryId)
                .Index(t => t.ShopCategory_CategoryId);
            
            CreateTable(
                "dbo.ShopProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsFeatured = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ShopProductShopCategories",
                c => new
                    {
                        ShopProduct_ProductId = c.Int(nullable: false),
                        ShopCategory_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShopProduct_ProductId, t.ShopCategory_CategoryId })
                .ForeignKey("dbo.ShopProducts", t => t.ShopProduct_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ShopCategories", t => t.ShopCategory_CategoryId, cascadeDelete: true)
                .Index(t => t.ShopProduct_ProductId)
                .Index(t => t.ShopCategory_CategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ShopProductShopCategories", new[] { "ShopCategory_CategoryId" });
            DropIndex("dbo.ShopProductShopCategories", new[] { "ShopProduct_ProductId" });
            DropIndex("dbo.ShopCategories", new[] { "ShopCategory_CategoryId" });
            DropForeignKey("dbo.ShopProductShopCategories", "ShopCategory_CategoryId", "dbo.ShopCategories");
            DropForeignKey("dbo.ShopProductShopCategories", "ShopProduct_ProductId", "dbo.ShopProducts");
            DropForeignKey("dbo.ShopCategories", "ShopCategory_CategoryId", "dbo.ShopCategories");
            DropTable("dbo.ShopProductShopCategories");
            DropTable("dbo.ShopProducts");
            DropTable("dbo.ShopCategories");
        }
    }
}
