using FoodOrderingAPI.Data;
using FoodOrderingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingAPI;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly FoodOrderingAPIDBContext _context;
    public InvoiceRepository(FoodOrderingAPIDBContext context)
    {
        _context = context;
    }

    IEnumerable<Invoice> IInvoiceRepository.GetAll()
    {
        var invoiceList = _context.Invoices.Include(i => i.DeliveryAgent).Include(i => i.Order.User).Include(i => i.Order.OrderTrackings).ThenInclude(ot => ot.Dish).ToList();
        return invoiceList;
    }
}
