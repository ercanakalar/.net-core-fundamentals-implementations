using auth_deneme.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auth_deneme;

[ApiController]
[Route("api/auth/[action]")]
public class UpdateUserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UpdateUserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPut("{id}")]
    [ActionName("update-user")]
    public async Task<ActionResult<User>> UpdateUser(User request)
    {
        var dbUser = await _context.Users.FindAsync(request.Id);
        if (dbUser == null)
            return BadRequest("Hero not found.");

        dbUser.Email = request.Email;
        dbUser.Password = request.Password;
        dbUser.FirstName = request.FirstName;
        dbUser.LastName = request.LastName;

        await _context.SaveChangesAsync();

        return Ok(await _context.Users.ToListAsync());
    }
}
