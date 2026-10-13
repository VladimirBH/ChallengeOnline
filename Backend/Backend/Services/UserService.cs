using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.Database;
using Backend.Database.Models;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services;

public class UserService
{
    private readonly JwtOptions _jwtOptions;
    private readonly ChallengeContext _challengeContext;

    public UserService(JwtOptions jwtOptions, ChallengeContext challengeContext)
    {
        _jwtOptions = jwtOptions;
        _challengeContext = challengeContext;
    }

    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }

    private static string HashRefreshToken(string token)
    {
        return Convert.ToHexString(SHA512.HashData(Encoding.UTF8.GetBytes(token)));
    }

    public string CreateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey));
        
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        
        var now = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddSeconds(_jwtOptions.AccessTokenLifetime), 
            signingCredentials: signingCredentials);
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task<AuthToken> CreateTokenPair(User user, CancellationToken cancellationToken = default)
    {
        var accessToken = CreateAccessToken(user);
        var refreshToken = GenerateRefreshToken();

        var entity = new AuthToken()
        {
            
        }
}
}