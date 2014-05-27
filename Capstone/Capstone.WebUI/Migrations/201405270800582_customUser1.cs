namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customUser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AccessLevel", c => c.Int());
            AddColumn("dbo.AspNetUsers", "UserEmail", c => c.String());
            AddColumn("dbo.AspNetUsers", "BvLocation_BvLocationId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BvLocation_BvLocationId");
            AddForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId", "dbo.BvLocations", "BvLocationId");
            DropColumn("dbo.AspNetUsers", "test1");
            DropColumn("dbo.AspNetUsers", "test2");
            DropColumn("dbo.AspNetUsers", "test3");
            DropColumn("dbo.AspNetUsers", "test4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "test4", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "test3", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "test2", c => c.Int());
            AddColumn("dbo.AspNetUsers", "test1", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId", "dbo.BvLocations");
            DropIndex("dbo.AspNetUsers", new[] { "BvLocation_BvLocationId" });
            DropColumn("dbo.AspNetUsers", "BvLocation_BvLocationId");
            DropColumn("dbo.AspNetUsers", "UserEmail");
            DropColumn("dbo.AspNetUsers", "AccessLevel");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
