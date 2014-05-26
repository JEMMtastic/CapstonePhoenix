namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUserEmailfromUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserEmail", c => c.String());
        }
    }
}
