using EventProvider.Business.Models;
using EventProvider.Data.Entities;

/// <remarks>
/// This code was formatted and refined using AI assistance.
/// </remarks>

namespace EventProvider.Business.Factories
{
    /// <summary>
    /// Provides factory methods for creating Event and EventEntity objects.
    /// </summary>
    public static class EventFactory
    {
        /// <summary>
        /// Creates an EventEntity from an EventRegistrationModel.
        /// </summary>
        /// <param name="form">The registration model containing event data.</param>
        /// <returns>A new EventEntity or null if the input is null.</returns>
        public static EventEntity? Create(EventRegistrationModel form) => form == null ? null : new()
        {
            Name = form.Name,
            Description = form.Description,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            Location = form.Location,
            TicketPrice = form.TicketPrice,
            TicketAmount = form.TicketAmount
        };

        /// <summary>
        /// Creates an Event model from an EventEntity.
        /// </summary>
        /// <param name="entity">The entity containing event data.</param>
        /// <returns>A new Event model or null if the input is null.</returns>
        public static Event? Create(EventEntity entity)
        {
            if (entity == null)
                return null;

            return new Event
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Location = entity.Location,
                TicketPrice = entity.TicketPrice,
                TicketAmount = entity.TicketAmount
            };
        }
    }
}