using GardenerKlondike.DAL.Contracts.Repositories;
using GardenerKlondike.DAL.Repositories.Abstract;
using GardenerKlondike.Entity;

namespace GardenerKlondike.DAL.Repositories
{
    public class CalendarEventRepository: GenericRepository<CalendarEvent>, ICalendarEventRepository
    {
        
    }
}