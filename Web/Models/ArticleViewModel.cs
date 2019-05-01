using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ArticleViewModel
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public string Author { get; set; }
    }
}