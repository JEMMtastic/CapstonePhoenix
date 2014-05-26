using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.WebUI.Models
{
    public class Event
    {
        public string Id { get; set; }
        public int PartnershipNightId { get; set; }
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}