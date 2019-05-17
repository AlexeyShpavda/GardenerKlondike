using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models
{
    public class ArticleViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Title must be less than 50 characters")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Author { get; set; }
    }
}