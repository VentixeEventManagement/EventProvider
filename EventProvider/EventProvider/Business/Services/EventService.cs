using EventProvider.Data.Interfaces;
using EventProvider.Business.Models;
using EventProvider.Business.Factories;
using EventProvider.Business.Interfaces;
using EventProvider.Data.Entities;
using EventProvider.Data.Repositories;

namespace EventProvider.Business.Services
{
    public class EventService(IEventRepository eventRepository)
    {
        private readonly IEventRepository _eventRepository = eventRepository;

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            var entities = await _eventRepository.GetAllAsync();
            var events = entities.Select(EventFactory.Create);
            return events!;
        }

        public async Task<Event> GetProjectByIdAsync(int eventId)
        {
            var project = await _eventRepository.GetAsync(p => p.Id == eventId);
            if (project == null)
                return null!;
            return EventFactory.Create(event)!;

        }




    }
}
