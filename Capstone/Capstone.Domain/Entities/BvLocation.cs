using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.Domain.Entities
{
    public class BvLocation
    {
        [HiddenInput(DisplayValue = false)]
        public int BvLocationId { get; set; }
        public string BvStoreNum {get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

    }
}
