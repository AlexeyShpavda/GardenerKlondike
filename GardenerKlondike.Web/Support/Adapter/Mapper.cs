using System.Collections.Generic;
using System.Linq;
using GardenerKlondike.Entity;
using GardenerKlondike.Web.Interfaces.Support.Adapter;
using GardenerKlondike.Web.Models;

namespace GardenerKlondike.Web.Support.Adapter
{
    public class Mapper : IMapper
    {
        public Article Map(ArticleViewModel articleViewModel)
        {
            return new Article
            {
                Title = articleViewModel.Title,
                Body = articleViewModel.Body,
                Author = articleViewModel.Author
            };
        }

        public ArticleViewModel Map(Article article)
        {
            return new ArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                Author = article.Author
            };
        }

        public IEnumerable<ArticleViewModel> Map(IEnumerable<Article> article)
        {
            return article.Select(Map);
        }

        public IEnumerable<Article> Map(IEnumerable<ArticleViewModel> articleViewModels)
        {
            return articleViewModels.Select(Map);
        }
    }
}