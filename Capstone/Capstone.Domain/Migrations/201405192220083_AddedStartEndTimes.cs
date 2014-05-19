namespace Capstone.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartEndTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartnershipNights", "StartTime", c => c.String(nullable: false));
            AddColumn("dbo.PartnershipNights", "EndTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PartnershipNights", "EndTime");
            DropColumn("dbo.PartnershipNights", "StartTime");
        }
    }
}
