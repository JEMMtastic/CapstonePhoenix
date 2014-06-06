using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage="Please enter a Store Number")]
        public string BvStoreNum {get; set;}
        [Required(ErrorMessage="Please enter an address")]
        public string Address { get; set; }
        [Required(ErrorMessage="please enter a city")]
        public string City { get; set; }
        [Required(ErrorMessage="Please enter a state")]
        public string State { get; set; }
        [Required(ErrorMessage="Please enter a zip code")]
        public string Zip { get; set; }
        public string Phone { get; set; }
        public List<PartnershipNight> PartnershipNights { get; set; }

    }
}
