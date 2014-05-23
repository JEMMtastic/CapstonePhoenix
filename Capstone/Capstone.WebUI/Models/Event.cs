using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.WebUI.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}