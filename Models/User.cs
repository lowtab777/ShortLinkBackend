﻿namespace ShortLinkBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; }
        public ICollection<ShortLink> ShortLinks { get; set; }
    }
}
