using BlazorApp1.Server.Services.Infrastructure;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly  IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpGet("GetUsers")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = await userService.GetUsers()
        };
        }

    }
}
