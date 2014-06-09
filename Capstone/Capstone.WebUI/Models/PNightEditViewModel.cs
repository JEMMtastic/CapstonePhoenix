using Capstone.WebUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.WebUI.Models
{
    public class PNightEditViewModel
    {
        public PartnershipNight PartnershipNight { get; set; }

        //Lists to select child object
        public List<Charity> Charities { get; set; }
        public List<BvLocation> Locations { get; set; }
    }
}
