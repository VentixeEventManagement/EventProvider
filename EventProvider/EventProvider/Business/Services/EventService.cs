using EventProvider.Data.Interfaces;
using EventProvider.Business.Models;
using EventProvider.Business.Factories;
using EventProvider.Business.Interfaces;
using EventProvider.Data.Entities;
using System.Linq.Expressions;

namespace EventProvider.Business.Services
{
    /// <summary>
    /// Provides business logic for managing events, including creating, retrieving, updating, and deleting events.
    /// </summary>
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventService"/> class.
        /// </summary>
        /// <param name="eventRepository">The repository used to access event data.</param>
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Retrieves all events from the data store.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of all events.
        /// </returns>
        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            var entities = await _eventRepository.GetAllAsync();
            var events = entities.Select(EventFactory.Create);
            return events!;
        }

        /// <summary>
        /// Retrieves a specific event by its unique identifier.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the event if found; otherwise, null.
        /// </returns>
        public async Task<Event?> GetEventByIdAsync(int eventId)
        {
            var eventobj = await _eventRepository.GetAsync(p => p.Id == eventId);
            if (eventobj == null)
                return null!;
            return EventFactory.Create(eventobj)!;
        }

        /// <summary>
        /// Creates a new event using the provided registration data.
        /// </summary>
        /// <param name="eventData">The data for the event to be created.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the event was created successfully; otherwise, false.
        /// </returns>
        public async Task<bool> CreateEventAsync(EventRegistrationModel eventData)
        {
            var eventEntity = EventFactory.Create(eventData);

            if (eventEntity == null)
                return false;

            var result = await _eventRepository.AddAsync(eventEntity);
            return result;
        }

        /// <summary>
        /// Updates an existing event with new data.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event to update.</param>
        /// <param name="newEventData">The new data for the event.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the event was updated successfully; otherwise, false.
        /// </returns>
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

        /// <summary>
        /// Deletes an event with the specified unique identifier.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the event was deleted successfully; otherwise, false.
        /// </returns>
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