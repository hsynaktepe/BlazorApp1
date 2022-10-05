using BlazorApp1.Shared.DTO;

namespace BlazorApp1.Server.Services.Infrastructure
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserById (int id);
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> CreateUser(UserDTO User);
        public Task<UserDTO> UpdateUser(UserDTO User);
        public Task<bool> DeleteUserById(int id);
        public Task<UserLoginResponseDTO> Login(string EMail, string Password);

    }
}
