using Microsoft.AspNetCore.Mvc;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Service.Contracts;
using SEMBS.SEMBS.Service.Implementations;

namespace SEMBS.SEMBS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;
        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        [HttpPost]
        public IActionResult AddNewEvent(EventDTO eventDetails)
        {
            return Ok(eventService.AddNewEvent(eventDetails));  
        }
    }
}
