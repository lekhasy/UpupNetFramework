namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replace_productId_by_nav_prop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductVariants", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductVariants", new[] { "ProductId" });
            RenameColumn(table: "dbo.ProductVariants", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.ProductVariants", "Product_Id", c => c.Long());
            CreateIndex("dbo.ProductVariants", "Product_Id");
            AddForeignKey("dbo.ProductVariants", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductVariants", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductVariants", new[] { "Product_Id" });
            AlterColumn("dbo.ProductVariants", "Product_Id", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.ProductVariants", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.ProductVariants", "ProductId");
            AddForeignKey("dbo.ProductVariants", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
