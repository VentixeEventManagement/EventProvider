// This code was formatted and refined using AI assistance.
using EventProvider.Data.Entities;
using Microsoft.EntityFrameworkCore;



namespace EventProvider.Data.Contexts
{
    /// <summary>
    /// Represents the Entity Framework database context for the application.
    /// Provides access to the database tables and manages entity objects during runtime.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the events table in the database.
        /// </summary>
        public DbSet<EventEntity> Events { get; set; }
    }
}
