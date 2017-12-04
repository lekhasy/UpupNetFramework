namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Total_Amount_And_Price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseOrderDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PurchaseOrderDetails", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrderDetails", "TotalAmount");
            DropColumn("dbo.PurchaseOrderDetails", "Price");
            DropColumn("dbo.PurchaseOrders", "IsDeleted");
        }
    }
}
