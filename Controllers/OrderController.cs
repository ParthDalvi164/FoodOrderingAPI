using System.Security.Claims;
using FoodOrderingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingAPI;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var orderList = _orderService.GetAll();
        return Ok(orderList);
    }

    [HttpPost] 
    public IActionResult Post(Order order)
    {
        if (ModelState.IsValid)
        {
            order.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var addedOrder = _orderService.Add(order);
            return CreatedAtAction("GetOrder", new { id = addedOrder.Id }, order);
        }
        return BadRequest(order);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        var order = _orderService.GetById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var orderFound = _orderService.GetById(id);

        if (orderFound != null)
        {
            _orderService.Delete(id);
            return NoContent();
        }
        return NotFound(orderFound);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, Order order)
    {
        var orderFound = _orderService.GetById(id);

        if (orderFound != null)
        {
            order.Id = orderFound.Id;
            _orderService.Update(order);
            return Ok(orderFound);
        }

        return NotFound(orderFound);
    }
}
