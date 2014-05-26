namespace Capstone.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartnershipNights", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PartnershipNights", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PartnershipNights", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartnershipNights", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.PartnershipNights", "EndDate");
            DropColumn("dbo.PartnershipNights", "StartDate");
        }
    }
}
