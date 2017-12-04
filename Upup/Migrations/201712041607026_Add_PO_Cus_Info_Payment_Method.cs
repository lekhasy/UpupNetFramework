namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PO_Cus_Info_Payment_Method : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "PaymentMethod", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "CustomerName", c => c.String());
            AddColumn("dbo.PurchaseOrders", "CustomerAddress", c => c.String());
            AddColumn("dbo.PurchaseOrders", "CustomerPhone", c => c.String());
            AddColumn("dbo.PurchaseOrders", "CustomerEmail", c => c.String());
            AddColumn("dbo.PurchaseOrders", "CustomerWebsite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "CustomerWebsite");
            DropColumn("dbo.PurchaseOrders", "CustomerEmail");
            DropColumn("dbo.PurchaseOrders", "CustomerPhone");
            DropColumn("dbo.PurchaseOrders", "CustomerAddress");
            DropColumn("dbo.PurchaseOrders", "CustomerName");
            DropColumn("dbo.PurchaseOrders", "PaymentMethod");
        }
    }
}
