using ShortLinkBackend.Models;

namespace ShortLinkBackend.Interfaces
{
    public interface IShortLinkService
    {
        Task<IEnumerable<ShortLink>> GetAllLinksAsync();
        Task<ShortLink?> GetByIdAsync(int id);
        Task<IEnumerable<ShortLink>> GetByUserAsync(int userId);
        Task<ShortLink> CreateShortLinkAsync(string longUrl, int userId);

        Task DeleteAsync(int id);
    }
}
