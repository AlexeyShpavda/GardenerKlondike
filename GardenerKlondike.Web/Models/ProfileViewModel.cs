using System.Collections.Generic;

namespace GardenerKlondike.Web.Models
{
    public class ProfileViewModel
    {
        public IEnumerable<GoalViewModel> GoalViewModels { get; set; }

        public IEnumerable<CalendarEventViewModel> CalendarEventViewModels { get; set; }
    }
}