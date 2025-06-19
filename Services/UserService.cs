using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;

namespace ShortLinkBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRespository _userRespository;
        public UserService(IUserRespository userRespository) 
        {
            _userRespository = userRespository;
        }

        public async Task<User?> AuthenticateUserAsync(string name, string password)
        {
            return await _userRespository.GetUserByNameAsync(name);
        }

        public async Task<User?> AddUserAsync(string name, string password)
        {
            var user = new User() {Name = name, PasswordHash = password, Role = "User" };
            var createdUser = await _userRespository.AddUserAsync(user);
            await _userRespository.SaveChangesAsync();
            return createdUser;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRespository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRespository.GetUserByIdAsync(id);
        }
    }
}
