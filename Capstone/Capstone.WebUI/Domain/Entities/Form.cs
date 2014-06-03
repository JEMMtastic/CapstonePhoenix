using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.WebUI.Domain.Entities
{
    public class Form
    {
        [HiddenInput(DisplayValue = false)]
        public int FormId { get; set; }


        //Properties

        #region Section 0 - Organization Information

        //All manually entered
        //**************************************************************************************
        public string NameOnCheck { get; set; } // "Name on check" - Comes from PartnershipNight.Charity.Name
        public string Purpose { get; set; }
        public string ContactName { get; set; } // TODO: Add the contact to the partnership
        public string OrganizationMailingAddress { get; set; }  // "Organization mailing address" - Comes from PartnershipNight.Charity.Address, City, Zip, State (?)
        public string OrganizationMailingCity { get; set; }
        public string OrganizationMailingState { get; set; }
        public string OrganizationMailingZip { get; set; }
        public string OrganizationPhone { get; set; } // "Telephone number" - Comes from PartnershipNight.Charity.Phone
        public string FederalTaxID { get; set; }// "Federal tax I.D. number - PartnershipNight.Charity.FederalTaxId

        public bool NewPartner { get; set; }

        public int HostingRestaurant { get; set; }// "Hosting restaurant" - PartnershipNight.BvLocation.BvStoreNum

        public string WeekDayOfPartnership { get; set; }// "Week day of Partnership" - PartnershipNight.Date

        [Required(ErrorMessage = "Date must be from somewhere in the 1800s to over 9000")]
        [Range(typeof(DateTime), "1/2/1800", "1/1/9001", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPartnership { get; set; }// "Date of Partnership" - PartnershipNight.Date 

        #endregion

        
        #region Section 1 - Actual Sales Information from Prior Year - 3 Weeks

        //Manually entered
        //**************************************************************************************

        // Prior Year Week X
        [Required(ErrorMessage = "Date must be from somewhere in the 1800s to over 9000")]
        [Range(typeof(DateTime), "1/2/1800", "1/1/9001", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Week1Date { get; set; }

        [Required(ErrorMessage = "Date must be from somewhere in the 1800s to over 9000")]
        [Range(typeof(DateTime), "1/2/1800", "1/1/9001", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Week2Date { get; set; }

        [Required(ErrorMessage = "Date must be from somewhere in the 1800s to over 9000")]
        [Range(typeof(DateTime), "1/2/1800", "1/1/9001", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Week3Date { get; set; }

        // Week 1 Hours x-x Guest Count
        public int Week1_45_GuestCount { get; set; }
        public int Week1_56_GuestCount { get; set; }
        public int Week1_67_GuestCount { get; set; }
        public int Week1_78_GuestCount { get; set; }
        public int Week1_89_GuestCount { get; set; }

        // Week 2 Hours x-x Guest Count
        public int Week2_45_GuestCount { get; set; }
        public int Week2_56_GuestCount { get; set; }
        public int Week2_67_GuestCount { get; set; }
        public int Week2_78_GuestCount { get; set; }
        public int Week2_89_GuestCount { get; set; }

        // Week 3 Hours x-x Guest Count
        public int Week3_45_GuestCount { get; set; }
        public int Week3_56_GuestCount { get; set; }
        public int Week3_67_GuestCount { get; set; }
        public int Week3_78_GuestCount { get; set; }
        public int Week3_89_GuestCount { get; set; }

        // Last week average check for hour X
        public double LastWeekAverageCheck_45 { get; set; }
        public double LastWeekAverageCheck_56 { get; set; }
        public double LastWeekAverageCheck_67 { get; set; }
        public double LastWeekAverageCheck_78 { get; set; }
        public double LastWeekAverageCheck_89 { get; set; }


        //Calculated
        //**************************************************************************************
        // Week 1 Hours x-x Adjusted Sales
        public double Week1_45_AdjustedSales { get; set; }
        public double Week1_56_AdjustedSales { get; set; }
        public double Week1_67_AdjustedSales { get; set; }
        public double Week1_78_AdjustedSales { get; set; }
        public double Week1_89_AdjustedSales { get; set; }

        // Week 2 Hours x-x Adjusted Sales
        public double Week2_45_AdjustedSales { get; set; }
        public double Week2_56_AdjustedSales { get; set; }
        public double Week2_67_AdjustedSales { get; set; }
        public double Week2_78_AdjustedSales { get; set; }
        public double Week2_89_AdjustedSales { get; set; }

        // Week 3 Hours x-x Adjusted Sales 
        public double Week3_45_AdjustedSales { get; set; }
        public double Week3_56_AdjustedSales { get; set; }
        public double Week3_67_AdjustedSales { get; set; }
        public double Week3_78_AdjustedSales { get; set; }
        public double Week3_89_AdjustedSales { get; set; }

        // Average Hours x-x Sales
        public double Average_45_Sales { get; set; }
        public double Average_56_Sales { get; set; }
        public double Average_67_Sales { get; set; }
        public double Average_78_Sales { get; set; }
        public double Average_89_Sales { get; set; }
       

        // Average Hours x-x Guest Count
        public double Average_45_GuestCount { get; set; }
        public double Average_56_GuestCount { get; set; }
        public double Average_67_GuestCount { get; set; }
        public double Average_78_GuestCount { get; set; }
        public double Average_89_GuestCount { get; set; }

        //totals
        public double Week1_AdjustedSalesTotal { get; set; }
        public double Week2_AdjustedSalesTotal { get; set; }
        public double Week3_AdjustedSalesTotal { get; set; }
        public double Average_SalesTotal { get; set; }
        public int Week1_GuestCountTotal { get; set; }
        public int Week2_GuestCountTotal { get; set; }
        public int Week3_GuestCountTotal { get; set; }
        public double Average_GuestCountTotal { get; set; }

        public double LastWeekAverageCheckTotal { get; set; }


        #endregion


        #region Section 2 - Scenario Donation Based on Projections

        //Manually entered
        //**************************************************************************************
        public int Scenario1_GuestCountInvited { get; set; }
        public int Scenario2_GuestCountInvited { get; set; } 


        //Calculated
        //**************************************************************************************
        public double Scenario1_EstimatedGuestCount { get; set; }
        public double Scenario2_EstimatedGuestCount { get; set; }

        public double Scenario1_ThreeWeekAverageGuestCount { get; set; }
        public double Scenario2_ThreeWeekAverageGuestCount { get; set; }

        public double Scenario1_TargetedGuestCount { get; set; }
        public double Scenario2_TargetedGuestCount { get; set; }

        public double Scenario1_EstimatedDonation { get; set; }
        public double Scenario2_EstimatedDonation { get; set; }

        #endregion


        #region Section 3 - Day of Partnership - Actual Sales & Guest Count Results Per PosiTouch

        //Manually entered
        //**************************************************************************************
        public double ActualSales_45 { get; set; }
        public double ActualSales_56 { get; set; }
        public double ActualSales_67 { get; set; }
        public double ActualSales_78 { get; set; }
        public double ActualSales_89 { get; set; }

        public int ActualGuestCount_45 { get; set; }
        public int ActualGuestCount_56 { get; set; }
        public int ActualGuestCount_67 { get; set; }
        public int ActualGuestCount_78 { get; set; }
        public int ActualGuestCount_89 { get; set; }
   
        public double PosiDonations { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        //Calculated
        //**************************************************************************************
        public double ActualAverageCheck_45 { get; set; }
        public double ActualAverageCheck_56 { get; set; }
        public double ActualAverageCheck_67 { get; set; }
        public double ActualAverageCheck_78 { get; set; }
        public double ActualAverageCheck_89 { get; set; }

        public double ActualSalesTotal { get; set; }
        public int ActualGuestCountTotal { get; set; }
        public double ActualAverageCheckTotal { get; set; }

        public double TenPercentDonation { get; set; }


        #endregion


        #region Section 4 - Sales & Guest Count Contribution Calculation

        //All Calculated
        //**************************************************************************************
        public double SalesContribution_3WeekAverage { get; set; }
        public double SalesContribution_Actual { get; set; }
        public double SalesContribution_Difference { get; set; }
        public double SalesContribution_Donation { get; set; }
        public double SalesContribution_SalesContribution { get; set; }

        public double GuestCountContribution_3WeekAverage { get; set; }
        public double GuestCountContribution_ActualNumber { get; set; }
        public double GuestCountContribution_GCCountribution { get; set; }

        #endregion


        #region Section 5 - Donation Check Request

        //Manually entered
        //**************************************************************************************
        public bool MailPartnershipCheckToBV { get; set; } //if true, use bv address; if false, use charity address

        //Calculated
        //**************************************************************************************
        public double Donations10PercentOfSalesToGL7700 { get; set; }
        public int GLCode7700 { get; set; }
        public double DonationsTakenOnThePosiRegisterCodeToGL2005{ get; set; }
        public int GLCode2005 { get; set; }
        public double TotalDonation { get; set; }

        #endregion



        //Calc methods

        #region Calculate Section 1

        public void CalculateSection1() 
        { 
            Week1_45_AdjustedSales = Week1_45_GuestCount * LastWeekAverageCheck_45;
            Week1_56_AdjustedSales = Week1_56_GuestCount * LastWeekAverageCheck_56;
            Week1_67_AdjustedSales = Week1_67_GuestCount * LastWeekAverageCheck_67;
            Week1_78_AdjustedSales = Week1_78_GuestCount * LastWeekAverageCheck_78;
            Week1_89_AdjustedSales = Week1_89_GuestCount * LastWeekAverageCheck_89;

            Week2_45_AdjustedSales = Week2_45_GuestCount * LastWeekAverageCheck_45;
            Week2_56_AdjustedSales = Week2_56_GuestCount * LastWeekAverageCheck_56;
            Week2_67_AdjustedSales = Week2_67_GuestCount * LastWeekAverageCheck_67;
            Week2_78_AdjustedSales = Week2_78_GuestCount * LastWeekAverageCheck_78;
            Week2_89_AdjustedSales = Week2_89_GuestCount * LastWeekAverageCheck_89;

            Week3_45_AdjustedSales = Week3_45_GuestCount * LastWeekAverageCheck_45;
            Week3_56_AdjustedSales = Week3_56_GuestCount * LastWeekAverageCheck_56;
            Week3_67_AdjustedSales = Week3_67_GuestCount * LastWeekAverageCheck_67;
            Week3_78_AdjustedSales = Week3_78_GuestCount * LastWeekAverageCheck_78;
            Week3_89_AdjustedSales = Week3_89_GuestCount * LastWeekAverageCheck_89;

            Average_45_Sales = (Week1_45_AdjustedSales + Week2_45_AdjustedSales + Week3_45_AdjustedSales)/3;
            Average_56_Sales = (Week1_56_AdjustedSales + Week2_56_AdjustedSales + Week3_56_AdjustedSales)/3; 
            Average_67_Sales = (Week1_67_AdjustedSales + Week2_67_AdjustedSales + Week3_67_AdjustedSales)/3; 
            Average_78_Sales = (Week1_78_AdjustedSales + Week2_78_AdjustedSales + Week3_78_AdjustedSales)/3; 
            Average_89_Sales = (Week1_89_AdjustedSales + Week2_89_AdjustedSales + Week3_89_AdjustedSales)/3; 

            Average_45_GuestCount = (Week1_45_GuestCount + Week2_45_GuestCount + Week3_45_GuestCount)/3;
            Average_56_GuestCount = (Week1_56_GuestCount + Week2_56_GuestCount + Week3_56_GuestCount)/3;
            Average_67_GuestCount = (Week1_67_GuestCount + Week2_67_GuestCount + Week3_67_GuestCount)/3;
            Average_78_GuestCount = (Week1_78_GuestCount + Week2_78_GuestCount + Week3_78_GuestCount)/3;
            Average_89_GuestCount = (Week1_89_GuestCount + Week2_89_GuestCount + Week3_89_GuestCount)/3;

            Week1_45_AdjustedSales = Math.Round(Week1_45_AdjustedSales, 2);
            Week1_56_AdjustedSales = Math.Round(Week1_56_AdjustedSales, 2);
            Week1_67_AdjustedSales = Math.Round(Week1_67_AdjustedSales, 2);
            Week1_78_AdjustedSales = Math.Round(Week1_78_AdjustedSales, 2);
            Week1_89_AdjustedSales = Math.Round(Week1_89_AdjustedSales, 2);

            Week2_45_AdjustedSales = Math.Round(Week2_45_AdjustedSales, 2);
            Week2_56_AdjustedSales = Math.Round(Week2_56_AdjustedSales, 2);
            Week2_67_AdjustedSales = Math.Round(Week2_67_AdjustedSales, 2);
            Week2_78_AdjustedSales = Math.Round(Week2_78_AdjustedSales, 2);
            Week2_89_AdjustedSales = Math.Round(Week2_89_AdjustedSales, 2);

            Week3_45_AdjustedSales = Math.Round(Week3_45_AdjustedSales, 2);
            Week3_56_AdjustedSales = Math.Round(Week3_56_AdjustedSales, 2);
            Week3_67_AdjustedSales = Math.Round(Week3_67_AdjustedSales, 2);
            Week3_78_AdjustedSales = Math.Round(Week3_78_AdjustedSales, 2);
            Week3_89_AdjustedSales = Math.Round(Week3_89_AdjustedSales, 2);

            Average_45_Sales = Math.Round(Average_45_Sales, 2);
            Average_56_Sales = Math.Round(Average_56_Sales, 2);
            Average_67_Sales = Math.Round(Average_67_Sales, 2);
            Average_78_Sales = Math.Round(Average_78_Sales, 2);
            Average_89_Sales = Math.Round(Average_89_Sales, 2);

            Average_45_GuestCount = Math.Round(Average_45_GuestCount, 2);
            Average_56_GuestCount = Math.Round(Average_56_GuestCount, 2);
            Average_67_GuestCount = Math.Round(Average_67_GuestCount, 2);
            Average_78_GuestCount = Math.Round(Average_78_GuestCount, 2);
            Average_89_GuestCount = Math.Round(Average_89_GuestCount, 2);


            Week1_AdjustedSalesTotal = Week1_45_AdjustedSales + Week1_56_AdjustedSales + Week1_67_AdjustedSales + Week1_78_AdjustedSales + Week1_89_AdjustedSales;
            Week2_AdjustedSalesTotal = Week2_45_AdjustedSales + Week2_56_AdjustedSales + Week2_67_AdjustedSales + Week2_78_AdjustedSales + Week2_89_AdjustedSales; 
            Week3_AdjustedSalesTotal = Week3_45_AdjustedSales + Week3_56_AdjustedSales + Week3_67_AdjustedSales + Week3_78_AdjustedSales + Week3_89_AdjustedSales; 
            Average_SalesTotal = Average_45_Sales + Average_56_Sales + Average_67_Sales + Average_78_Sales + Average_89_Sales;

            Week1_AdjustedSalesTotal = Math.Round(Week1_AdjustedSalesTotal, 2);
            Week2_AdjustedSalesTotal = Math.Round(Week2_AdjustedSalesTotal, 2);
            Week3_AdjustedSalesTotal = Math.Round(Week3_AdjustedSalesTotal, 2);
            Average_SalesTotal = Math.Round(Average_SalesTotal, 2);

            Week1_GuestCountTotal = Week1_45_GuestCount + Week1_56_GuestCount + Week1_67_GuestCount + Week1_78_GuestCount + Week1_89_GuestCount;
            Week2_GuestCountTotal = Week2_45_GuestCount + Week2_56_GuestCount + Week2_67_GuestCount + Week2_78_GuestCount + Week2_89_GuestCount;
            Week3_GuestCountTotal = Week3_45_GuestCount + Week3_56_GuestCount + Week3_67_GuestCount + Week3_78_GuestCount + Week3_89_GuestCount;
            Average_GuestCountTotal = Average_45_GuestCount + Average_56_GuestCount + Average_67_GuestCount + Average_78_GuestCount + Average_89_GuestCount;

            if (!Double.IsNaN(Average_SalesTotal / Average_GuestCountTotal))
                LastWeekAverageCheckTotal = Average_SalesTotal / Average_GuestCountTotal;
            LastWeekAverageCheckTotal = Math.Round(LastWeekAverageCheckTotal, 2);
        }


        #endregion


        #region Calculate Section 2

        public void CalculateSection2()
        {
            Scenario1_EstimatedGuestCount = Scenario1_GuestCountInvited * 0.25;
            Scenario2_EstimatedGuestCount = Scenario2_GuestCountInvited * 0.25;

            Scenario1_EstimatedGuestCount = Math.Round(Scenario1_EstimatedGuestCount, 0);
            Scenario2_EstimatedGuestCount = Math.Round(Scenario2_EstimatedGuestCount, 0);

            Scenario1_ThreeWeekAverageGuestCount = Average_GuestCountTotal;
            Scenario2_ThreeWeekAverageGuestCount = Average_GuestCountTotal;

            Scenario1_TargetedGuestCount = Scenario1_EstimatedGuestCount + Scenario1_ThreeWeekAverageGuestCount;
            Scenario2_TargetedGuestCount = Scenario2_EstimatedGuestCount + Scenario2_ThreeWeekAverageGuestCount;

            Scenario1_EstimatedDonation = (Scenario1_TargetedGuestCount * LastWeekAverageCheckTotal) * 0.1;
            Scenario2_EstimatedDonation = (Scenario2_TargetedGuestCount * LastWeekAverageCheckTotal) * 0.1;

            Scenario1_EstimatedDonation = Math.Round(Scenario1_EstimatedDonation, 2);
            Scenario2_EstimatedDonation = Math.Round(Scenario2_EstimatedDonation, 2);
        }

        #endregion


        #region Calculate Section 3

        public void CalculateSection3()
        {
            if (!Double.IsNaN(ActualSales_45 / ActualGuestCount_45) ) 
                ActualAverageCheck_45 = ActualSales_45 / ActualGuestCount_45;
            ActualAverageCheck_45 = Math.Round(ActualAverageCheck_45, 2);

            if (!Double.IsNaN(ActualSales_56 / ActualGuestCount_56))
                ActualAverageCheck_56 = ActualSales_56/ActualGuestCount_56;
            ActualAverageCheck_56 = Math.Round(ActualAverageCheck_56, 2);

            if (!Double.IsNaN(ActualSales_67 / ActualGuestCount_67))
                ActualAverageCheck_67 = ActualSales_67/ActualGuestCount_67;
            ActualAverageCheck_67 = Math.Round(ActualAverageCheck_67, 2);

            if (!Double.IsNaN(ActualSales_78 / ActualGuestCount_78))
                ActualAverageCheck_78 = ActualSales_78/ActualGuestCount_78;
            ActualAverageCheck_78 = Math.Round(ActualAverageCheck_78, 2);

            if (!Double.IsNaN(ActualSales_89 / ActualGuestCount_89))
                ActualAverageCheck_89 = ActualSales_89/ActualGuestCount_89;
            ActualAverageCheck_89 = Math.Round(ActualAverageCheck_89, 2);

            ActualSalesTotal = ActualSales_45 + ActualSales_56 + ActualSales_67 + ActualSales_78 + ActualSales_89;
            ActualGuestCountTotal = ActualGuestCount_45 + ActualGuestCount_56 + ActualGuestCount_67 + ActualGuestCount_78 + ActualGuestCount_89;

            if (!Double.IsNaN(ActualSalesTotal / ActualGuestCountTotal))
                ActualAverageCheckTotal = ActualSalesTotal / ActualGuestCountTotal;
            ActualAverageCheckTotal = Math.Round(ActualAverageCheckTotal, 2);

            TenPercentDonation = ActualSalesTotal * 0.1;
            TenPercentDonation = Math.Round(TenPercentDonation, 2);
        }

        #endregion


        #region Calculate Section 4

        public void CalculateSection4()
        {
            SalesContribution_3WeekAverage = Average_SalesTotal;
            SalesContribution_Actual = ActualSalesTotal;
            SalesContribution_Difference = SalesContribution_Actual - SalesContribution_3WeekAverage;
            SalesContribution_Donation = TotalDonation;
            SalesContribution_SalesContribution = SalesContribution_Difference + SalesContribution_Donation;

            GuestCountContribution_3WeekAverage = Average_GuestCountTotal;
            GuestCountContribution_ActualNumber = ActualGuestCountTotal;
            GuestCountContribution_GCCountribution = GuestCountContribution_ActualNumber - GuestCountContribution_3WeekAverage;
        }

        #endregion


        #region Calculate Section 5

        public void CalculateSection5()
        {
            Donations10PercentOfSalesToGL7700 = TenPercentDonation;
            GLCode7700 = 7700 - HostingRestaurant;
            DonationsTakenOnThePosiRegisterCodeToGL2005 = PosiDonations;
            GLCode2005 = 2005 - HostingRestaurant;
            TotalDonation = (ActualSalesTotal * 1.10) + PosiDonations;
            TotalDonation = Math.Round(TotalDonation, 2);
        }

        #endregion



        //not part of the official form
        public bool IsComplete { get; set; }

    }
}
