using System.Collections.Generic;
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

        Task<int> SaveAsync();
    }
}