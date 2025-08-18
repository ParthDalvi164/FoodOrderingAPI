using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public interface IDeliveryAgentService
{
    DeliveryAgent Add(DeliveryAgent deliveryAgent);
    IEnumerable<DeliveryAgent> GetAll();
    DeliveryAgent GetById(int id);
    DeliveryAgent Delete(int id);
    DeliveryAgent Update(DeliveryAgent deliveryAgent);
}
