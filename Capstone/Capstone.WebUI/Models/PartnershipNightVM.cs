using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.WebUI.Domain.Entities;

namespace Capstone.WebUI.Models
{
    public class PartnershipNightVM
    {
        private bool ckRequest = false;
        private bool before = false;
        private bool after = false;


        [HiddenInput(DisplayValue = false)]
        public int PartnershipNightId { get; set; }

        [Required(ErrorMessage="Please enter a date for the event.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage="Please enter an end time for the event")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        
        
        public Charity Charity { get; set; } 
        
     
        public BvLocation BVLocation { get; set; }
        

        public int CheckRequestId { get; set; } 

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; } 

        public bool CheckRequestFinished { 
            get
            {
                return ckRequest;
            }
            set
            {
                ckRequest = value;
            }
         }

        public bool BeforeTheEventFinished
        {
            get
            {
                return before;
            }
            set
            {
                before = value;
            }
        }

        public bool AfterTheEventFinished
        {
            get
            {
                return after;
            }
            set
            {
                after = value;
            }
        }

        [Required(ErrorMessage = "A BV Location is required.")]
        public int BvLocationId { get; set; }

        public List<BvLocation> BvLocations { get; set; }


        [Required(ErrorMessage = "A charity is required.")]
        public int CharityId { get; set; }

        public List<Charity> Charities { get; set; }

    }
}