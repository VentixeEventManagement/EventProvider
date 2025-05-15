using EventProvider.Business.Models;

namespace EventProvider.Business.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventByIdAsync(int eventId);
    }
}