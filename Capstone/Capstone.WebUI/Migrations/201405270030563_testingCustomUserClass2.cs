namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingCustomUserClass2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropColumn("dbo.AspNetUsers", "FName1");
            DropColumn("dbo.AspNetUsers", "LName1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LName1", c => c.String());
            AddColumn("dbo.AspNetUsers", "FName1", c => c.String());
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
