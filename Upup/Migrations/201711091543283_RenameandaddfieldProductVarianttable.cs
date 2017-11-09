namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameandaddfieldProductVarianttable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductCustomProperties", newName: "ProductVariants");
            RenameColumn(table: "dbo.ShipDateSettings", name: "ProductCustomProperties_Id", newName: "ProductVariant_Id");
            RenameIndex(table: "dbo.ShipDateSettings", name: "IX_ProductCustomProperties_Id", newName: "IX_ProductVariant_Id");
            AddColumn("dbo.ProductVariants", "VariantName", c => c.String());
            AddColumn("dbo.ProductVariants", "VariantCode", c => c.String());
            AddColumn("dbo.ProductVariants", "BrandName", c => c.String());
            AddColumn("dbo.ProductVariants", "Origin", c => c.String());
            DropColumn("dbo.ProductVariants", "PropertyCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductVariants", "PropertyCode", c => c.String());
            DropColumn("dbo.ProductVariants", "Origin");
            DropColumn("dbo.ProductVariants", "BrandName");
            DropColumn("dbo.ProductVariants", "VariantCode");
            DropColumn("dbo.ProductVariants", "VariantName");
            RenameIndex(table: "dbo.ShipDateSettings", name: "IX_ProductVariant_Id", newName: "IX_ProductCustomProperties_Id");
            RenameColumn(table: "dbo.ShipDateSettings", name: "ProductVariant_Id", newName: "ProductCustomProperties_Id");
            RenameTable(name: "dbo.ProductVariants", newName: "ProductCustomProperties");
        }
    }
}
