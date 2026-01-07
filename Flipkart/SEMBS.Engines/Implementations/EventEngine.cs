using SEMBS.SEMBS.Data;
using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.Entities;

namespace SEMBS.SEMBS.Engines.Implementations
{
    public class EventEngine : IEventEngine
    {
        private readonly AppDbContext appDbContext;

        public EventEngine(AppDbContext _appDbContext)
        {
            this.appDbContext = _appDbContext;
        }

        public bool AddNewEvent(EventDTO eventDtls)
        {
            Event eventInfo = new Event
            {
                Title = eventDtls.Title,
                Description = eventDtls.Description,
                Date = eventDtls.Date,
                Venue = eventDtls.Venue,
                Capacity = eventDtls.Capacity,
                OrganizerId = 1
            };
            try
            {
                appDbContext.Events.Add(eventInfo);
                int rowsAffected = appDbContext.SaveChanges();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
