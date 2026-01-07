using SEMBS.SEMBS.Models.DTO;

namespace SEMBS.SEMBS.Engines.Contracts
{
    public interface IUserEngine
    {
        public bool AddNewUser(UserDTO userDTO);
    }
}
