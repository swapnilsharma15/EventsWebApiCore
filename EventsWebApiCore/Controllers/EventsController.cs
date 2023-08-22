using EventsWebApiCore.Data;
using EventsWebApiCore.Models;
using EventsWebApiCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EventsWebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;
        public EventsController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        [HttpGet("GetEvents")]
        public async Task<IEnumerable<Event>> GetEvents(
             [FromQuery] int page = 1,
             [FromQuery] int pageSize = 10)
        {
            return await eventService.GetEvents(page, pageSize);
        }

        [HttpGet("GetEventInfo/{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var eventViewModel = await eventService.GetEventInfo(id);

            if(eventViewModel != null)
            {
                return Ok(eventViewModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateEvent")]
        public async Task<Event> CreateEvent(Event eventItem)
        {
            return await eventService.CreateEvent(eventItem);
        }

        [HttpPut("EditEventDetails")]
        public async Task<IActionResult> EditEvent([FromBody] Event updatedEvent)
        {
            var updatedEventObj = eventService.CreateEvent(updatedEvent);

            if (updatedEventObj == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(updatedEventObj);
            }
        }
    }
}
