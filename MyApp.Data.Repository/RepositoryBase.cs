using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Data.EF;
using MyApp.Data.Models;

namespace MyApp.Data.Repository
{
    /// <summary>
    /// Represents common logic for dealing with a specific EntityFramework Entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey> 
        where TKey : class
    {
        protected MyAppContext Context { get; private set; }

        protected RepositoryBase()
        {
            Context = new MyAppContext();
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public virtual TEntity Get(TKey id)
        {
            return Context.Set<TEntity>().Single(x => x.Id == id);
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            var entity = await Context.Set<TEntity>().SingleAsync(x => x.Id == id);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(IQueryable<TEntity> query)
        {
            return await query.ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual TKey Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity.Id;
        }

        public virtual async Task<TKey> CreateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public virtual void Remove(TKey id)
        {
            var entity = Context.Set<TEntity>().Single(x => x.Id == id);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            var entity = Context.Set<TEntity>().Single(x => x.Id == id);
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }
    }
}
