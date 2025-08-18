using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingAPI;
[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var orderList = _invoiceService.GetAll();
        return Ok(orderList);
    }
}
