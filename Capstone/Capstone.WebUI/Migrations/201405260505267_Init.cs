namespace Capstone.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                "dbo.PartnershipNights",
                c => new
                    {
                        PartnershipNightId = c.Int(nullable: false, identity: true),
                        EventLength = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FName = c.String(),
                        LName = c.String(),
                        UserEmail = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        BvLocation_BvLocationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BvLocations", t => t.BvLocation_BvLocationId, cascadeDelete: true)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.BvLocation_BvLocationId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BvLocation_BvLocationId", "dbo.BvLocations");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PartnershipNights", "Charity_CharityId", "dbo.Charities");
            DropForeignKey("dbo.PartnershipNights", "BVLocation_BvLocationId", "dbo.BvLocations");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "BvLocation_BvLocationId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PartnershipNights", new[] { "Charity_CharityId" });
            DropIndex("dbo.PartnershipNights", new[] { "BVLocation_BvLocationId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Forms");
            DropTable("dbo.Charities");
            DropTable("dbo.PartnershipNights");
            DropTable("dbo.BvLocations");
        }
    }
}
