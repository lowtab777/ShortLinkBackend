﻿using ShortLinkBackend.Models;

namespace ShortLinkBackend.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
