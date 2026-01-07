using SEMBS.SEMBS.Models.Entities;

namespace SEMBS.SEMBS.Service.Contracts
{
    public interface IEventService
    {
        public bool AddNewEvent(EventDTO eventDTO);
    }
}
