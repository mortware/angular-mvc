using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyApp.DataAccess;
using MyApp.Repository;

namespace MyApp.Repository
{
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

        public async virtual Task<TEntity> GetAsync(TKey id)
        {
            var entity = await Context.Set<TEntity>().SingleAsync(x => x.Id == id);
            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAsync(IQueryable<TEntity> query)
        {
            return await query.ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual TKey Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity.Id;
        }

        public virtual void Remove(TKey id)
        {
            var entity = Context.Set<TEntity>().Single(x => x.Id == id);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
