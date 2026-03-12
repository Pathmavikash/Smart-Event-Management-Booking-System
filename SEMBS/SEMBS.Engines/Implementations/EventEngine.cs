using SEMBS.SEMBS.Data;
using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Repository.Contracts;

namespace SEMBS.SEMBS.Engines.Implementations
{
    public class EventEngine : IEventEngine
    {
        private readonly AppDbContext appDbContext;
        private readonly IGenericRepository<Event> genericRepository;

        public EventEngine(AppDbContext _appDbContext, IGenericRepository<Event> genericRepository)
        {
            this.appDbContext = _appDbContext;
            this.genericRepository = genericRepository;
        }

        public async Task<bool> AddNewEvent(Event eventDtls)
        {
            try
            {
                await genericRepository.AddAsync(eventDtls);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<List<EventDTO>> GetMyEvents(int userId)
        {
            List<Event> events = appDbContext.Events.Where(e => e.OrganizerId == userId).ToList();
            List<EventDTO> eventDetailsList = [];
            foreach (var ev in events)
            {
                EventDTO eventDetails = new()
                {
                    Id = ev.Id,
                    Title = ev.Title,
                    Description = ev.Description,
                    Date = ev.Date,
                    Venue = ev.Venue,
                    Capacity = ev.Capacity,
                    OrganizerId = ev.OrganizerId,
                    Price = 1000
                };
                eventDetailsList.Add(eventDetails);
            }
            return eventDetailsList;
        }
        public async Task<List<EventDTO>> GetAllEvents()
        {
            List<Event> events = appDbContext.Events.ToList();
            List<EventDTO> eventDetailsList = [];
            foreach (var ev in events)
            {
                EventDTO eventDetails = new()
                {
                    Id = ev.Id,
                    Title = ev.Title,
                    Description = ev.Description,
                    Date = ev.Date,
                    Venue = ev.Venue,
                    Capacity = ev.Capacity,
                    OrganizerId = ev.OrganizerId,
                    Price = 1000
                };
                eventDetailsList.Add(eventDetails);
            }
            return eventDetailsList;
        }
    }
}
