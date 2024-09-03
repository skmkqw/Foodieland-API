using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Foodieland.Application.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Foodieland.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-keysuper-secret-key")), 
            SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            claims: claims, 
            signingCredentials: signingCredentials, 
            issuer: "Foodieland",
            expires: DateTime.Now.AddDays(1));
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}