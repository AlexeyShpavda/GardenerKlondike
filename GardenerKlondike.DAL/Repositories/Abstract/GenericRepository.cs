using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GardenerKlondike.DAL.Contracts.Repositories.Abstract;
using GardenerKlondike.Entity;

namespace GardenerKlondike.DAL.Repositories.Abstract
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity.Entity
    {
        private IDbSet<TEntity> DbSet { get; }

        private GardenerKlondikeContainer Context { get; }

        protected GenericRepository()
        {
            Context = new GardenerKlondikeContainer();

            DbSet = Context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var result = DbSet.Add(entity);

            Context.Entry(entity).State = EntityState.Added;

            return result;
        }

        public TEntity Update(TEntity entity)
        {
            var result = DbSet.Attach(entity);

            Context.Entry(entity).State = EntityState.Modified;

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id).ConfigureAwait(false);

            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            Expression<Func<TEntity, bool>> predicate = x => x.Id == id;

            return await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}