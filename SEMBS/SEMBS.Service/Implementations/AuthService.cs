using Azure.Core;
using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Models.Entities;
using SEMBS.SEMBS.Service.Contracts;

namespace SEMBS.SEMBS.Service.Implementations
{
    public class AuthService : IAuthService
    {
        public static string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        private readonly IAuthEngine _engine;
        private readonly JwtTokenService _jwtTokenService;

        public AuthService(IAuthEngine engine, JwtTokenService jwtTokenService)
        {
            _engine = engine;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<LoginResponseDTO> Login(LoginDTO loginDTO)
        {
            var user = await _engine.ValidateUser(loginDTO);

            if (user == null)
            {
                return new LoginResponseDTO
                {
                    AccessToken = "",
                    ExpiresIn = 0,
                    Role = "",
                    UserId = 0,
                    FullName = ""
                };
            }
            var token = _jwtTokenService.GenerateToken(user.Id, user.Email, user.RoleName);

            return new LoginResponseDTO
            {
                AccessToken = token,
                ExpiresIn = 3600,
                Role = user.RoleName,
                UserId = user.Id,
                FullName = string.Join(" ", user.FirstName, user.LastName)
            };
        }
        public async Task<bool> Register(RegisterDTO registerDTO)
        {
            User user = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                RoleName = registerDTO.RoleName,
                Password = Hash(registerDTO.Password)
            };
            return await _engine.RegisterUser(user);
        }
    }
}
