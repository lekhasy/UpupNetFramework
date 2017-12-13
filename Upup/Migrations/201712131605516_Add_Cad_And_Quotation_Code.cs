namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Cad_And_Quotation_Code : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductVariants", "Cad2dUrl", c => c.String());
            AddColumn("dbo.ProductVariants", "Cad3dUrl", c => c.String());
            AddColumn("dbo.PurchaseOrders", "QuotationCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "QuotationCode");
            DropColumn("dbo.ProductVariants", "Cad3dUrl");
            DropColumn("dbo.ProductVariants", "Cad2dUrl");
        }
    }
}
