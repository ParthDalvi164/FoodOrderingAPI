using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public interface IInvoiceRepository
{
    IEnumerable<Invoice> GetAll();
}
