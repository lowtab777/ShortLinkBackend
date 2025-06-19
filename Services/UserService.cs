using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;

namespace ShortLinkBackend.Services
{
    public class UserService : IUserService
    {
        public UserService() { }

        public Task<User?> AuthenticateUserAsync(string name, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
