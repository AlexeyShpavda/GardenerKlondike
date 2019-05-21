using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GardenerKlondike.DAL.Contracts.Repositories.Abstract;
using GardenerKlondike.Entity;

namespace GardenerKlondike.DAL.Contracts.Repositories
{
    public interface IGoalRepository : IGenericRepository<Goal>
    {
        Task<IEnumerable<Goal>> GetAllPersonalGoalsAsync(string user);
    }
}