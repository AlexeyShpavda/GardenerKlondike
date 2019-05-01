using System.Data.Entity;
using System.Linq;

namespace Data.Repositories.Abstract
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository()
        {
            var context = new GardenerDbContext();

            _dbSet = context.Set<TEntity>();
        }

        private readonly IDbSet<TEntity> _dbSet;

        public TEntity Add(TEntity task)
        {
            return _dbSet.Add(task);
        }

        public TEntity Remove(TEntity task)
        {
            return _dbSet.Remove(task);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }
    }
}