using SEMBS.SEMBS.Models.Entities;

namespace SEMBS.SEMBS.Engines.Contracts
{
    public interface IEventEngine
    {
        public bool AddNewEvent(EventDTO eventDTO);
    }
}
