namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrderDetails", "Quantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrderDetails", "Quantity");
        }
    }
}
