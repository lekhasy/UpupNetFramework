namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Move_Cad_To_Prod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Cad2dUrl", c => c.String());
            AddColumn("dbo.Products", "Cad3dUrl", c => c.String());
            DropColumn("dbo.ProductVariants", "Cad2dUrl");
            DropColumn("dbo.ProductVariants", "Cad3dUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductVariants", "Cad3dUrl", c => c.String());
            AddColumn("dbo.ProductVariants", "Cad2dUrl", c => c.String());
            DropColumn("dbo.Products", "Cad3dUrl");
            DropColumn("dbo.Products", "Cad2dUrl");
        }
    }
}
