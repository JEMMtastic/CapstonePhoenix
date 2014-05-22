namespace Capstone.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propNameChng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartnershipNights", "Start", c => c.String(nullable: false));
            AddColumn("dbo.PartnershipNights", "End", c => c.String(nullable: false));
            DropColumn("dbo.PartnershipNights", "StartTime");
            DropColumn("dbo.PartnershipNights", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartnershipNights", "EndTime", c => c.String(nullable: false));
            AddColumn("dbo.PartnershipNights", "StartTime", c => c.String(nullable: false));
            DropColumn("dbo.PartnershipNights", "End");
            DropColumn("dbo.PartnershipNights", "Start");
        }
    }
}
