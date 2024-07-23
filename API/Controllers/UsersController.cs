using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[Controller]
[Route("api/[controller]")]    //api/Users
public class UsersController (DataContext context):ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var Users= await context.Users.ToListAsync();
        return Users;
    }

    [HttpGet("{id}")]   //api/Users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user=await context.Users.FindAsync(id);
        if(user==null) return NotFound();

        return user;
    }
}
