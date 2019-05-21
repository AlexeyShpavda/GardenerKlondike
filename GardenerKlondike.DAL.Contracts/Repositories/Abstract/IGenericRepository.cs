using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GardenerKlondike.DAL.Contracts.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : Entity.Entity
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        Task DeleteAsync(int id);

        Task<TEntity> GetAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveAsync();
    }
}