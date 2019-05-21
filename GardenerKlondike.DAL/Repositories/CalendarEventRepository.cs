using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GardenerKlondike.DAL.Contracts.Repositories;
using GardenerKlondike.DAL.Repositories.Abstract;
using GardenerKlondike.Entity;

namespace GardenerKlondike.DAL.Repositories
{
    public class CalendarEventRepository: GenericRepository<CalendarEvent>, ICalendarEventRepository
    {
        public async Task<IEnumerable<CalendarEvent>> GetAllPersonalEventsAsync(string user)
        {
            Expression<Func<CalendarEvent, bool>> predicate = x => x.User == user;

            return await FindAllAsync(predicate);
        }
    }
}