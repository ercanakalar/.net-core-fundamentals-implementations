using auth_deneme.Data;
using Microsoft.AspNetCore.Mvc;

namespace auth_deneme;

[ApiController]
[Route("api/auth/[action]")]
public class GetUserByIdController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public GetUserByIdController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ActionName("signin")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return BadRequest("User not found.");
        return Ok(user);
    }
}

