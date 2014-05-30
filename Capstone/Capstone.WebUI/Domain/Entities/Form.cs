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


        //Manually entered
        //**************************************************************************************
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
        public decimal LastWeekAverageCheck_45 { get; set; }
        public decimal LastWeekAverageCheck_56 { get; set; }
        public decimal LastWeekAverageCheck_67 { get; set; }
        public decimal LastWeekAverageCheck_78 { get; set; }
        public decimal LastWeekAverageCheck_89 { get; set; }


        //Calculated
        //**************************************************************************************
        // Week 1 Hours x-x Adjusted Sales
        public decimal Week1_45_AdjustedSales { get; set; }
        public decimal Week1_56_AdjustedSales { get; set; }
        public decimal Week1_67_AdjustedSales { get; set; }
        public decimal Week1_78_AdjustedSales { get; set; }
        public decimal Week1_89_AdjustedSales { get; set; }

        // Week 2 Hours x-x Adjusted Sales
        public decimal Week2_45_AdjustedSales { get; set; }
        public decimal Week2_56_AdjustedSales { get; set; }
        public decimal Week2_67_AdjustedSales { get; set; }
        public decimal Week2_78_AdjustedSales { get; set; }
        public decimal Week2_89_AdjustedSales { get; set; }

        // Week 3 Hours x-x Adjusted Sales 
        public decimal Week3_45_AdjustedSales { get; set; }
        public decimal Week3_56_AdjustedSales { get; set; }
        public decimal Week3_67_AdjustedSales { get; set; }
        public decimal Week3_78_AdjustedSales { get; set; }
        public decimal Week3_89_AdjustedSales { get; set; }

        // Average Hours x-x Sales
        public decimal Average_45_Sales { get; set; }
        public decimal Average_56_Sales { get; set; }
        public decimal Average_67_Sales { get; set; }
        public decimal Average_78_Sales { get; set; }
        public decimal Average_89_Sales { get; set; }
       

        // Average Hours x-x Guest Count
        public int Average_45_GuestCount { get; set; }
        public int Average_56_GuestCount { get; set; }
        public int Average_67_GuestCount { get; set; }
        public int Average_78_GuestCount { get; set; }
        public int Average_89_GuestCount { get; set; }

        //totals
        public decimal Week1_AdjustedSalesTotal { get; set; }
        public decimal Week2_AdjustedSalesTotal { get; set; }
        public decimal Week3_AdjustedSalesTotal { get; set; }
        public decimal Average_AdjustedSalesTotal { get; set; }
        public int Week1_GuestCountTotal { get; set; }
        public int Week2_GuestCountTotal { get; set; }
        public int Week3_GuestCountTotal { get; set; }
        public int Average_GuestCountTotal { get; set; }

        public decimal LastWeekAverageCheckTotal { get; set; }


        #endregion


        #region Section 2 - Scenario Donation Based on Projections

        //Manually entered
        //**************************************************************************************
        public int Scenario1_GuestCount { get; set; }
        public int Scenario2_GuestCount { get; set; } 


        //Calculated
        //**************************************************************************************
        public int Scenario1_EstimatedGuestCount { get; set; }
        public int Scenario2_EstimatedGuestCount { get; set; }

        public int Scenario1_ThreeWeekAverageGuestCount { get; set; }
        public int Scenario2_ThreeWeekAverageGuestCount { get; set; }

        public int Scenario1_TargetedGuestCount { get; set; }
        public int Scenario2_TargetedGuestCount { get; set; }

        public decimal Scenario1_EstimatedDonation { get; set; }
        public decimal Scenario2_EstimatedDonation { get; set; }

        #endregion


        #region Section 3 - Day of Partnership - Actual Sales & Guest Count Results Per PosiTouch

        //Manually entered
        //**************************************************************************************
        public decimal ActualSales_45 { get; set; }
        public decimal ActualSales_56 { get; set; }
        public decimal ActualSales_67 { get; set; }
        public decimal ActualSales_78 { get; set; }
        public decimal ActualSales_89 { get; set; }

        public int ActualGuestCount_45 { get; set; }
        public int ActualGuestCount_56 { get; set; }
        public int ActualGuestCount_67 { get; set; }
        public int ActualGuestCount_78 { get; set; }
        public int ActualGuestCount_89 { get; set; }
   
        public decimal PosiDonations { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        //Calculated
        //**************************************************************************************
        public decimal ActualAverageCheck_45 { get; set; }
        public decimal ActualAverageCheck_56 { get; set; }
        public decimal ActualAverageCheck_67 { get; set; }
        public decimal ActualAverageCheck_78 { get; set; }
        public decimal ActualAverageCheck_89 { get; set; }

        public decimal ActualSalesTotal { get; set; }
        public int ActualGuestCountTotal { get; set; }
        public decimal ActualAverageCheckTotal { get; set; }

        public decimal TenPercentDonation { get; set; }


        #endregion


        #region Section 4 - Sales & Guest Count Contribution Calculation

        //All Calculated
        //**************************************************************************************
        public decimal SalesContribution_3WeekAverage { get; set; }
        public decimal SalesContribution_Actual { get; set; }
        public decimal SalesContribution_Difference { get; set; }
        public decimal SalesContribution_Donation { get; set; }
        public decimal SalesContribution_SalesContribution { get; set; }

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
        public decimal Donations10PercentOfSalesToGL7700 { get; set; }
        public string GLCode7700 { get; set; }
        public decimal DonationsTakenOnThePosiRegisterCodeToGL2005{ get; set; }
        public string GLCode2005 { get; set; }
        public decimal TotalDonation { get; set; }

        #endregion




        //Calc methods

        public void CalculateSection1() 
        { 

        }

        public void CalculateSection2()
        {

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
