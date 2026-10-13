using Microsoft.IdentityModel.Tokens;

namespace Backend.Models;

public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; }= string.Empty;
    public string SecurityKey { get; set; }= string.Empty;
    public int AccessTokenLifetime { get; set; } = 1000;
}