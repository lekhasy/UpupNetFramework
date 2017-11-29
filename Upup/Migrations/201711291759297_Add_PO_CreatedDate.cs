namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PO_CreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "CreatedDate");
        }
    }
}
