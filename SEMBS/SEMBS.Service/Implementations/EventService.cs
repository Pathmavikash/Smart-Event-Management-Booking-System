using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Repository.Contracts;
using SEMBS.SEMBS.Service.Contracts;

namespace SEMBS.SEMBS.Service.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventEngine _engine;
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Role> _roleRepo;
        public EventService(IEventEngine engine, IGenericRepository<User> userRepo, IGenericRepository<Role> roleRepo)
        {
            _engine = engine;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public async Task<bool> AddNewEvent(EventDTO eventDtls)
        {
            User user = _userRepo.GetById(eventDtls.OrganizerId);
            if (user != null)
            {
                IsUserValidForCreate(user.RoleId);
                Event eventInfo = new Event
                {
                    Title = eventDtls.Title,
                    Description = eventDtls.Description,
                    Date = eventDtls.Date,
                    Venue = eventDtls.Venue,
                    Capacity = eventDtls.Capacity,
                    OrganizerId = eventDtls.OrganizerId,
                    Price = eventDtls.Price
                };
                return await _engine.AddNewEvent(eventInfo);
            }
            return false;
        }
        private bool IsUserValidForCreate(int roleId)
        {
            Role role = _roleRepo.GetById(roleId);
            if (role.Name == "Organizer")
            {
                return true;
            }
            return false;
        }
        public async Task<List<EventDTO>> GetMyEvents(int userId)
        {
            if(userId > 0)
            {
                return await _engine.GetMyEvents(userId);
            }
            else
            {
                return new List<EventDTO>();
            }
        }
        public async Task<List<EventDTO>> GetAllEvents()
        {
            return await _engine.GetAllEvents();
        }
    }
}
