namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Identity_Field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AutoIncrementCode", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AutoIncrementCode");
        }
    }
}
