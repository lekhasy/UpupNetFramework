namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Temp_Po_Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TempPoName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TempPoName");
        }
    }
}
