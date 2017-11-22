namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_LinkGuid_To_Product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "LinkGuide", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "LinkGuide");
        }
    }
}
