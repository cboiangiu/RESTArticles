using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RESTArticlesLibrary.Interfaces.Services;

namespace RESTArticlesLibrary.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken()
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTIssuerSigningKey"]!));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] { new Claim(ClaimTypes.Name, "Bob") };

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signingCredentials,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
