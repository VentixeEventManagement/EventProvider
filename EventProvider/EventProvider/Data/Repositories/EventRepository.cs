using System.Linq.Expressions;
using EventProvider.Data.Contexts;
using EventProvider.Data.Entities;
using EventProvider.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventProvider.Data.Repositories
{
    /// <summary>
    /// Provides data access methods specific to event entities, using Entity Framework Core.
    /// </summary>
    public class EventRepository : BaseRepository<EventEntity>, IEventRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository"/> class with the specified data context.
        /// </summary>
        /// <param name="context">The database context to use for event data operations.</param>
        public EventRepository(DataContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves all event entities from the database asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of all event entities.
        /// </returns>
        public override async Task<IEnumerable<EventEntity>> GetAllAsync()
        {
            var entities = await _db.ToListAsync();
            return entities;
        }

        /// <summary>
        /// Retrieves a single event entity that matches the specified condition.
        /// </summary>
        /// <param name="expression">The condition to match the event entity against.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the event entity if found; otherwise, null.
        /// </returns>
        public override async Task<EventEntity?> GetAsync(Expression<Func<EventEntity, bool>> expression)
        {
            var entity = await _db.FirstOrDefaultAsync(expression);
            return entity;
        }

        // Add more advanced methods here like filtering by date, location, etc.
    }
}