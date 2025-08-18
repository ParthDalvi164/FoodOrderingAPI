using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public interface IInvoiceService
{
    IEnumerable<Invoice> GetAll();
}
