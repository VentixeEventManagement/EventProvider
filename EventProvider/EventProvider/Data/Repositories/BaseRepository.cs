using EventProvider.Data.Contexts;
using EventProvider.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

/// <remarks>
/// This code was formatted and refined using AI assistance.
/// </remarks>

namespace EventProvider.Data.Repositories
{
    /// <summary>
    /// Provides a base implementation of common data access methods for entities using Entity Framework Core.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The database context used for data operations.
        /// </summary>
        protected readonly DataContext _context;

        /// <summary>
        /// The DbSet representing the collection of entities in the context.
        /// </summary>
        protected readonly DbSet<TEntity> _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The database context to use.</param>
        public BaseRepository(DataContext context)
        {
            _context = context;
            _db = context.Set<TEntity>();
        }

        /// <summary>
        /// Adds a new entity to the data store asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the entity was added successfully; otherwise, false.
        /// </returns>
        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Retrieves a single entity that matches the specified condition.
        /// </summary>
        /// <param name="expression">The condition to match the entity against.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the entity if found; otherwise, null.
        /// </returns>
        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _db.FirstOrDefaultAsync(expression);
            return entity;
        }

        /// <summary>
        /// Retrieves all entities from the data store asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of all entities.
        /// </returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _db.ToListAsync();
            return entities;
        }

        /// <summary>
        /// Checks if any entities exist that match the specified condition.
        /// </summary>
        /// <param name="expression">The condition to match entities against.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if any matching entities exist; otherwise, false.
        /// </returns>
        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _db.AnyAsync(expression);
            return result;
        }

        /// <summary>
        /// Updates an existing entity in the data store asynchronously.
        /// </summary>
        /// <param name="entity">The entity with updated data.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the entity was updated successfully; otherwise, false.
        /// </returns>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _db.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Removes an entity from the data store asynchronously.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the entity was removed successfully; otherwise, false.
        /// </returns>
        public async Task<bool> RemoveAsync(TEntity entity)
        {
            try
            {
                _db.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}