using ShortLinkBackend.Models;

namespace ShortLinkBackend.Interfaces
{
    public interface IUserRespository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByNameAsync(string name);
        Task<IEnumerable<User>> GetAllUsersAsync(); 
        Task<User?> AddUserAsync(User user);

        void UpdateUser(User User);
        void DeleteUser(User id);

        Task SaveChangesAsync();
    }
}
