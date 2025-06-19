using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;

namespace ShortLinkBackend.Services
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly IShortLinkRepositroy _shortLinkRepositroy;
        public ShortLinkService(IShortLinkRepositroy shortLinkRepositroy) 
        {
            _shortLinkRepositroy = shortLinkRepositroy;
        }
        public Task<ShortLink> CreateShortLinkAsync(string longUrl, int userId)
        {
            // todo
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            await _shortLinkRepositroy.GetLinkByIdAsync(id);
            await _shortLinkRepositroy.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShortLink>> GetAllLinksAsync()
        {
            return await _shortLinkRepositroy.GetAllLinksAsync();
        }

        public async Task<ShortLink?> GetByIdAsync(int id)
        {
            return await _shortLinkRepositroy.GetLinkByIdAsync(id);
        }

        public async Task<IEnumerable<ShortLink>> GetByUserAsync(int userId)
        {
            throw new NotImplementedException();
           
        }
    }
}
