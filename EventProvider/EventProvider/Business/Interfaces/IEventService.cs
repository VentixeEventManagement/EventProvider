using EventProvider.Business.Models;

namespace EventProvider.Business.Interfaces
{
    public interface IEventService
    {
        Task<bool> CreateEventAsync(EventRegistrationModel eventData);
        Task<bool> DeleteEventAsync(int eventId);
        Task<bool> EditEventAsync(int eventId, EventRegistrationModel newEventData);
        Task<Event?> GetEventByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetEventsAsync();
    }
}