using System.Collections.Generic;
using GardenerKlondike.Entity;
using GardenerKlondike.Web.Models;

namespace GardenerKlondike.Web.Interfaces.Support.Adapter
{
    public interface IMapper
    {
        Article Map(ArticleViewModel articleViewModel);

        ArticleViewModel Map(Article article);

        IEnumerable<ArticleViewModel> Map(IEnumerable<Article> article);

        IEnumerable<Article> Map(IEnumerable<ArticleViewModel> articleViewModels);
    }
}