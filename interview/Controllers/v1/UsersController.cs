using Microsoft.AspNetCore.Mvc;

namespace interview.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(id);
    }
}
