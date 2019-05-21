using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GardenerKlondike.DAL.Contracts.Repositories;
using GardenerKlondike.DAL.Repositories.Abstract;
using GardenerKlondike.Entity;

namespace GardenerKlondike.DAL.Repositories
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        public async Task<IEnumerable<Goal>> GetAllPersonalGoalsAsync(string user)
        {
            Expression<Func<Goal, bool>> predicate = x => x.User == user;

            return await FindAllAsync(predicate);
        }
    }
}