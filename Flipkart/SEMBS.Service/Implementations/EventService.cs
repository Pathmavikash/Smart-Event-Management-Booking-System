using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Engines.Implementations;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Service.Contracts;

namespace SEMBS.SEMBS.Service.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventEngine _engine;
        public EventService(IEventEngine engine)
        {
            _engine = engine;
        }

        public bool AddNewEvent(EventDTO eventDtls)
        {
            return _engine.AddNewEvent(eventDtls);
        }
    }
}
