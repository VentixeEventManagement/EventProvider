using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EventProvider.Data.Contexts;
using EventProvider.Data.Entities;

namespace EventProvider.Tests
{
    /// <summary>
    /// Custom WebApplicationFactory for integration testing.
    /// Configures the test host to use an in-memory database and seeds test data for events.
    /// </summary>
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                // Remove the app's DataContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                // Register the in-memory database for testing.
                services.AddDbContext<DataContext>(options =>
                    options.UseInMemoryDatabase("InMemoryTestDb"));

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database context.
                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                    db.Database.EnsureCreated();
                    try
                    {
                        InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<CustomWebApplicationFactory>>();
                        logger.LogError(ex, "An error occurred seeding the database. Error: {Message}", ex.Message);
                    }
                }
            });
        }

        /// <summary>
        /// Seeds the in-memory database with test event data.
        /// </summary>
        private void InitializeDbForTests(DataContext context)
        {
            // Clear existing data
            context.Events.RemoveRange(context.Events);
            context.SaveChanges();

            // Add test event data
            context.Events.AddRange(
                new EventEntity
                {
                    Id = 1,
                    Name = "Test Event 1",
                    Description = "Description for Test Event 1",
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2),
                    Location = "Test Location 1",
                    TicketPrice = 100,
                    TicketAmount = "100"
                },
                new EventEntity
                {
                    Id = 2,
                    Name = "Test Event 2",
                    Description = "Description for Test Event 2",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(4),
                    Location = "Test Location 2",
                    TicketPrice = 150,
                    TicketAmount = "200"
                }
            );

            context.SaveChanges();
        }
    }
}
