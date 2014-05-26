using Capstone.WebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.WebUI.Domain.Entities
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage="The user must have a store number")]
        public BvLocation BvLocation { get; set; }
        
        [Required(ErrorMessage = "Please enter a First Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LName { get; set; }

        //Properties below this line have been taken out because Identity will handle them instead

        //[HiddenInput(DisplayValue = false)]
        //public int UserId { get; set; }

        //[Required(ErrorMessage = "Please enter a Username")]
        //public string Username { get; set; }
        
        //[HiddenInput(DisplayValue = false)]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "you must enter an access level")]
        //[Range(1, 2, ErrorMessage = "You must enter a 1 or a 2")]
        //public int AccessLevel { get; set; }

        //public string PhoneNumber { get; set; }
        //public string UserEmail { get; set; }
    }
}
