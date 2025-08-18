using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingAPI;
[Authorize(Roles = nameof(Role.ADMIN))]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var userList = _userService.GetAll();
        return Ok(userList);
    }

    [HttpPost]
    public IActionResult Post(User user)
    {
        if (ModelState.IsValid)
        {
            var addedUser = _userService.Add(user);
            return CreatedAtAction("GetUser", new { id = addedUser.Id }, user);
        }
        return BadRequest(user);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var userFound = _userService.GetById(id);

        if (userFound != null)
        {
            _userService.Delete(id);
            return NoContent();
        }
        return NotFound(userFound);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        var userFound = _userService.GetById(id);

        if (userFound != null)
        {
            user.Id = userFound.Id;
            _userService.Update(user);
            return Ok(userFound);
        }

        return NotFound(userFound);
    }
}
