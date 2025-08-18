using Microsoft.AspNetCore.Mvc;
using FoodOrderingAPI.Migrations;

namespace FoodOrderingAPI;

[Route("api/[controller]")]
[ApiController]
public class UserAuthenticationController : ControllerBase
{
    private readonly IUserService _userService;
    public UserAuthenticationController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public IActionResult Login(LoginViewModel loginVM)
    {
        if (ModelState.IsValid)
        {
            var loginResp = _userService.Login(loginVM);
            if (loginResp.IsSuccess == true)
            {
                return Ok(loginResp);
            }
            return Unauthorized();
        }
        return BadRequest(loginVM);
    }
}
