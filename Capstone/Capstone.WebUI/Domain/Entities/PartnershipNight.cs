using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Capstone.WebUI.Domain.Entities
{
    public class PartnershipNight
    {
        //Form flags determine if documents have been filled out yet
        private bool ckRequest;
        private bool before;
        private bool after;

        //Constructor to set flags to default
        public PartnershipNight()
        {
            //Set form flags to false when the event is first created
            ckRequest = false;
            before = false;
            after = false;
        }

        [HiddenInput(DisplayValue = false)]
        public int PartnershipNightId { get; set; }
        //NOTE: Should we add another id to identify each partnership night apart from the database row

        [Required(ErrorMessage="Please enter a date for the event.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage="Please enter an end time for the event")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        
        [Required(ErrorMessage = "A Charity is required.")]
        public Charity Charity { get; set; } 
        
        [Required(ErrorMessage = "A BV Location is required.")]
        public BvLocation BVLocation { get; set; }
        
        //NOTE: Should this be a hidden input?
        public int CheckRequestId { get; set; } //Not required when the event is first created

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; } // Optional

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

    }
}
