using Capstone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.WebUI.Models
{
    public class Calendar
    {
        private DateTime currentDate = DateTime.Now;
        private List<string> months = new List<string>{"January", "February", "March", "April", "May", "June", "July", "August",
                                "September", "October", "November", "December"};
        private List<string> days = new List<string>{ "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        //has a list of events
        public List<PartnershipNight> events { get; set; }
        //list of months
        public List<string> Months { set { Months = months; } }
        public List<string> Days { set { Days = days; } }
        

        //constructor for no date entered will return calendar for current month
        public Calendar()
        {

        }

    }
}