namespace Capstone.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BvLocations",
                c => new
                    {
                        BvLocationId = c.Int(nullable: false, identity: true),
                        BvStoreNum = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.BvLocationId);
            
            CreateTable(
                "dbo.Charities",
                c => new
                    {
                        CharityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Zip = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        FederalTaxId = c.String(nullable: false),
                        TypeOfCharity = c.String(),
                    })
                .PrimaryKey(t => t.CharityId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormId = c.Int(nullable: false, identity: true),
                        Purpose = c.String(),
                        Contact = c.String(),
                        NewPartner = c.Boolean(nullable: false),
                        Wk1Year = c.Int(nullable: false),
                        Wk2Year = c.Int(nullable: false),
                        Wk3Year = c.Int(nullable: false),
                        Wk1FourGc = c.Int(nullable: false),
                        Wk1FiveGc = c.Int(nullable: false),
                        Wk1SixGc = c.Int(nullable: false),
                        Wk1SevenGc = c.Int(nullable: false),
                        Wk1EightGc = c.Int(nullable: false),
                        Wk2FourGc = c.Int(nullable: false),
                        Wk2FiveGc = c.Int(nullable: false),
                        Wk2SixGc = c.Int(nullable: false),
                        WkSevenGc = c.Int(nullable: false),
                        Wk2EightGc = c.Int(nullable: false),
                        Wk3FourGc = c.Int(nullable: false),
                        Wk3FiveGc = c.Int(nullable: false),
                        Wk3SixGc = c.Int(nullable: false),
                        Wk3SevenGc = c.Int(nullable: false),
                        Wk3EightGc = c.Int(nullable: false),
                        LWkAvgChkFour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LWkAvgChkFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LWkAvgChkSix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LWkAvgChkSeven = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LWkAvgChkEight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Scenario1Gc = c.Int(nullable: false),
                        Scenario2Gc = c.Int(nullable: false),
                        ActualSalesFour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSalesFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSalesSix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSalesSeven = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSalesEight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualGcFour = c.Int(nullable: false),
                        ActualGcFive = c.Int(nullable: false),
                        ActualGcSix = c.Int(nullable: false),
                        ActualGcSeven = c.Int(nullable: false),
                        ActualGcEight = c.Int(nullable: false),
                        PosiDonations = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.FormId);
            
            CreateTable(
                "dbo.PartnershipNights",
                c => new
                    {
                        PartnershipNightId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CheckRequestId = c.Int(nullable: false),
                        Comments = c.String(),
                        CheckRequestFinished = c.Boolean(nullable: false),
                        BeforeTheEventFinished = c.Boolean(nullable: false),
                        AfterTheEventFinished = c.Boolean(nullable: false),
                        BVLocation_BvLocationId = c.Int(nullable: false),
                        Charity_CharityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartnershipNightId)
                .ForeignKey("dbo.BvLocations", t => t.BVLocation_BvLocationId, cascadeDelete: true)
                .ForeignKey("dbo.Charities", t => t.Charity_CharityId, cascadeDelete: true)
                .Index(t => t.BVLocation_BvLocationId)
                .Index(t => t.Charity_CharityId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        UserFName = c.String(nullable: false),
                        UserLName = c.String(nullable: false),
                        Password = c.String(),
                        AccessLevel = c.Int(nullable: false),
                        UserEmail = c.String(),
                        PhoneNumber = c.String(),
                        BvLocation_BvLocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.BvLocations", t => t.BvLocation_BvLocationId, cascadeDelete: true)
                .Index(t => t.BvLocation_BvLocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "BvLocation_BvLocationId", "dbo.BvLocations");
            DropForeignKey("dbo.PartnershipNights", "Charity_CharityId", "dbo.Charities");
            DropForeignKey("dbo.PartnershipNights", "BVLocation_BvLocationId", "dbo.BvLocations");
            DropIndex("dbo.Users", new[] { "BvLocation_BvLocationId" });
            DropIndex("dbo.PartnershipNights", new[] { "Charity_CharityId" });
            DropIndex("dbo.PartnershipNights", new[] { "BVLocation_BvLocationId" });
            DropTable("dbo.Users");
            DropTable("dbo.PartnershipNights");
            DropTable("dbo.Forms");
            DropTable("dbo.Charities");
            DropTable("dbo.BvLocations");
        }
    }
}
