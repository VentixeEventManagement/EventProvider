using EventProvider.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventProvider.Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<EventEntity> Events { get; set; }
    }
}
