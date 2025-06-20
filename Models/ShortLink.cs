namespace ShortLinkBackend.Models
{
    public class ShortLink
    {
        public int Id { get; set; }
        public string LongUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public int CreatedById { get; set; }
        public User? CreatedBy { get; set; }
    }
}
