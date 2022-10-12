using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorApp1.Server.Data.Context;
using BlazorApp1.Server.Data.Models;
using BlazorApp1.Server.Services.Infrastructure;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorApp1.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;
        private readonly IConfiguration configuration;

        public UserService(IMapper Mapper, DataContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }

        public async Task<UserLoginResponseDTO> Login(string Email, string Password)
        {
            // Veritabanı Kullanıcı Doğrulama İşlemleri Yapıldı.

            var encryptedPassword = PasswordEncrypter.Encrypt(Password);

            var dbUser = await context.Users.FirstOrDefaultAsync(i => i.EmailAdress == Email && i.Password == encryptedPassword);

            if (dbUser == null)
                throw new Exception("User not found or given information is wrong");

            if (!dbUser.IsActive)
                throw new Exception("User state is Passive!");


            UserLoginResponseDTO result = new UserLoginResponseDTO();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(configuration["JwtExpiryInDays"].ToString()));

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName ),
                new Claim(ClaimTypes.UserData, dbUser.Id.ToString())
            };

            var token = new JwtSecurityToken(configuration["JwtIssuer"], configuration["JwtAudience"], claims, null, expiry, creds);

            result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
            result.User = mapper.Map<UserDTO>(dbUser);

            return result;
        }


        public async Task<UserDTO> CreateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser != null)
                throw new Exception("Kullanıcı zaten mevcut!");

            dbUser = mapper.Map<Users>(User);
            dbUser.CreateDate = DateTime.Now;

            await context.Users.AddAsync(dbUser);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(dbUser);
        }

        public async Task<bool> DeleteUserById(int Id)
        {
            var dbUser = await context.Users.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbUser == null)
                throw new Exception("Kullanıcı bulunamadı!");

            context.Users.Remove(dbUser);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<UserDTO> GetUserById(int Id)
        {
            return await context.Users
                 .Where(i => i.Id == Id)
                 .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await context.Users
                 .Where(i => i.IsActive)
                 .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                 .ToListAsync();
        }

        public async Task<UserDTO> UpdateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser == null)
                throw new Exception("Kullanıcı bulunamadı!");

            //sadece değiştirilen alanı update etmesine yardımcı olmaktadır.
            //create üzerinde yapılan işlemde yeni bir instance oluştuğu için komple değişiklik yapılmış algılıyor
            //automapper dto ile context i karşılaştırarak bu işlemi gerçekleştirmektedir
            mapper.Map(User, dbUser);


            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(dbUser);
        }

   
    }
}
