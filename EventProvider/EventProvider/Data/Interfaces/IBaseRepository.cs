using System.Linq.Expressions;

/// <remarks>
/// This code was formatted and refined using AI assistance.
/// </remarks>

namespace EventProvider.Data.Interfaces
{
    /// <summary>
    /// Defines generic methods for basic data access operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds a new entity to the data store asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the entity was added successfully; otherwise, false.
        /// </returns>
        Task<bool> AddAsync(TEntity entity);

        /// <summary>
        /// Checks if any entities exist that match the specified condition.
        /// </summary>
        /// <param name="expression">The condition to match entities against.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if any matching entities exist; otherwise, false.
        /// </returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Retrieves all entities from the data store asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of all entities.
        /// </returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieves a single entity that matches the specified condition.
        /// </summary>
        /// <param name="expression">The condition to match the entity against.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the entity if found; otherwise, null.
        /// </returns>
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Removes an entity from the data store asynchronously.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the entity was removed successfully; otherwise, false.
        /// </returns>
        Task<bool> RemoveAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the data store asynchronously.
        /// </summary>
        /// <param name="entity">The entity with updated data.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the entity was updated successfully; otherwise, false.
        /// </returns>
        Task<bool> UpdateAsync(TEntity entity);
    }
}