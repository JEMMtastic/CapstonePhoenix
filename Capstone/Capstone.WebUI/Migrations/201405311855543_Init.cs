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
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.BvLocationId);
            
            CreateTable(
                "dbo.PartnershipNights",
                c => new
                    {
                        PartnershipNightId = c.Int(nullable: false, identity: true),
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
                        State = c.String(),
                        CharityContactNm = c.String(),
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
                        NameOnCheck = c.String(),
                        Purpose = c.String(),
                        ContactName = c.String(),
                        OrganizationMailingAddress = c.String(),
                        OrganizationMailingCity = c.String(),
                        OrganizationMailingState = c.String(),
                        OrganizationMailingZip = c.String(),
                        OrganizationPhone = c.String(),
                        FederalTaxID = c.String(),
                        NewPartner = c.Boolean(nullable: false),
                        HostingRestaurant = c.String(),
                        WeekDayOfPartnership = c.String(),
                        DateOfPartnership = c.DateTime(nullable: false),
                        Week1Date = c.DateTime(nullable: false),
                        Week2Date = c.DateTime(nullable: false),
                        Week3Date = c.DateTime(nullable: false),
                        Week1_45_GuestCount = c.Int(nullable: false),
                        Week1_56_GuestCount = c.Int(nullable: false),
                        Week1_67_GuestCount = c.Int(nullable: false),
                        Week1_78_GuestCount = c.Int(nullable: false),
                        Week1_89_GuestCount = c.Int(nullable: false),
                        Week2_45_GuestCount = c.Int(nullable: false),
                        Week2_56_GuestCount = c.Int(nullable: false),
                        Week2_67_GuestCount = c.Int(nullable: false),
                        Week2_78_GuestCount = c.Int(nullable: false),
                        Week2_89_GuestCount = c.Int(nullable: false),
                        Week3_45_GuestCount = c.Int(nullable: false),
                        Week3_56_GuestCount = c.Int(nullable: false),
                        Week3_67_GuestCount = c.Int(nullable: false),
                        Week3_78_GuestCount = c.Int(nullable: false),
                        Week3_89_GuestCount = c.Int(nullable: false),
                        LastWeekAverageCheck_45 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastWeekAverageCheck_56 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastWeekAverageCheck_67 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastWeekAverageCheck_78 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastWeekAverageCheck_89 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week1_45_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week1_56_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week1_67_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week1_78_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week1_89_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week2_45_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week2_56_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week2_67_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week2_78_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week2_89_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week3_45_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week3_56_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week3_67_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week3_78_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week3_89_AdjustedSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Average_45_Sales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Average_56_Sales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Average_67_Sales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Average_78_Sales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Average_89_Sales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Average_45_GuestCount = c.Int(nullable: false),
                        Average_56_GuestCount = c.Int(nullable: false),
                        Average_67_GuestCount = c.Int(nullable: false),
                        Average_78_GuestCount = c.Int(nullable: false),
                        Average_89_GuestCount = c.Int(nullable: false),
                        Week1_AdjustedSalesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week2_AdjustedSalesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week3_AdjustedSalesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Average_AdjustedSalesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Week1_GuestCountTotal = c.Int(nullable: false),
                        Week2_GuestCountTotal = c.Int(nullable: false),
                        Week3_GuestCountTotal = c.Int(nullable: false),
                        Average_GuestCountTotal = c.Int(nullable: false),
                        LastWeekAverageCheckTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Scenario1_GuestCount = c.Int(nullable: false),
                        Scenario2_GuestCount = c.Int(nullable: false),
                        Scenario1_EstimatedGuestCount = c.Int(nullable: false),
                        Scenario2_EstimatedGuestCount = c.Int(nullable: false),
                        Scenario1_ThreeWeekAverageGuestCount = c.Int(nullable: false),
                        Scenario2_ThreeWeekAverageGuestCount = c.Int(nullable: false),
                        Scenario1_TargetedGuestCount = c.Int(nullable: false),
                        Scenario2_TargetedGuestCount = c.Int(nullable: false),
                        Scenario1_EstimatedDonation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Scenario2_EstimatedDonation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSales_45 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSales_56 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSales_67 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSales_78 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSales_89 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualGuestCount_45 = c.Int(nullable: false),
                        ActualGuestCount_56 = c.Int(nullable: false),
                        ActualGuestCount_67 = c.Int(nullable: false),
                        ActualGuestCount_78 = c.Int(nullable: false),
                        ActualGuestCount_89 = c.Int(nullable: false),
                        PosiDonations = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        ActualAverageCheck_45 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualAverageCheck_56 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualAverageCheck_67 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualAverageCheck_78 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualAverageCheck_89 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualSalesTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualGuestCountTotal = c.Int(nullable: false),
                        ActualAverageCheckTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TenPercentDonation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesContribution_3WeekAverage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesContribution_Actual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesContribution_Difference = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesContribution_Donation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesContribution_SalesContribution = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GuestCountContribution_3WeekAverage = c.Int(nullable: false),
                        GuestCountContribution_ActualNumber = c.Int(nullable: false),
                        GuestCountContribution_GCCountribution = c.Int(nullable: false),
                        MailPartnershipCheckToBV = c.Boolean(nullable: false),
                        Donations10PercentOfSalesToGL7700 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GLCode7700 = c.String(),
                        DonationsTakenOnThePosiRegisterCodeToGL2005 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GLCode2005 = c.String(),
                        TotalDonation = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        FirstName = c.String(),
                        LastName = c.String(),
                        AccessLevel = c.Int(),
                        UserEmail = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        BvLocation_BvLocationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BvLocations", t => t.BvLocation_BvLocationId)
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
