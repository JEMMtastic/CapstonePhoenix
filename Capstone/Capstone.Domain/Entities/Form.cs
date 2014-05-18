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
        // "Name on check" - Comes from PartnershipNight.Charity.Name
        public string Purpose { get; set; }
        public string Contact { get; set; } // TODO: Add the contact to the partnership

        // "Organization mailing address" - Comes from PartnershipNight.Charity.Address, City, Zip, State (?)
        // "Telephone number" - Comes from PartnershipNight.Charity.Phone
        // "Federal tax I.D. number - PartnershipNight.Charity.FederalTaxId
        public bool NewPartner { get; set; }
        // "Hosting restaurant" - PartnershipNight.BvLocation.BvStoreNum
        // "Week day of Partnership" - PartnershipNight.Date
        // "Date of Partnership" - PartnershipNight.Date 
        #endregion
        
        #region Section 1 - Actual Sales Information from Prior Year - 3 Weeks
        public int Wk1Year { get; set; } // Prior Year Week X
        public int Wk2Year { get; set; }
        public int Wk3Year { get; set; }


        // Prior Year Adjusted Sales, week 1, Hour 4 thru 8 = Wk1HOURGc * LWkAvgChkHOUR
        // Prior Year Adjusted Sales Total = Sum of week 1 hours 4 thru 8

        // Prior Year Adjusted Sales, week 2, Hour 4 thr 8 = Wk1HOURGc * LWkAvgChkHOUR
        // Prior Year Adjusted Sales Total = Sum of week 2 hours 4 thru 8

        // Prior Year Adjusted Sales, week 3, Hour 4 thr 8 = Wk1HOURGc * LWkAvgChkHOUR
        // Prior Year Adjusted Sales Total = Sum of week 3 hours 4 thru 8

        public int Wk1FourGc { get; set; } // Week 1 Hours x-x Guest Count
        public int Wk1FiveGc { get; set; }
        public int Wk1SixGc { get; set; }
        public int Wk1SevenGc { get; set; }
        public int Wk1EightGc { get; set; }
        // "Guest Count week 1 total" - Add Wk1FourGc thru Wk1EightGc

        public int Wk2FourGc { get; set; } // Week 2 Hours x-x Guest Count
        public int Wk2FiveGc { get; set; }
        public int Wk2SixGc { get; set; }
        public int WkSevenGc { get; set; }
        public int Wk2EightGc { get; set; }
        // "Guest Count week 2 total" - Add Wk2FourGc thru Wk2EightGc

        public int Wk3FourGc { get; set; } // Week 3 Hours x-x Guest Count
        public int Wk3FiveGc { get; set; }
        public int Wk3SixGc { get; set; }
        public int Wk3SevenGc { get; set; }
        public int Wk3EightGc { get; set; }
        // "Guest Count week 3 total" - Add Wk3FourGc thru Wk3EightGc
        public decimal LWkAvgChkFour { get; set; } // Last week average check for hour X
        public decimal LWkAvgChkFive { get; set; }
        public decimal LWkAvgChkSix { get; set; }
        public decimal LWkAvgChkSeven { get; set; }
        public decimal LWkAvgChkEight { get; set; }


        // "Week 1 Adjusted Sales" - Sum of (Prior Year Adjusted Sales, week 1, Hour 4 thru 8 = Wk1HOURGc * LWkAvgChkHOUR) / 3
        // "Week 2 Adjusted Sales" - Sum of (Prior Year Adjusted Sales, week 2, Hour 4 thru 8 = Wk1HOURGc * LWkAvgChkHOUR) / 3
        // "Week 3 Adjusted Sales" - Sum of (Prior Year Adjusted Sales, week 3, Hour 4 thru 8 = Wk1HOURGc * LWkAvgChkHOUR) / 3
        // "Average Sales Total" - Sum of all weeks Adjsuted Sales

        // "Week 1 Average GC" - Sum of Wk1HOURGc / 3
        // "Week 2 Average GC" - Sum of Wk2HOURGc / 3
        // "Week 3 Average GC" - Sum of Wk3HOURGc / 3
        // "Average Guest Count Total" - Sum of all weeks Average Guest Count

        // "Overall Average Check" - Average Sales Total / Average Guest Count Total
        #endregion

        #region Section 2 - Scenario Donation Based on Projections
        public int Scenario1Gc { get; set; }
        public int Scenario2Gc { get; set; } 

        // "Estimated Guest Count" - Intended guest count * 25%
        // "3 Week Average Guest Count" - Same as Average Guest Count Total from Section 1
        // "Targeted Guest Count" - Estimated Gueset Count + 3 Week Average Guest Count
        // "Estimated Donation" - (Targeted Guest Count * Overall Average Check) * 10%
        #endregion

        // TODO: Move calculations?
        #region Section 3 - Day of Partnership - Actual Sales & Guest Count Results Per PosiTouch
        public decimal ActualSalesFour { get; set; } // Actual sales for hours 4 thru 8
        public decimal ActualSalesFive { get; set; }
        public decimal ActualSalesSix { get; set; }
        public decimal ActualSalesSeven { get; set; }
        public decimal ActualSalesEight { get; set; }
        // "Actual Sales Total" - Sum of Actual Sales for hours 4 thru 8

        public int ActualGcFour { get; set; } // Actual guest count for hours 4 thru 8
        public int ActualGcFive { get; set; }
        public int ActualGcSix { get; set; }
        public int ActualGcSeven { get; set; }
        public int ActualGcEight { get; set; }
        // "Actual Gueset Count Total" - Sum of Actual Guest Count for hours 4 thru 8

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
