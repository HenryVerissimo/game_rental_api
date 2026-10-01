using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GameRentalApi.Infrastructure.Services;


public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user, List<Role> roles)
    {
        string jwtSecretKey = _configuration["JWT:SECRETKEY"]
            ?? throw new InvalidOperationException("Environment variable JWT__SECRETKEY not implemented!");

        int jwtExpireInMinutes = Convert.ToInt32(_configuration["JWT:EXPIREINMINUTES"]
                ?? throw new InvalidOperationException("Environment variable JWT__EXPIREINMINUTES not implemented!"));

        string jwtIssuer = _configuration["JWT:ISSUER"]
                ?? throw new InvalidOperationException("Environment variable JWT__ISSUER not implemented!");

        string jwtAudience = _configuration["JWT:AUDIENCE"]
                ?? throw new InvalidOperationException("Environment variable JWT__AUDIENCE not implemented!");

        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.UTF8.GetBytes(jwtSecretKey);
        SigningCredentials credentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        List<Claim> claims = new()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
        };

        foreach (Role role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(jwtExpireInMinutes),
            Issuer = jwtIssuer,
            Audience = jwtAudience,
            SigningCredentials = credentials
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}