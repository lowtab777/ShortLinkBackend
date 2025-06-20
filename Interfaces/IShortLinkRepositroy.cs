using ShortLinkBackend.Models;

namespace ShortLinkBackend.Interfaces
{
    public interface IShortLinkRepositroy
    {
        Task<ShortLink?> GetLinkByIdAsync(int id);
        Task<ShortLink?> GetLinkByLongUrlAsync(string longUrl);
        Task<ShortLink?> GetLinkByShortUrlAsync(string shortUrl);

        Task<IEnumerable<ShortLink>> GetAllLinksAsync();

        Task AddLinkAsync(ShortLink link);
        void DeleteLink(ShortLink link);

        Task SaveChangesAsync();

        Task<bool> ExistsByShortUrlAsync(string shortCode);
    }
}
