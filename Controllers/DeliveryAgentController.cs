using FoodOrderingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingAPI;
[Authorize(Roles = nameof(Role.ADMIN))]
[Route("api/[controller]")]
[ApiController]
public class DeliveryAgentController : ControllerBase
{
    private readonly IDeliveryAgentService _deliveryAgentService;
    public DeliveryAgentController(IDeliveryAgentService deliveryAgentService)
    {
        _deliveryAgentService = deliveryAgentService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var deliveryAgentList = _deliveryAgentService.GetAll();
        return Ok(deliveryAgentList);
    }

    [HttpPost]
    public IActionResult Post(DeliveryAgent deliveryAgent)
    {
        if (ModelState.IsValid)
        {
            var addedDeliveryAgent = _deliveryAgentService.Add(deliveryAgent);
            return CreatedAtAction("GetDeliveryAgent", new { id = addedDeliveryAgent.Id }, deliveryAgent);
        }
        return BadRequest(deliveryAgent);
    }

    [HttpGet("{id}")]
    public IActionResult GetDeliveryAgent(int id)
    {
        var deliveryAgent = _deliveryAgentService.GetById(id);
        if (deliveryAgent == null)
        {
            return NotFound();
        }
        return Ok(deliveryAgent);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDeliveryAgent(int id)
    {
        var deliveryAgentFound = _deliveryAgentService.GetById(id);

        if (deliveryAgentFound != null)
        {
            _deliveryAgentService.Delete(id);
            return NoContent();
        }
        return NotFound(deliveryAgentFound);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDeliveryAgent(int id, DeliveryAgent deliveryAgent)
    {
        var deliveryAgentFound = _deliveryAgentService.GetById(id);

        if (deliveryAgentFound != null)
        {
            deliveryAgent.Id = deliveryAgentFound.Id;
            _deliveryAgentService.Update(deliveryAgent);
            return Ok(deliveryAgentFound);
        }

        return NotFound(deliveryAgentFound);
    }
}
