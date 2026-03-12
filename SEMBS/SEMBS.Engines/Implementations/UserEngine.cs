using SEMBS.SEMBS.Data;
using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Repository.Contracts;

namespace SEMBS.SEMBS.Engines.Implementations
{
    public class UserEngine : IUserEngine
    {
        private readonly AppDbContext appDbContext;
        private readonly IGenericRepository<User> genericRepository;

        public UserEngine(AppDbContext appDbContext, IGenericRepository<User> genericRepository)
        {
            this.appDbContext = appDbContext;
            this.genericRepository = genericRepository;
        }
        public bool AddNewUser(UserDTO userDTO)
        {
            User user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                RoleId = userDTO.RoleId
            };
            try
            {
                genericRepository.AddAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
