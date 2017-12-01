namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Consolidate_Quantity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCarts", "Quantity", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCarts", "Quantity", c => c.Int(nullable: false));
        }
    }
}
