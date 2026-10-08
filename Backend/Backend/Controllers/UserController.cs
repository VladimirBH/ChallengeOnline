using Backend.Database;
using Backend.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ChallengeContext _context;

    public UserController(ChallengeContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        var curUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

        if (curUser != null)
        {
            return Ok();
        }

        return Unauthorized(new {message = "Неверный логин или пароль"});
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        
    }
}