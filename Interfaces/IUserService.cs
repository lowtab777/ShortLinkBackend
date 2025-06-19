using ShortLinkBackend.Models;

namespace ShortLinkBackend.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> AuthenticateUserAsync(string name, string password);


    }
}
