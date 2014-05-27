namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingCustomUserClass51 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId", "dbo.BvLocations");
            DropIndex("dbo.AspNetUsers", new[] { "BvLocation_BvLocationId" });
            DropColumn("dbo.AspNetUsers", "BvLocation_BvLocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BvLocation_BvLocationId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "LName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FName", c => c.String());
            CreateIndex("dbo.AspNetUsers", "BvLocation_BvLocationId");
            AddForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId", "dbo.BvLocations", "BvLocationId", cascadeDelete: true);
        }
    }
}
