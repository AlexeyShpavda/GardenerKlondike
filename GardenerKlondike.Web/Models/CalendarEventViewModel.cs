using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GardenerKlondike.Web.Models
{
    public class CalendarEventViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Subject must be less than 50 characters")]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [Required]
        public string ThemeColor { get; set; }

        [Required]
        public bool IsFullDay { get; set; }

        public string User { get; set; }
    }
}