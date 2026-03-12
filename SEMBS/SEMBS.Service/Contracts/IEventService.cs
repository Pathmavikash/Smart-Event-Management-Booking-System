using SEMBS.SEMBS.Models.Entities;

namespace SEMBS.SEMBS.Service.Contracts
{
    public interface IEventService
    {
        public Task<bool> AddNewEvent(EventDTO eventDTO);
        public Task<List<EventDTO>> GetMyEvents(int userId);
        public Task<List<EventDTO>> GetAllEvents();
    }
}
