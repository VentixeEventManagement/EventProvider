using System.Linq.Expressions;
using Data.Repositories;
using EventProvider.Data.Contexts;
using EventProvider.Data.Entities;
using EventProvider.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventProvider.Data.Repositories
{
    public class EventRepository : BaseRepository<EventEntity>, IEventRepository
    {
        public EventRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<EventEntity>> GetAllAsync()
        {
            var entities = await _db
                .ToListAsync();

            return entities;
        }

        public override async Task<EventEntity?> GetAsync(Expression<Func<EventEntity, bool>> expression)
        {
            var entity = await _db
                .FirstOrDefaultAsync(expression);

            return entity;
        }


        // add more advanced methods here like filtering by date, location, etc. 
    }
}
