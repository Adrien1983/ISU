using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Jhon Doe" },
        new User { Id = 2, Name = "Jane Doe" }
    };

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _users.Where(u => u.Id == id).FirstOrDefault();
        if (user == null)
            return NotFound();
        return Ok(user);
    }
}