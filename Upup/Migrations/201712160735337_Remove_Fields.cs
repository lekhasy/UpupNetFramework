namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Fields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Code");
            DropColumn("dbo.Products", "Cad2dUrl");
            DropColumn("dbo.Products", "Cad3dUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Cad3dUrl", c => c.String());
            AddColumn("dbo.Products", "Cad2dUrl", c => c.String());
            AddColumn("dbo.Products", "Code", c => c.String());
        }
    }
}
