using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Data.Models;

namespace MyApp.Data.Repository
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : IEntity<TKey>
        where TKey : class
    {
        /// <summary>
        /// Returns an <see cref="IQueryable{TEntity}"/>/>
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Query();
        
        /// <summary>
        /// Returns the <see cref="TEntity"/> with the specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Returns the entity object with the specified Id as an asynchronous operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Executes and returns the results of the <see cref="IQueryable"/> as an asynchronous operation
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(IQueryable<TEntity> query);

        /// <summary>
        /// Updates the <see cref="TEntity"/> 
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates the <see cref="TEntity"/> as an asynchronous operation
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Creates a new <see cref="{TEntity}"/> and returns the generated Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TKey Create(TEntity entity);

        /// <summary>
        /// Creates a new entity and returns the generated Id as an asynchronous operation
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TKey> CreateAsync(TEntity entity);

        /// <summary>
        /// Removes the <see cref="TEntity"/>
        /// </summary>
        /// <param name="id"></param>
        void Remove(TKey id);

        /// <summary>
        /// Removes the <see cref="TEntity"/> as an asynchronous operation
        /// </summary>
        /// <param name="id"></param>
        Task RemoveAsync(TKey id);
    }
}
