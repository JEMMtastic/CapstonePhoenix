using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.WebUI.Domain.Entities
{
    public class Charity
    {
        [HiddenInput(DisplayValue = false)]
        public int CharityId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the charity.")]
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        [Required(ErrorMessage="Please enter a zip code.")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        public string State { get; set; }

        public string CharityContactNm { get; set; }
        
        [Required(ErrorMessage="Please enter a phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        //NOTE: Should we add email?
        
        [Required(ErrorMessage="Please enter the FederalTaxId.")]
        public string FederalTaxId { get; set; }
        
        public string TypeOfCharity { get; set; }

       
    }
}
