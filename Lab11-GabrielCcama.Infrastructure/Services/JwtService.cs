using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lab11_GabrielCcama.Application.Interfaces;
using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Lab11_GabrielCcama.Infrastructure.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var roles = user.UserRoles.Select(ur => ur.Role.RoleName);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
        };
        // Añadir roles como Claims (múltiples ClaimTypes.Role)
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}