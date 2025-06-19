using Microsoft.EntityFrameworkCore;
using ShortLinkBackend.Models;

namespace ShortLinkBackend.ShortLinkDbContext
{
    public class ShortUrlDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ShortLink> ShortLinks { get; set; }
        public ShortUrlDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        } 
    }
}
