namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingCustomUserClass5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId1", "dbo.BvLocations");
            DropForeignKey("dbo.AspNetUsers", "test5_CharityId", "dbo.Charities");
            DropIndex("dbo.AspNetUsers", new[] { "BvLocation_BvLocationId1" });
            DropIndex("dbo.AspNetUsers", new[] { "test5_CharityId" });
            DropColumn("dbo.AspNetUsers", "BvLocation_BvLocationId1");
            DropColumn("dbo.AspNetUsers", "test5_CharityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "test5_CharityId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "BvLocation_BvLocationId1", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "test5_CharityId");
            CreateIndex("dbo.AspNetUsers", "BvLocation_BvLocationId1");
            AddForeignKey("dbo.AspNetUsers", "test5_CharityId", "dbo.Charities", "CharityId");
            AddForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId1", "dbo.BvLocations", "BvLocationId");
        }
    }
}
