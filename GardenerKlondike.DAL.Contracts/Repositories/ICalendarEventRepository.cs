using System.Collections.Generic;
using System.Threading.Tasks;
using GardenerKlondike.DAL.Contracts.Repositories.Abstract;
using GardenerKlondike.Entity;

namespace GardenerKlondike.DAL.Contracts.Repositories
{
    public interface ICalendarEventRepository : IGenericRepository<CalendarEvent>
    {
        Task<IEnumerable<CalendarEvent>> GetAllPersonalEventsAsync(string user);
    }
}