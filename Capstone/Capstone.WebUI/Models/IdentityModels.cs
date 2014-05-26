﻿using Capstone.WebUI.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Capstone.WebUI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    public class User : IdentityUser    
    {
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The user must have a store number")]
        public BvLocation BvLocation { get; set; }

        [Required(ErrorMessage = "Please enter a Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        public string UserFName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string UserLName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Password { get; set; }

        [Required(ErrorMessage = "you must enter an access level")]
        [Range(1, 2, ErrorMessage = "You must enter a 1 or a 2")]
        public int AccessLevel { get; set; }

        public string UserEmail { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("CapstoneDbContext")
        {
        }
        /*public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
         * */
    }
}