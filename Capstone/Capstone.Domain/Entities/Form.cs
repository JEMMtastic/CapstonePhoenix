using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.Domain.Entities
{
    public class Form
    {
        [HiddenInput(DisplayValue = false)]
        public int FormId { get; set; }

        #region Section 0 - Organization Information
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
        public DateTime DateOfPartnership { get; set; }// "Date of Partnership" - PartnershipNight.Date 
        #endregion
        
        #region Section 1 - Actual Sales Information from Prior Year - 3 Weeks
        public DateTime Week1Date { get; set; } // Prior Year Week X
        public DateTime Week2Date { get; set; }
        public DateTime Week3Date { get; set; }


        //Manually entered
        //**************************************************************************************
        // Week 1 Hours x-x Guest Count
        public int Week145GuestCount { get; set; }
        public int Week156GuestCount { get; set; }
        public int Week167GuestCount { get; set; }
        public int Week178GuestCount { get; set; }
        public int Week189GuestCount { get; set; }

        // Week 2 Hours x-x Guest Count
        public int Week245GuestCount { get; set; }
        public int Week256GuestCount { get; set; }
        public int Week267GuestCount { get; set; }
        public int Week278GuestCount { get; set; }
        public int Week289GuestCount { get; set; }

        // Week 3 Hours x-x Guest Count
        public int Week345GuestCount { get; set; }
        public int Week356GuestCount { get; set; }
        public int Week367GuestCount { get; set; }
        public int Week378GuestCount { get; set; }
        public int Week389GuestCount { get; set; }

        // Last week average check for hour X
        public decimal LastWeekAverageCheck45 { get; set; }
        public decimal LastWeekAverageCheck56 { get; set; }
        public decimal LastWeekAverageCheck67 { get; set; }
        public decimal LastWeekAverageCheck78 { get; set; }
        public decimal LastWeekAverageCheck89 { get; set; }


        //Calculated
        //**************************************************************************************
        // Week 1 Hours x-x Adjusted Sales
        public decimal Week145AdjustedSales { get; set; }
        public decimal Week156AdjustedSales { get; set; }
        public decimal Week167AdjustedSales { get; set; }
        public decimal Week178AdjustedSales { get; set; }
        public decimal Week189AdjustedSales { get; set; }

        // Week 2 Hours x-x Adjusted Sales
        public decimal Week245AdjustedSales { get; set; }
        public decimal Week256AdjustedSales { get; set; }
        public decimal Week267AdjustedSales { get; set; }
        public decimal Week278AdjustedSales { get; set; }
        public decimal Week289AdjustedSales { get; set; }

        // Week 3 Hours x-x Adjusted Sales 
        public decimal Week345AdjustedSales { get; set; }
        public decimal Week356AdjustedSales { get; set; }
        public decimal Week367AdjustedSales { get; set; }
        public decimal Week378AdjustedSales { get; set; }
        public decimal Week389AdjustedSales { get; set; }

        // Average Hours x-x Sales
        public decimal Average45Sales { get; set; }
        public decimal Average56Sales { get; set; }
        public decimal Average67Sales { get; set; }
        public decimal Average78Sales { get; set; }
        public decimal Average89Sales { get; set; }
       

        // Average Hours x-x Guest Count
        public int Average45GuestCount { get; set; }
        public int Average56GuestCount { get; set; }
        public int Average67GuestCount { get; set; }
        public int Average78GuestCount { get; set; }
        public int Average89GuestCount { get; set; }

        //totals
        public decimal Week1AdjustedSalesTotal { get; set; }
        public decimal Week2AdjustedSalesTotal { get; set; }
        public decimal Week3AdjustedSalesTotal { get; set; }
        public decimal AverageAdjustedSalesTotal { get; set; }
        public int Week1GuestCountTotal { get; set; }
        public int Week2GuestCountTotal { get; set; }
        public int Week3GuestCountTotal { get; set; }
        public int AverageGuestCountTotal { get; set; }

        public decimal LastWeekAverageCheckTotal { get; set; }


        #endregion

        #region Section 2 - Scenario Donation Based on Projections

        //Manually entered
        //**************************************************************************************
        public int Scenario1GuestCount { get; set; }
        public int Scenario2GuestCount { get; set; } 


        //Calculated
        //**************************************************************************************
        public int Scenario1EstimatedGuestCount { get; set; }
        public int Scenario2EstimatedGuestCount { get; set; }

        public int Scenario1ThreeWeekAverageGuestCount { get; set; }
        public int Scenario2ThreeWeekAverageGuestCount { get; set; }

        public int Scenario1TargetedGuestCount { get; set; }
        public int Scenario2TargetedGuestCount { get; set; }

        public decimal Scenario1EstimatedDonation { get; set; }
        public decimal Scenario2EstimatedDonation { get; set; }

        #endregion

        // TODO: Move calculations?
        #region Section 3 - Day of Partnership - Actual Sales & Guest Count Results Per PosiTouch
        public decimal ActualSalesFour { get; set; } // Actual sales for hours 4 thru 8
        public decimal ActualSalesFive { get; set; }
        public decimal ActualSalesSix { get; set; }
        public decimal ActualSalesSeven { get; set; }
        public decimal ActualSalesEight { get; set; }
        // "Actual Sales Total" - Sum of Actual Sales for hours 4 thru 8

     

        public decimal PosiDonations { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        //Calculation methods
        public decimal getTotalSales()
        {
            return (ActualSalesFour + ActualSalesFive + ActualSalesSix + ActualSalesSeven + ActualSalesEight); //sum of all hours' sales for the event
        }

        public decimal getAvgCheck(decimal sales, int gc)
        {
            return sales / gc;  //Divide the hour's sales by the guest count to get the average check amt. for the hour.
        }

        public decimal getDonation()
        {
            return getTotalSales() * 0.10M;
        } 
        #endregion

        #region Section 4 - Sales & Guest Count Contribution Calculation
        // "3 Week Avg Sales Contribution" - Same as Average Sales Total from Section 1 
        // "Acutal Sales Contribution" - Same as Actual Sales Total from Section 3
        // "Difference" - (Actual Sales Contribution - 3 Week Avg Sales Contribution)
        // "Donation" - Same as Total Donation for Check Request from Section 5 * -1
        // "Sales Contribution" - Sum of the Difference + Donation
        // "Guest Count 3 Week Avg #" - Same as AvgG from Section 1
        // "Guest Count Contribution Actual #" - Same as Actual Guest Total from Section 3
        // "Guest Count Contribution" - Actual Guests - 3 Week Avg
        #endregion

        // TODO: Decide what to do with the Mail-to radio button
        #region Section 5 - Donation Check Request
        // "Donation 10% to GL7700" - Same as 10% Donation from Section 3
        // "GL Code" - 7700 + Hosting Restaurant number
        // "Donations at Register to GL2005" - Same as Posi Donations from Section 3
        // "GL Code" - 2005 + Hosting Restaurant number
        // "Total Donation for Check Request" - (Actual Sales Totals * 10%) + Posi Donations from Section 3
        // "Mail to" - Radio button to select whether or not the check is sent to the BV location or the charity. 
        #endregion
    }
}
