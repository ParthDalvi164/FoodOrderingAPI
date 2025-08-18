using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public interface IOrderService
{
    Order Add(Order order);
    IEnumerable<Order> GetAll();
    Order GetById(int id);
    Order Delete(int id);
    Order Update(Order order);
}
