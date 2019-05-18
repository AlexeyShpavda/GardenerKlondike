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

        public Goal Map(GoalViewModel goalViewModel)
        {
            return new Goal()
            {
                Name = goalViewModel.Name,
                Note = goalViewModel.Note,
                IsCompleted = goalViewModel.IsCompleted,
                User = goalViewModel.User
            };
        }

        public GoalViewModel Map(Goal goal)
        {
            return new GoalViewModel()
            {
                Id = goal.Id,
                Name = goal.Name,
                Note = goal.Note,
                IsCompleted = goal.IsCompleted,
                User = goal.User
            };
        }

        public IEnumerable<GoalViewModel> Map(IEnumerable<Goal> goals)
        {
            return goals.Select(Map);
        }

        public IEnumerable<Goal> Map(IEnumerable<GoalViewModel> goalViewModels)
        {
            return goalViewModels.Select(Map);
        }
    }
}