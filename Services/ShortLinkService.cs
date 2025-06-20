using System.Text;
using System;
using ShortLinkBackend.Interfaces;
using ShortLinkBackend.Models;
using System.Security.Cryptography;

namespace ShortLinkBackend.Services
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly IShortLinkRepositroy _shortLinkRepository;
        private readonly IUserRespository _userRespository;

        private const string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int _shortCodeLength = 6;
        public ShortLinkService(IShortLinkRepositroy shortLinkRepositroy, IUserRespository userRespository) 
        {
            _shortLinkRepository = shortLinkRepositroy;
            _userRespository = userRespository;
        }
        public async Task<ShortLink> CreateShortLinkAsync(string longUrl, int userId)
        {
            string shortCode;

            do
            {
                shortCode = GenerateShortCode(longUrl); // или без longUrl, если нужен случайный код
            }
            while (await _shortLinkRepository.ExistsByShortUrlAsync(shortCode));

            var link = new ShortLink
            {
                LongUrl = longUrl,
                ShortUrl = shortCode,
                CreatedDate = DateTime.UtcNow,
                CreatedById = userId
            };
            await _shortLinkRepository.AddLinkAsync(link);
            await _shortLinkRepository.SaveChangesAsync();
            return link;
        }



        public async Task<IEnumerable<ShortLink>> GetAllLinksAsync()
        {
            return await _shortLinkRepository.GetAllLinksAsync();
        }

        public async Task<ShortLink?> UpdateShortLinkAsync(ShortLink shortLink)
        {
            var existingLink = await _shortLinkRepository.GetLinkByIdAsync(shortLink.Id);
            if (existingLink == null)
            {
                return null;
            }

            existingLink.LongUrl = shortLink.LongUrl;
            existingLink.ShortUrl = shortLink.ShortUrl;

            await _shortLinkRepository.SaveChangesAsync();
            return existingLink;
        }

        public async Task<ShortLink?> GetByIdAsync(int id)
        {
            return await _shortLinkRepository.GetLinkByIdAsync(id);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var link = await _shortLinkRepository.GetLinkByIdAsync(id);
            if (link == null)
            {
                return false;
            }
            _shortLinkRepository.DeleteLink(link);
            await _shortLinkRepository.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(ShortLink shortLink)
        {
            _shortLinkRepository.DeleteLink(shortLink);
            await _shortLinkRepository.SaveChangesAsync();
        }

        private string GenerateShortCode(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input + Guid.NewGuid()));
            var builder = new StringBuilder();

            for (int i = 0; i < _shortCodeLength; i++)
            {
                var index = bytes[i] % _chars.Length;
                builder.Append(_chars[index]);
            }

            return builder.ToString();
        }


    }
}
