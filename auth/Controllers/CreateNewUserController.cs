using auth_deneme.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auth_deneme;

[ApiController]
[Route("api/auth/[action]")]
public class CreateNewUserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CreateNewUserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ActionName("signup")]
    public async Task<ActionResult<User>> CreateUser(User newUser)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);

        if (existingUser != null)
        {
            return BadRequest("User already exists.");
        }

        var isMatchPasswords = newUser.Password == newUser.ConfirmPassword;

        if (!isMatchPasswords)
        {
            throw new NotImplementedException();
        }


        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        var response = new
        {
            message = "You have successfully registered.",
            user = new
            {
                id = newUser.Id,
                firstName = newUser.FirstName,
                lastName = newUser.LastName,
                email = newUser.Email,
            },
        };

        return Ok(response);
    }

    private Exception BadRequestObjectResult(string v)
    {
        throw new NotImplementedException();
    }

}
