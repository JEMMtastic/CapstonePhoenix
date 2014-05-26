namespace Capstone.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartnershipNightChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartnershipNights", "EventLength", c => c.Int(nullable: false));
            DropColumn("dbo.PartnershipNights", "Start");
            DropColumn("dbo.PartnershipNights", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartnershipNights", "End", c => c.String(nullable: false));
            AddColumn("dbo.PartnershipNights", "Start", c => c.String(nullable: false));
            DropColumn("dbo.PartnershipNights", "EventLength");
        }
    }
}
