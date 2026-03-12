using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Models.Entities;

namespace SEMBS.SEMBS.Engines.Contracts
{
    public interface IAuthEngine
    {
        public Task<bool> RegisterUser(User user);
        public Task<User?> ValidateUser(LoginDTO loginDTO);
    }
}
