using EventProvider.Business.Models;
using EventProvider.Data.Entities;

namespace EventProvider.Business.Factories
{
    public static class EventFactory
    {
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
                TicketsLeft = entity.TicketAmount
            };
        }
    }
}
