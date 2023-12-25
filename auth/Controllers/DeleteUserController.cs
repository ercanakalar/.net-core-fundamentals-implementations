using auth_deneme.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auth_deneme;

[ApiController]
[Route("api/auth/[action]")]
public class DeleteUserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public DeleteUserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpDelete("{id}")]
    [ActionName("delete-user")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
        var userToDelete = await _context.Users.FindAsync(id);
        if (userToDelete == null)
            return BadRequest("Hero not found.");

        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();

        return Ok(await _context.Users.ToListAsync());
    }
}
