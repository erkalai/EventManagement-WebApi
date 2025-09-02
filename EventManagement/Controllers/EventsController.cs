using EventManagement.Entities;
using EventManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;
        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await eventService.GetEventsAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var ev = await eventService.GetEventByIdAsync(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event ev)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdEvent = await eventService.CreateEventAsync(ev);
                return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.EventId }, createdEvent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id, Event ev)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != ev.EventId)
                return BadRequest("Event ID Mismatch");

            var existingEvent = await eventService.GetEventByIdAsync(id);
            if (existingEvent == null)
                return NotFound();

            var updated = await eventService.UpdateEventAsync(ev);

            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var existingEvent = await eventService.GetEventByIdAsync(id);
            if (existingEvent == null)
                return NotFound();
            var deleted = await eventService.DeleteEventAsync(id);
            return deleted ? NoContent() : BadRequest("Failed to delete the event.");
        }
    }
}
