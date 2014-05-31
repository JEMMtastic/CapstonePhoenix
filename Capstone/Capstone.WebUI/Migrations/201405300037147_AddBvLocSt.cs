namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBvLocSt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BvLocations", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BvLocations", "State");
        }
    }
}
