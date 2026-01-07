using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Service.Contracts;

namespace SEMBS.SEMBS.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserEngine userEngine;
        public UserService(IUserEngine userEngine) 
        {
            this.userEngine = userEngine;
        }
        public bool AddNewUser(UserDTO userDTO)
        {
            return userEngine.AddNewUser(userDTO);
        }
    }
}
