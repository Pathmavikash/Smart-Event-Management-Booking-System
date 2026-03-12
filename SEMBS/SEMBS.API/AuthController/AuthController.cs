using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Service;
using SEMBS.SEMBS.Service.Contracts;

namespace SEMBS.SEMBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<bool> RegisterNewUser(RegisterDTO registerDTO)
        {
            return await _authService.Register(registerDTO);
        }

        [HttpPost("login")]
        public async Task<LoginResponseDTO> Login(LoginDTO request)
        {
            return await _authService.Login(request);
            
        }
    }
}
