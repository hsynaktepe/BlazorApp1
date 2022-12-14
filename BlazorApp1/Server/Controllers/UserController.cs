using BlazorApp1.Server.Services.Infrastructure;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDTO>> Login(string Email, string Password)
        {
            return new ServiceResponse<UserLoginResponseDTO>()
            {
                Value = await userService.Login(Email, Password)
            };

        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = await userService.GetUsers()
        };
        }



        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.CreateUser(User)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.UpdateUser(User)
            };
        }

        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDTO>> GetUserById(int Id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.GetUserById(Id)
            };
        }


        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] int id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserById(id)
            };
        }

    }
}
