using Microsoft.EntityFrameworkCore;
using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;
using ShortLinkBackend.ShortLinkDbContext;

namespace ShortLinkBackend.Repositories
{
    public class ShortLinkRepository : IShortLinkRepositroy
    {
        private readonly ShortUrlDbContext _context;
        public ShortLinkRepository(ShortUrlDbContext context) 
        {
            _context = context;
        }
        public async Task AddLinkAsync(ShortLink link)
        {
            await _context.ShortLinks.AddAsync(link);
        }

        public void DeleteLink(ShortLink link)
        {
            _context.ShortLinks.Remove(link);
        }

        public async Task<IEnumerable<ShortLink>> GetAllLinksAsync()
        {
            return await _context.ShortLinks.ToListAsync();
        }

        public async Task<ShortLink?> GetLinkByShortUrlAsync(string shortUrl)
        {
            return await _context.ShortLinks.FirstOrDefaultAsync(s => s.ShortUrl == shortUrl);
        }

        public async Task<ShortLink?> GetLinkByIdAsync(int id)
        {
            return await _context.ShortLinks.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ShortLink?> GetLinkByLongUrlAsync(string longUrl)
        {
            return await _context.ShortLinks.FirstOrDefaultAsync(s => s.LongUrl == longUrl);
        }

        public async Task<bool> ExistsByShortUrlAsync(string shortCode)
        {
            return await _context.ShortLinks.AnyAsync(l => l.ShortUrl == shortCode);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
