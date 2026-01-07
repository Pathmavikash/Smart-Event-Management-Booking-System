using SEMBS.SEMBS.Data;
using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Models.Entities;

namespace SEMBS.SEMBS.Engines.Implementations
{
    public class UserEngine : IUserEngine
    {
        private readonly AppDbContext appDbContext;

        public UserEngine(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
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
                appDbContext.Users.Add(user);
                int rowsaffected = appDbContext.SaveChanges();
                return rowsaffected > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
