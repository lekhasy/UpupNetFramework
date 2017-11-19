namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Purchase_Order_And_PO_Detail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        ProductVariant_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariant_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.ProductVariant_Id);
            
            AddColumn("dbo.PurchaseOrderDetails", "ShipDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrderDetails", "State", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseOrders", "ReceiveDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "ReceiveDate", c => c.DateTime());
            DropForeignKey("dbo.ProductCarts", "ProductVariant_Id", "dbo.ProductVariants");
            DropForeignKey("dbo.ProductCarts", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProductCarts", new[] { "ProductVariant_Id" });
            DropIndex("dbo.ProductCarts", new[] { "Customer_Id" });
            DropColumn("dbo.PurchaseOrderDetails", "State");
            DropColumn("dbo.PurchaseOrderDetails", "ShipDate");
            DropTable("dbo.ProductCarts");
        }
    }
}
