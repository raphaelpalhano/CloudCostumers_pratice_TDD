using CloudCostumer.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCostumer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
   

    public UsersController(IUsersService usersService)
    {
       

    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        
        return Ok("Tudo certo");
    }
}

