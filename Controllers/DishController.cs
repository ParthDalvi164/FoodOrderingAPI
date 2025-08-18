using FoodOrderingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingAPI;
[Route("api/[controller]")]
[ApiController]
public class DishController : ControllerBase
{
    private readonly IDishService _dishService;
    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var dishList = _dishService.GetAll();
        return Ok(dishList);
    }

    [HttpPost]
    [Authorize(Roles = nameof(Role.ADMIN))]

    public IActionResult Post(Dish dish)
    {
        if (ModelState.IsValid)
        {
            var addedDish = _dishService.Add(dish);
            return CreatedAtAction("GetDish", new { id = addedDish.Id }, dish);
        }
        return BadRequest(dish);
    }

    [HttpGet("{id}")]
    public IActionResult GetDish(int id)
    {
        var dish = _dishService.GetById(id);
        if (dish == null)
        {
            return NotFound();
        }
        return Ok(dish);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(Role.ADMIN))]

    public IActionResult DeleteDish(int id)
    {
        var dishFound = _dishService.GetById(id);

        if (dishFound != null)
        {
            _dishService.Delete(id);
            return NoContent();
        }
        return NotFound(dishFound);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = nameof(Role.ADMIN))]

    public IActionResult UpdateDish(int id, Dish dish)
    {
        var dishFound = _dishService.GetById(id);

        if (dishFound != null)
        {
            dish.Id = dishFound.Id;
            _dishService.Update(dish);
            return Ok(dishFound);
        }

        return NotFound(dishFound);
    }
}
