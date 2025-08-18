using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _repository;
    public InvoiceService(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<Invoice> IInvoiceService.GetAll()
    {
        return _repository.GetAll();
    }
}
