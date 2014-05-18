using Capstone.Domain.Entities;
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
        [HiddenInput(DisplayValue = false)]
        public int PartnershipNightId { get; set; }

        [Required(ErrorMessage = "Please enter a date for the event.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "A Charity is required.")]
        public int CharityId { get; set; }
        
        [Required(ErrorMessage = "A BV Location is required.")]
        public int BVLocationId { get; set; }

        public int CheckRequestId { get; set; } //Not required when the event is first created

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; } // Optional

        public bool CheckRequestFinished { get; set; }

        public bool BeforeTheEventFinished { get; set; }

        public bool AfterTheEventFinished { get; set; }

        //Lists to select child object
        public List<Charity> Charities { get; set; }
        public List<BvLocation> Locations { get; set; }
    }
}
