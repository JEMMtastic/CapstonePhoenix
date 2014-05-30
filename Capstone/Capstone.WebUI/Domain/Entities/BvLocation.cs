using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.WebUI.Domain.Entities
{
    public class BvLocation
    {
        [HiddenInput(DisplayValue = false)]
        public int BvLocationId { get; set; }
        public string BvStoreNum {get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public List<PartnershipNight> PartnershipNights { get; set; }

    }
}
