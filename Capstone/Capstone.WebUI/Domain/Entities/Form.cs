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

        public string HostingRestaurant { get; set; }// "Hosting restaurant" - PartnershipNight.BvLocation.BvStoreNum

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
        public int Scenario1_GuestCount { get; set; }
        public int Scenario2_GuestCount { get; set; } 


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

        public int GuestCountContribution_3WeekAverage { get; set; }
        public int GuestCountContribution_ActualNumber { get; set; }
        public int GuestCountContribution_GCCountribution { get; set; }

        #endregion


        #region Section 5 - Donation Check Request

        //Manually entered
        //**************************************************************************************
        public bool MailPartnershipCheckToBV { get; set; } //if true, use bv address; if false, use charity address

        //Calculated
        //**************************************************************************************
        public double Donations10PercentOfSalesToGL7700 { get; set; }
        public string GLCode7700 { get; set; }
        public double DonationsTakenOnThePosiRegisterCodeToGL2005{ get; set; }
        public string GLCode2005 { get; set; }
        public double TotalDonation { get; set; }

        #endregion


        //not part of the official form
        public bool IsComplete { get; set; }

        //Calc methods

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

            Week1_AdjustedSalesTotal = Week1_45_AdjustedSales + Week1_56_AdjustedSales + Week1_67_AdjustedSales + Week1_78_AdjustedSales + Week1_89_AdjustedSales;
            Week2_AdjustedSalesTotal = Week2_45_AdjustedSales + Week2_56_AdjustedSales + Week2_67_AdjustedSales + Week2_78_AdjustedSales + Week2_89_AdjustedSales; 
            Week3_AdjustedSalesTotal = Week3_45_AdjustedSales + Week3_56_AdjustedSales + Week3_67_AdjustedSales + Week3_78_AdjustedSales + Week3_89_AdjustedSales; 
            Average_SalesTotal = Average_45_Sales + Average_56_Sales + Average_67_Sales + Average_78_Sales + Average_89_Sales;

            Week1_GuestCountTotal = Week1_45_GuestCount + Week1_56_GuestCount + Week1_67_GuestCount + Week1_78_GuestCount + Week1_89_GuestCount;
            Week2_GuestCountTotal = Week2_45_GuestCount + Week2_56_GuestCount + Week2_67_GuestCount + Week2_78_GuestCount + Week2_89_GuestCount;
            Week3_GuestCountTotal = Week3_45_GuestCount + Week3_56_GuestCount + Week3_67_GuestCount + Week3_78_GuestCount + Week3_89_GuestCount;
            Average_GuestCountTotal = Average_45_GuestCount + Average_56_GuestCount + Average_67_GuestCount + Average_78_GuestCount + Average_89_GuestCount;

            LastWeekAverageCheckTotal = Average_SalesTotal / Average_GuestCountTotal;
        }

        public void CalculateSection2()
        {
            Scenario1_EstimatedGuestCount = Scenario1_GuestCount * 0.25;
            Scenario2_EstimatedGuestCount = Scenario2_GuestCount * 0.25;

            Scenario1_ThreeWeekAverageGuestCount = Average_GuestCountTotal;
            Scenario2_ThreeWeekAverageGuestCount = Average_GuestCountTotal;

            Scenario1_TargetedGuestCount = Scenario1_EstimatedGuestCount + Scenario1_ThreeWeekAverageGuestCount;
            Scenario2_TargetedGuestCount = Scenario2_EstimatedGuestCount + Scenario2_ThreeWeekAverageGuestCount;

            Scenario1_EstimatedDonation = (Scenario1_TargetedGuestCount * LastWeekAverageCheckTotal) * 0.1;
            Scenario2_EstimatedDonation = (Scenario2_TargetedGuestCount * LastWeekAverageCheckTotal) * 0.1;
        }

        public void CalculateSection3()
        {

        }

        public void CalculateSection4()
        {

        }

        public void CalculateSection5()
        {

        }
        
    }
}
