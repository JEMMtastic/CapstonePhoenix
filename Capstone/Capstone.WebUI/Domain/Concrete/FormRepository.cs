using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Entities;
using Capstone.WebUI.Models;

namespace Capstone.WebUI.Domain.Concrete
{
    public class FormRepository : FormInterface
    {

        public void AddForm(Form form)
        {
            var db = new ApplicationDbContext();

            db.Forms.Add(form);
        }

        public Form GetFormById(int id)
        {
            var db = new ApplicationDbContext();

            return (from form in db.Forms
                    where form.FormId == id
                    select form).FirstOrDefault();
        }

        public IQueryable<Entities.Form> GetForms()
        {
            var db = new ApplicationDbContext();

            return (from form in db.Forms
                    select form).AsQueryable<Form>();
        }

        public void UpdateForm(Entities.Form form)
        {
           var db = new ApplicationDbContext();

           if (form.FormId == 0)
           {
               db.Forms.Add(form);
           }
           else
           {
               var dbEntry = db.Forms.Find(form.FormId);
               if (dbEntry != null)
               {
                   dbEntry.FormId = form.FormId;
                   dbEntry.ActualAverageCheck_45 = form.ActualAverageCheck_45;
                   dbEntry.ActualAverageCheck_56 = form.ActualAverageCheck_56;
                   dbEntry.ActualAverageCheck_67 = form.ActualAverageCheck_67;
                   dbEntry.ActualAverageCheck_78 = form.ActualAverageCheck_78;
                   dbEntry.ActualAverageCheck_89 = form.ActualAverageCheck_89;
                   dbEntry.ActualAverageCheckTotal = form.ActualAverageCheckTotal;
                   dbEntry.ActualGuestCount_45 = form.ActualGuestCount_45;
                   dbEntry.ActualGuestCount_56 = form.ActualGuestCount_56;
                   dbEntry.ActualGuestCount_67 = form.ActualGuestCount_67;
                   dbEntry.ActualGuestCount_78 = form.ActualGuestCount_78;
                   dbEntry.ActualGuestCount_89 = form.ActualGuestCount_89;
                   dbEntry.ActualGuestCountTotal = form.ActualGuestCountTotal;
                   dbEntry.ActualSales_45 = form.ActualSales_45;
                   dbEntry.ActualSales_56 = form.ActualSales_56;
                   dbEntry.ActualSales_67 = form.ActualSales_67;
                   dbEntry.ActualSales_78 = form.ActualSales_78;
                   dbEntry.ActualSales_89 = form.ActualSales_89;
                   dbEntry.ActualSalesTotal = form.ActualSalesTotal;
                   dbEntry.Average_45_GuestCount = form.Average_45_GuestCount;
                   dbEntry.Average_45_Sales = form.Average_45_Sales;
                   dbEntry.Average_56_GuestCount = form.Average_56_GuestCount;
                   dbEntry.Average_56_Sales = form.Average_56_Sales;
                   dbEntry.Average_67_GuestCount = form.Average_67_GuestCount;
                   dbEntry.Average_67_Sales = form.Average_67_Sales;
                   dbEntry.Average_78_GuestCount = form.Average_78_GuestCount;
                   dbEntry.Average_78_Sales = form.Average_78_Sales;
                   dbEntry.Average_89_GuestCount = form.Average_89_GuestCount;
                   dbEntry.Average_89_Sales = form.Average_89_Sales;
                   dbEntry.Average_GuestCountTotal = form.Average_GuestCountTotal;
                   dbEntry.Average_SalesTotal = form.Average_SalesTotal;
                   dbEntry.ContactName = form.ContactName;
                   dbEntry.DateOfPartnership = form.DateOfPartnership;
                   dbEntry.Donations10PercentOfSalesToGL7700 = form.Donations10PercentOfSalesToGL7700;
                   dbEntry.DonationsTakenOnThePosiRegisterCodeToGL2005 = form.DonationsTakenOnThePosiRegisterCodeToGL2005;
                   dbEntry.FederalTaxID = form.FederalTaxID;
                   dbEntry.GLCode2005 = form.GLCode2005;
                   dbEntry.GLCode7700 = form.GLCode7700;
                   dbEntry.GuestCountContribution_3WeekAverage = form.GuestCountContribution_3WeekAverage;
                   dbEntry.GuestCountContribution_ActualNumber = form.GuestCountContribution_ActualNumber;
                   dbEntry.GuestCountContribution_GCCountribution = form.GuestCountContribution_GCCountribution;
                   dbEntry.HostingRestaurant = form.HostingRestaurant;
                   dbEntry.IsComplete = form.IsComplete;
                   dbEntry.LastWeekAverageCheck_45 = form.LastWeekAverageCheck_45;
                   dbEntry.LastWeekAverageCheck_56 = form.LastWeekAverageCheck_56;
                   dbEntry.LastWeekAverageCheck_67 = form.LastWeekAverageCheck_67;
                   dbEntry.LastWeekAverageCheck_78 = form.LastWeekAverageCheck_78;
                   dbEntry.LastWeekAverageCheck_89 = form.LastWeekAverageCheck_89;
                   dbEntry.LastWeekAverageCheckTotal = form.LastWeekAverageCheckTotal;
                   dbEntry.MailPartnershipCheckToBV = form.MailPartnershipCheckToBV;
                   dbEntry.NameOnCheck = form.NameOnCheck;
                   dbEntry.NewPartner = form.NewPartner;
                   dbEntry.Notes = form.Notes;
                   dbEntry.OrganizationMailingAddress = form.OrganizationMailingAddress;
                   dbEntry.OrganizationMailingCity = form.OrganizationMailingCity;
                   dbEntry.OrganizationMailingState = form.OrganizationMailingState;
                   dbEntry.OrganizationMailingZip = form.OrganizationMailingZip;
                   dbEntry.OrganizationPhone = form.OrganizationPhone;
                   dbEntry.PosiDonations = form.PosiDonations;
                   dbEntry.Purpose = form.Purpose;
                   dbEntry.SalesContribution_3WeekAverage = form.SalesContribution_3WeekAverage;
                   dbEntry.SalesContribution_Actual = form.SalesContribution_Actual;
                   dbEntry.SalesContribution_Difference = form.SalesContribution_Difference;
                   dbEntry.SalesContribution_Donation = form.SalesContribution_Donation;
                   dbEntry.SalesContribution_SalesContribution = form.SalesContribution_SalesContribution;
                   dbEntry.Scenario1_EstimatedDonation = form.Scenario1_EstimatedDonation;
                   dbEntry.Scenario1_EstimatedGuestCount = form.Scenario1_EstimatedGuestCount;
                   dbEntry.Scenario1_GuestCountInvited = form.Scenario1_GuestCountInvited;
                   dbEntry.Scenario1_TargetedGuestCount = form.Scenario1_TargetedGuestCount;
                   dbEntry.Scenario1_ThreeWeekAverageGuestCount = form.Scenario1_ThreeWeekAverageGuestCount;
                   dbEntry.Scenario2_EstimatedDonation = form.Scenario2_EstimatedDonation;
                   dbEntry.Scenario2_EstimatedGuestCount = form.Scenario2_EstimatedGuestCount;
                   dbEntry.Scenario2_GuestCountInvited = form.Scenario2_GuestCountInvited;
                   dbEntry.Scenario2_TargetedGuestCount = form.Scenario2_TargetedGuestCount;
                   dbEntry.Scenario2_ThreeWeekAverageGuestCount = form.Scenario2_ThreeWeekAverageGuestCount;
                   dbEntry.TenPercentDonation = form.TenPercentDonation;
                   dbEntry.TotalDonation = form.TotalDonation;
                   dbEntry.Week1_45_AdjustedSales = form.Week1_45_AdjustedSales;
                   dbEntry.Week1_45_GuestCount = form.Week1_45_GuestCount;
                   dbEntry.Week1_56_AdjustedSales = form.Week1_56_AdjustedSales;
                   dbEntry.Week1_56_GuestCount = form.Week1_56_GuestCount;
                   dbEntry.Week1_67_AdjustedSales = form.Week1_67_AdjustedSales;
                   dbEntry.Week1_67_GuestCount = form.Week1_67_GuestCount;
                   dbEntry.Week1_78_AdjustedSales = form.Week1_78_AdjustedSales;
                   dbEntry.Week1_78_GuestCount = form.Week1_78_GuestCount;
                   dbEntry.Week1_89_AdjustedSales = form.Week1_89_AdjustedSales;
                   dbEntry.Week1_89_GuestCount = form.Week1_89_GuestCount;
                   dbEntry.Week1_AdjustedSalesTotal = form.Week1_AdjustedSalesTotal;
                   dbEntry.Week1_GuestCountTotal = form.Week1_GuestCountTotal;
                   dbEntry.Week1Date = form.Week1Date;
                   dbEntry.Week2_45_AdjustedSales = form.Week2_45_AdjustedSales;
                   dbEntry.Week2_45_GuestCount = form.Week2_45_GuestCount;
                   dbEntry.Week2_56_AdjustedSales = form.Week2_56_AdjustedSales;
                   dbEntry.Week2_56_GuestCount = form.Week2_56_GuestCount;
                   dbEntry.Week2_67_AdjustedSales = form.Week2_67_AdjustedSales;
                   dbEntry.Week2_67_GuestCount = form.Week2_67_GuestCount;
                   dbEntry.Week2_67_GuestCount = form.Week2_67_GuestCount;
                   dbEntry.Week2_78_AdjustedSales = form.Week2_78_AdjustedSales;
                   dbEntry.Week2_78_GuestCount = form.Week2_78_GuestCount;
                   dbEntry.Week2_89_AdjustedSales = form.Week2_89_AdjustedSales;
                   dbEntry.Week2_89_GuestCount = form.Week2_89_GuestCount;
                   dbEntry.Week2_AdjustedSalesTotal = form.Week2_AdjustedSalesTotal;
                   dbEntry.Week2_GuestCountTotal = form.Week2_GuestCountTotal;
                   dbEntry.Week2Date = form.Week2Date;
                   dbEntry.Week3_45_AdjustedSales = form.Week3_45_AdjustedSales;
                   dbEntry.Week3_45_GuestCount = form.Week3_45_GuestCount;
                   dbEntry.Week3_56_AdjustedSales = form.Week3_56_GuestCount;
                   dbEntry.Week3_67_AdjustedSales = form.Week3_67_AdjustedSales;
                   dbEntry.Week3_67_GuestCount = form.Week3_67_GuestCount;
                   dbEntry.Week3_78_AdjustedSales = form.Week3_78_AdjustedSales;
                   dbEntry.Week3_78_GuestCount = form.Week3_78_GuestCount;
                   dbEntry.Week3_89_AdjustedSales = form.Week3_89_AdjustedSales;
                   dbEntry.Week3_89_GuestCount = form.Week3_89_GuestCount;
                   dbEntry.Week3_AdjustedSalesTotal = form.Week3_AdjustedSalesTotal;
                   dbEntry.Week3_GuestCountTotal = form.Week3_GuestCountTotal;
                   dbEntry.Week3Date = form.Week3Date;
                   dbEntry.WeekDayOfPartnership = form.WeekDayOfPartnership;
               }               
           }

           db.SaveChanges();
        }

        public Form DeleteForm(int id)
        {
            var db = new ApplicationDbContext();
            var dbEntry = db.Forms.Find(id);
            if (dbEntry != null)
            {
                db.Forms.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
