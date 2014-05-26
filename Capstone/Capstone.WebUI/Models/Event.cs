using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.WebUI.Models
{
    public class Event
    {
        public int id { get; set; }
        public int PartnershipNightId { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}