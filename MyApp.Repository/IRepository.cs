using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : IEntity<TKey>
        where TKey : class
    {
        /// <summary>
        /// Used for performing queries directly with entities - Needs discussion
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Query();

        /// <summary>
        /// Returns the entity object with the specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Updates the entity entry in the context
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Creates a new entity and returns the generated Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TKey Create(TEntity entity);

        /// <summary>
        /// Removes the entity
        /// </summary>
        /// <param name="id"></param>
        void Remove(TKey id);

        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAsync(IQueryable<TEntity> query);
    }
}
