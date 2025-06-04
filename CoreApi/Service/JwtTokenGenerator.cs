using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CoreApi.Service;

public class JwtTokenGenerator
{
   // private readonly IConfiguration _configuration;

    public JwtTokenGenerator()
    {
       
    }
    public string GenerateToken(string username, string secretKey, string issuer, string audience)
    {
        // Secret key (must be kept safe, usually in appsettings.json or env vars)
       
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Claims (can add email, role, etc.)
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        // Create token
        var token = new JwtSecurityToken(
            issuer: issuer,              // Who created the token
            audience: audience,      // Who the token is for
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
