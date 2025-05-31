using Swashbuckle.AspNetCore.Filters;
using EventProvider.Business.Models;
using System;

namespace EventProvider.SwaggerExamples
{
    /// <summary>
    /// Provides a sample <see cref="Event"/> instance for Swagger documentation.
    /// </summary>
    public class EventExample : IExamplesProvider<Event>
    {
        /// <summary>
        /// Returns an example <see cref="Event"/> object with realistic sample data.
        /// </summary>
        /// <returns>
        /// An <see cref="Event"/> instance representing a typical event, used for Swagger UI examples.
        /// </returns>
        public Event GetExamples()
        {
            return new Event
            {
                Id = 1,
                Name = "comicon",
                Description = "Annual comic and pop culture convention.",
                StartDate = DateTime.Parse("2025-05-28T12:12:03.663Z"),
                EndDate = DateTime.Parse("2025-05-29T18:00:00.000Z"),
                Location = "Convention Center, Cityville",
                TicketPrice = 49,
                TicketAmount = "500"
            };
        }
    }
}