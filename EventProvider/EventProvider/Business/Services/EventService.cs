using EventProvider.Data.Interfaces;
using EventProvider.Business.Models;
using EventProvider.Business.Factories;
using EventProvider.Business.Interfaces;
using EventProvider.Data.Entities;
using System.Linq.Expressions;

namespace EventProvider.Business.Services
{
    public class EventService(IEventRepository eventRepository) : IEventService
    {
        private readonly IEventRepository _eventRepository = eventRepository;

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            var entities = await _eventRepository.GetAllAsync();
            var events = entities.Select(EventFactory.Create);
            return events!;
        }

        public async Task<Event?> GetEventByIdAsync(int eventId)
        {
            var eventobj = await _eventRepository.GetAsync(p => p.Id == eventId);
            if (eventobj == null)
                return null!;
            return EventFactory.Create(eventobj)!;

        }

        public async Task<bool> CreateEventAsync(EventRegistrationModel eventData)
        {

            var EventtEntity = EventFactory.Create(eventData);

            if (EventtEntity == null)
                return false;

            var result = await _eventRepository.AddAsync(EventtEntity);
            return result;
        }

        public async Task<bool> EditEventAsync(int eventId, EventRegistrationModel newEventData)
        {
            var targetEvent = await _eventRepository.GetAsync(e => e.Id == eventId);
            if (targetEvent == null)
                return false;

            targetEvent.Name = newEventData.Name;
            targetEvent.Description = newEventData.Description;
            targetEvent.StartDate = newEventData.StartDate;
            targetEvent.EndDate = newEventData.EndDate;
            targetEvent.Location = newEventData.Location;
            targetEvent.TicketPrice = newEventData.TicketPrice;
            targetEvent.TicketAmount = newEventData.TicketAmount;

            bool result = await _eventRepository.UpdateAsync(targetEvent);
            return result;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var targetEvent = await _eventRepository.GetAsync(e => e.Id == eventId);
            if (targetEvent == null)
                return false;

            bool result = await _eventRepository.RemoveAsync(targetEvent);
            return result;
        }





    }
}
