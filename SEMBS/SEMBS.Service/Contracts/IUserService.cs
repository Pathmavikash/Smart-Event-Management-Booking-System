using SEMBS.SEMBS.Models.DTO;

namespace SEMBS.SEMBS.Service.Contracts
{
    public interface IUserService
    {
        public bool AddNewUser(UserDTO userDTO);
    }
}
