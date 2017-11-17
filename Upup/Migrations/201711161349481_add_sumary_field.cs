namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_sumary_field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Sumary", c => c.String());
            AddColumn("dbo.Posts", "Sumary_en", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Sumary_en");
            DropColumn("dbo.Posts", "Sumary");
        }
    }
}
