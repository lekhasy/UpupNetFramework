namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Customer_Name : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseOrders", "CustomerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "CustomerName", c => c.String());
        }
    }
}
