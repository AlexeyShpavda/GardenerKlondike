using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GardenerKlondike.Web.Models
{
    public class ArticleViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title must be less than 50 characters")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public string Author { get; set; }
    }
}