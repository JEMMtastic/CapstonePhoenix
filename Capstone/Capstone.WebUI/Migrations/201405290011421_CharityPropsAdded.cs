namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharityPropsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charities", "State", c => c.String());
            AddColumn("dbo.Charities", "CharityContactNm", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Charities", "CharityContactNm");
            DropColumn("dbo.Charities", "State");
        }
    }
}
