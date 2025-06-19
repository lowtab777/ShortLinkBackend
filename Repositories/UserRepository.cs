using Microsoft.EntityFrameworkCore;
using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;
using ShortLinkBackend.ShortLinkDbContext;

namespace ShortLinkBackend.Repositories
{
    public class UserRepository : IUserRespository
    {
        private readonly ShortUrlDbContext _context;

        public UserRepository(ShortUrlDbContext context) 
        {
            _context = context;
        }
        public async Task<User?> AddUserAsync(User user)
        {
            return  (await _context.Users.AddAsync(user)).Entity;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
