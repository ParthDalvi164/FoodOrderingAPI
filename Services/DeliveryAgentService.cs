using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public class DeliveryAgentService : IDeliveryAgentService
{
    private readonly IDeliveryAgentRepository _repository;
    private readonly IConfiguration _configuration;
    public DeliveryAgentService(IDeliveryAgentRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    DeliveryAgent IDeliveryAgentService.Add(DeliveryAgent deliveryAgent)
    {
        var addedDeliveryAgent = _repository.Add(deliveryAgent);
        return addedDeliveryAgent;
    }

    IEnumerable<DeliveryAgent> IDeliveryAgentService.GetAll()
    {
        return _repository.GetAll();
    }
    DeliveryAgent IDeliveryAgentService.GetById(int id)
    {
        return _repository.GetById(id);
    }
    DeliveryAgent IDeliveryAgentService.Delete(int id)
    {
        return _repository.Delete(id);
    }
    DeliveryAgent IDeliveryAgentService.Update(DeliveryAgent deliveryAgent)
    {
        return _repository.Update(deliveryAgent);
    }
}
