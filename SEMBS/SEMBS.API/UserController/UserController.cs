using Microsoft.AspNetCore.Mvc;
using SEMBS.SEMBS.Models.DTO;
using SEMBS.SEMBS.Service.Contracts;

namespace SEMBS.SEMBS.API.UserController
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IActionResult AddNewUser(UserDTO userDTO)
        {
            return Ok(userService.AddNewUser(userDTO));
        }
    }
}
