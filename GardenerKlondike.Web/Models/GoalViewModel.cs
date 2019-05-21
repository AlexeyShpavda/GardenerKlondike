using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GardenerKlondike.Web.Models
{
    public class GoalViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        public bool IsCompleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string User { get; set; }
    }
}