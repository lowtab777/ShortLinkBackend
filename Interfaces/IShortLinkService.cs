using ShortLinkBackend.Models;

namespace ShortLinkBackend.Interfaces
{
    public interface IShortLinkService
    {
        Task<IEnumerable<ShortLink>> GetAllLinksAsync();
        Task<ShortLink?> GetByIdAsync(int id);
        Task<ShortLink> CreateShortLinkAsync(string longUrl, int userId);
        Task<ShortLink?> UpdateShortLinkAsync(ShortLink shortLink);

        Task DeleteAsync(ShortLink shortLink);
        Task<bool> DeleteByIdAsync(int id);
    }
}
