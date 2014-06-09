using Capstone.WebUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.WebUI.Models
{
    public class ProfileViewModel
    {
        List<PartnershipNight> PartnershipNights { get; set; }
        List<Form> Forms { get; set; }
        BvLocation BvLocation { get; set; }
    }
}