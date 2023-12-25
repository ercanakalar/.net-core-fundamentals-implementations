using auth_deneme.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auth_deneme;

[ApiController]
[Route("api/auth/[action]")]
public class GetAllUsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public GetAllUsersController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [ActionName("users")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }
}
