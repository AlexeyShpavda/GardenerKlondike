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

        Goal Map(GoalViewModel goalViewModel);

        GoalViewModel Map(Goal goal);

        IEnumerable<GoalViewModel> Map(IEnumerable<Goal> goals);

        IEnumerable<Goal> Map(IEnumerable<GoalViewModel> goalViewModels);

        CalendarEvent Map(CalendarEventViewModel calendarEventViewModel);

        CalendarEventViewModel Map(CalendarEvent calendarEvent);

        IEnumerable<CalendarEventViewModel> Map(IEnumerable<CalendarEvent> calendarEvents);

        IEnumerable<CalendarEvent> Map(IEnumerable<CalendarEventViewModel> calendarEventViewModels);
    }
}