using Microsoft.AspNetCore.Mvc;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Service.Contracts;

namespace SEMBS.SEMBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;
        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        [HttpPost("create")]
        public async Task<bool> AddNewEvent(EventDTO eventDetails)
        {
            return await eventService.AddNewEvent(eventDetails);  
        }
        [HttpGet("getMyEvents/{userId}")]
        public async Task<List<EventDTO>> GetMyEvents(int userId)
        {
            return await eventService.GetMyEvents(userId);
        }
        [HttpGet("getAllEvents")]
        public async Task<List<EventDTO>> GetAllEvents()
        {
            return await eventService.GetAllEvents();
        }
    }
}
