﻿using System.IdentityModel.Tokens.Jwt;

namespace RESTArticlesLibrary.Interfaces.Services;

public interface IAuthService
{
    string GenerateToken();
}
