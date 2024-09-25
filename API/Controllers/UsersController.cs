using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // api/users
// below concept is called 'Primary constructor'
public class UsersController(DataContext context) : ControllerBase
{

[HttpGet]
public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
{
    var users = await context.Users.ToListAsync();
    if(users == null) return NotFound();
    return users;
}

[HttpGet("{Id:int}")] // api/users/3
public async Task<ActionResult<AppUser>> GetUser(int Id)
{ 
    var user = await context.Users.FindAsync(Id);
    if(user == null) return NotFound();
    return user;
}

}