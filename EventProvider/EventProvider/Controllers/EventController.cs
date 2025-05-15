using EventProvider.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventProvider.Business.Models;

namespace EventProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IEventService eventService) : ControllerBase
    {
        private readonly IEventService _eventService = eventService;

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventService.GetEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventobj = await _eventService.GetEventByIdAsync(id);
            if (eventobj == null)
            {
                return NotFound();
            }
            return Ok(eventobj);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventRegistrationModel form)
        {
            if (!ModelState.IsValid && form.Id < 1)
                return BadRequest();

            var result = await _eventService.CreateEventAsync(form);
            return result ? Created("", null) : Problem();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditProject(int id, EventRegistrationModel form)
        {
            if (!ModelState.IsValid && form.Id < 1)
                return BadRequest();

            var result = await _eventService.EditEventAsync(id, form);
            return result ? Ok("Event got updated") : BadRequest("failed to update Event");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEventAsync(id);
            return result ? Ok("Event got deleted") : BadRequest("failed to delete Event");
        }


    }
}
