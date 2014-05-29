namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PNtCleanUp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PartnershipNights", "EventLength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartnershipNights", "EventLength", c => c.Int(nullable: false));
        }
    }
}
