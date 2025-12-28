using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.AppUsers.Result;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShuttleRouteManager.Infrastructure.Services;

internal sealed class JwtService(IConfiguration configuration) : IJwtService
{
    public Task<LoginQueryResult> GenerateTokenAsync(GetAppUsersQueryResult user)
    {
        var claims = new List<Claim>
    {
        new("sub", user.Id.ToString()),
        new("email", user.Email),
        new("name", $"{user.FirstName} {user.LastName}"),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expireMinutes = int.Parse(configuration["JwtSettings:ExpirationMinutes"]!);
        var expiration = DateTime.UtcNow.AddMinutes(expireMinutes);

        var token = new JwtSecurityToken(
            issuer: configuration["JwtSettings:Issuer"],
            audience: configuration["JwtSettings:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        var result = new LoginQueryResult
        {
            Token = tokenString,
            ExpirationTime = expiration,
            User = user
        };

        return Task.FromResult(result);
    }
}
