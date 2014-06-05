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
                   dbEntry.FormId = dbEntry.FormId;
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
                   dbEntry.ActualSales_45 = dbEntry.ActualSales_45;
                   dbEntry.ActualSales_56 = dbEntry.ActualSales_56;
                   dbEntry.ActualSales_67 = dbEntry.ActualSales_67;
                   dbEntry.ActualSales_78 = dbEntry.ActualSales_78;
                   dbEntry.ActualSales_89 = dbEntry.ActualSales_89;
                   dbEntry.ActualSalesTotal = dbEntry.ActualSalesTotal;
                   dbEntry.Average_45_GuestCount = dbEntry.Average_45_GuestCount;
                   dbEntry.Average_45_Sales = dbEntry.Average_45_Sales;
                   dbEntry.Average_56_GuestCount = dbEntry.Average_56_GuestCount;
                   dbEntry.Average_56_Sales = dbEntry.Average_56_Sales;
                   dbEntry.Average_67_GuestCount = dbEntry.Average_67_GuestCount;
                   dbEntry.Average_67_Sales = dbEntry.Average_67_Sales;
                   dbEntry.Average_78_GuestCount = dbEntry.Average_78_GuestCount;
                   dbEntry.Average_78_Sales = dbEntry.Average_78_Sales;
                   dbEntry.Average_89_GuestCount = dbEntry.Average_89_GuestCount;
                   dbEntry.Average_89_Sales = dbEntry.Average_89_Sales;
                   dbEntry.Average_GuestCountTotal = dbEntry.Average_GuestCountTotal;
                   dbEntry.Average_SalesTotal = dbEntry.Average_SalesTotal;
                   dbEntry.ContactName = dbEntry.ContactName;
                   dbEntry.DateOfPartnership = dbEntry.DateOfPartnership;
                   dbEntry.Donations10PercentOfSalesToGL7700 = dbEntry.Donations10PercentOfSalesToGL7700;
                   dbEntry.DonationsTakenOnThePosiRegisterCodeToGL2005 = dbEntry.DonationsTakenOnThePosiRegisterCodeToGL2005;
                   dbEntry.FederalTaxID = dbEntry.FederalTaxID;
                   dbEntry.GLCode2005 = dbEntry.GLCode2005;
                   dbEntry.GLCode7700 = dbEntry.GLCode7700;
                   dbEntry.GuestCountContribution_3WeekAverage = dbEntry.GuestCountContribution_3WeekAverage;
                   dbEntry.GuestCountContribution_ActualNumber = dbEntry.GuestCountContribution_ActualNumber;
                   dbEntry.GuestCountContribution_GCCountribution = dbEntry.GuestCountContribution_GCCountribution;
                   dbEntry.HostingRestaurant = dbEntry.HostingRestaurant;
                   dbEntry.IsComplete = dbEntry.IsComplete;
                   dbEntry.LastWeekAverageCheck_45 = dbEntry.LastWeekAverageCheck_45;
                   dbEntry.LastWeekAverageCheck_56 = dbEntry.LastWeekAverageCheck_56;
                   dbEntry.LastWeekAverageCheck_67 = dbEntry.LastWeekAverageCheck_67;
                   dbEntry.LastWeekAverageCheck_78 = dbEntry.LastWeekAverageCheck_78;
                   dbEntry.LastWeekAverageCheck_89 = dbEntry.LastWeekAverageCheck_89;
                   dbEntry.LastWeekAverageCheckTotal = dbEntry.LastWeekAverageCheckTotal;
                   dbEntry.MailPartnershipCheckToBV = dbEntry.MailPartnershipCheckToBV;
                   dbEntry.NameOnCheck = dbEntry.NameOnCheck;
                   dbEntry.NewPartner = dbEntry.NewPartner;
                   dbEntry.Notes = dbEntry.Notes;
                   dbEntry.OrganizationMailingAddress = dbEntry.OrganizationMailingAddress;
                   dbEntry.OrganizationMailingCity = dbEntry.OrganizationMailingCity;
                   dbEntry.OrganizationMailingState = dbEntry.OrganizationMailingState;
                   dbEntry.OrganizationMailingZip = dbEntry.OrganizationMailingZip;
                   dbEntry.OrganizationPhone = dbEntry.OrganizationPhone;
                   dbEntry.PosiDonations = dbEntry.PosiDonations;
                   dbEntry.Purpose = dbEntry.Purpose;
                   dbEntry.SalesContribution_3WeekAverage = dbEntry.SalesContribution_3WeekAverage;
                   dbEntry.SalesContribution_Actual = dbEntry.SalesContribution_Actual;
                   dbEntry.SalesContribution_Difference = dbEntry.SalesContribution_Difference;
                   dbEntry.SalesContribution_Donation = dbEntry.SalesContribution_Donation;
                   dbEntry.SalesContribution_SalesContribution = dbEntry.SalesContribution_SalesContribution;
                   dbEntry.Scenario1_EstimatedDonation = dbEntry.Scenario1_EstimatedDonation;
                   dbEntry.Scenario1_EstimatedGuestCount = dbEntry.Scenario1_EstimatedGuestCount;
                   dbEntry.Scenario1_GuestCountInvited = dbEntry.Scenario1_GuestCountInvited;
                   dbEntry.Scenario1_TargetedGuestCount = dbEntry.Scenario1_TargetedGuestCount;
                   dbEntry.Scenario1_ThreeWeekAverageGuestCount = dbEntry.Scenario1_ThreeWeekAverageGuestCount;
                   dbEntry.Scenario2_EstimatedDonation = dbEntry.Scenario2_EstimatedDonation;
                   dbEntry.Scenario2_EstimatedGuestCount = dbEntry.Scenario2_EstimatedGuestCount;
                   dbEntry.Scenario2_GuestCountInvited = dbEntry.Scenario2_GuestCountInvited;
                   dbEntry.Scenario2_TargetedGuestCount = dbEntry.Scenario2_TargetedGuestCount;
                   dbEntry.Scenario2_ThreeWeekAverageGuestCount = dbEntry.Scenario2_ThreeWeekAverageGuestCount;
                   dbEntry.TenPercentDonation = dbEntry.TenPercentDonation;
                   dbEntry.TotalDonation = dbEntry.TotalDonation;
                   dbEntry.Week1_45_AdjustedSales = dbEntry.Week1_45_AdjustedSales;
                   dbEntry.Week1_45_GuestCount = dbEntry.Week1_45_GuestCount;
                   dbEntry.Week1_56_AdjustedSales = dbEntry.Week1_56_AdjustedSales;
                   dbEntry.Week1_56_GuestCount = dbEntry.Week1_56_GuestCount;
                   dbEntry.Week1_67_AdjustedSales = dbEntry.Week1_67_AdjustedSales;
                   dbEntry.Week1_67_GuestCount = dbEntry.Week1_67_GuestCount;
                   dbEntry.Week1_78_AdjustedSales = dbEntry.Week1_78_AdjustedSales;
                   dbEntry.Week1_78_GuestCount = dbEntry.Week1_78_GuestCount;
                   dbEntry.Week1_89_AdjustedSales = dbEntry.Week1_89_AdjustedSales;
                   dbEntry.Week1_89_GuestCount = dbEntry.Week1_89_GuestCount;
                   dbEntry.Week1_AdjustedSalesTotal = dbEntry.Week1_AdjustedSalesTotal;
                   dbEntry.Week1_GuestCountTotal = dbEntry.Week1_GuestCountTotal;
                   dbEntry.Week1Date = dbEntry.Week1Date;
                   dbEntry.Week2_45_AdjustedSales = dbEntry.Week2_45_AdjustedSales;
                   dbEntry.Week2_45_GuestCount = dbEntry.Week2_45_GuestCount;
                   dbEntry.Week2_56_AdjustedSales = dbEntry.Week2_56_AdjustedSales;
                   dbEntry.Week2_56_GuestCount = dbEntry.Week2_56_GuestCount;
                   dbEntry.Week2_67_AdjustedSales = dbEntry.Week2_67_AdjustedSales;
                   dbEntry.Week2_67_GuestCount = dbEntry.Week2_67_GuestCount;
                   dbEntry.Week2_67_GuestCount = dbEntry.Week2_67_GuestCount;
                   dbEntry.Week2_78_AdjustedSales = dbEntry.Week2_78_AdjustedSales;
                   dbEntry.Week2_78_GuestCount = dbEntry.Week2_78_GuestCount;
                   dbEntry.Week2_89_AdjustedSales = dbEntry.Week2_89_AdjustedSales;
                   dbEntry.Week2_89_GuestCount = dbEntry.Week2_89_GuestCount;
                   dbEntry.Week2_AdjustedSalesTotal = dbEntry.Week2_AdjustedSalesTotal;
                   dbEntry.Week2_GuestCountTotal = dbEntry.Week2_GuestCountTotal;
                   dbEntry.Week2Date = dbEntry.Week2Date;
                   dbEntry.Week3_45_AdjustedSales = dbEntry.Week3_45_AdjustedSales;
                   dbEntry.Week3_45_GuestCount = dbEntry.Week3_45_GuestCount;
                   dbEntry.Week3_56_AdjustedSales = dbEntry.Week3_56_GuestCount;
                   dbEntry.Week3_67_AdjustedSales = dbEntry.Week3_67_AdjustedSales;
                   dbEntry.Week3_67_GuestCount = dbEntry.Week3_67_GuestCount;
                   dbEntry.Week3_78_AdjustedSales = dbEntry.Week3_78_AdjustedSales;
                   dbEntry.Week3_78_GuestCount = dbEntry.Week3_78_GuestCount;
                   dbEntry.Week3_89_AdjustedSales = dbEntry.Week3_89_AdjustedSales;
                   dbEntry.Week3_89_GuestCount = dbEntry.Week3_89_GuestCount;
                   dbEntry.Week3_AdjustedSalesTotal = dbEntry.Week3_AdjustedSalesTotal;
                   dbEntry.Week3_GuestCountTotal = dbEntry.Week3_GuestCountTotal;
                   dbEntry.Week3Date = dbEntry.Week3Date;
                   dbEntry.WeekDayOfPartnership = dbEntry.WeekDayOfPartnership;
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
