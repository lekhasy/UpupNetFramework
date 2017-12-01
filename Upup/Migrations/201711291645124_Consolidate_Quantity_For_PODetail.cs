namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Consolidate_Quantity_For_PODetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseOrderDetails", "Quantity", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseOrderDetails", "Quantity", c => c.Double(nullable: false));
        }
    }
}
