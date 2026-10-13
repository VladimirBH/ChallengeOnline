using Backend.Models;

namespace Backend.DTO;

public class UserAuthDTO
{
    public AuthToken? AuthToken { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}