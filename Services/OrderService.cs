using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IConfiguration _configuration;
    public OrderService(IOrderRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    Order IOrderService.Add(Order order)
    {
        var addedOrder = _repository.Add(order);
        return addedOrder;
    }

    IEnumerable<Order> IOrderService.GetAll()
    {
        return _repository.GetAll();
    }
    Order IOrderService.GetById(int id)
    {
        return _repository.GetById(id);
    }
    Order IOrderService.Delete(int id)
    {
        return _repository.Delete(id);
    }
    Order IOrderService.Update(Order order)
    {
        return _repository.Update(order);
    }
}
