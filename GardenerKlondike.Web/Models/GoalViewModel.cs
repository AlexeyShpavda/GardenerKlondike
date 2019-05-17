using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GardenerKlondike.Web.Models
{
    public class GoalViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Title must be less than 50 characters")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        public bool IsCompleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string User { get; set; }
    }
}