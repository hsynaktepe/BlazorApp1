using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorApp1.Server.Data.Context;
using BlazorApp1.Server.Data.Models;
using BlazorApp1.Server.Services.Infrastructure;
using BlazorApp1.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        public async Task<UserDTO> CreateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser != null)
                throw new Exception("Kullanıcı zaten mevcut!");

            dbUser = mapper.Map<Users>(User);

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
