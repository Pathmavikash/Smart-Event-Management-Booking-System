using SEMBS.SEMBS.Models.DTO;

namespace SEMBS.SEMBS.Service.Contracts
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterDTO registerDTO);
        public Task<LoginResponseDTO> Login(LoginDTO loginDTO);
    }
}
