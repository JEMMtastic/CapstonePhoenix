namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingCustomUserClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId", "dbo.BvLocations");
            RenameColumn(table: "dbo.AspNetUsers", name: "FName", newName: "FName1");
            RenameColumn(table: "dbo.AspNetUsers", name: "LName", newName: "LName1");
            AddColumn("dbo.AspNetUsers", "test1", c => c.String());
            AddColumn("dbo.AspNetUsers", "test2", c => c.Int());
            AddColumn("dbo.AspNetUsers", "test3", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "test4", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "BvLocation_BvLocationId1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "test5_CharityId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BvLocation_BvLocationId1");
            CreateIndex("dbo.AspNetUsers", "test5_CharityId");
            AddForeignKey("dbo.AspNetUsers", "test5_CharityId", "dbo.Charities", "CharityId");
            AddForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId1", "dbo.BvLocations", "BvLocationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId1", "dbo.BvLocations");
            DropForeignKey("dbo.AspNetUsers", "test5_CharityId", "dbo.Charities");
            DropIndex("dbo.AspNetUsers", new[] { "test5_CharityId" });
            DropIndex("dbo.AspNetUsers", new[] { "BvLocation_BvLocationId1" });
            DropColumn("dbo.AspNetUsers", "test5_CharityId");
            DropColumn("dbo.AspNetUsers", "BvLocation_BvLocationId1");
            DropColumn("dbo.AspNetUsers", "test4");
            DropColumn("dbo.AspNetUsers", "test3");
            DropColumn("dbo.AspNetUsers", "test2");
            DropColumn("dbo.AspNetUsers", "test1");
            RenameColumn(table: "dbo.AspNetUsers", name: "LName1", newName: "LName");
            RenameColumn(table: "dbo.AspNetUsers", name: "FName1", newName: "FName");
            AddForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId", "dbo.BvLocations", "BvLocationId", cascadeDelete: true);
        }
    }
}
