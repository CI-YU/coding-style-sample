using interview.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace interview.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUser _user;
    public UsersController(ILogger<UsersController> logger, IUser user)
    {
        _logger = logger;
        _user = user;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        await _user.GetUserById(id);
        return Ok(id);
    }
}
