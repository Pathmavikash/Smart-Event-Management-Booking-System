using SEMBS.SEMBS.Models.Entities;

namespace SEMBS.SEMBS.Engines.Contracts
{
    public interface IEventEngine
    {
        public Task<bool> AddNewEvent(Event eventDTO);
        public Task<List<EventDTO>> GetMyEvents (int userId);
        public Task<List<EventDTO>> GetAllEvents();
    }
}
