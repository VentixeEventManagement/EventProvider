using EventProvider.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventProvider.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected DataContext()
        {
        }

        public DbSet<EventEntity> Customers { get; set; }
    }
}
