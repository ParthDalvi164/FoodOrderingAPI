using FoodOrderingAPI.Data;
using FoodOrderingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingAPI;

public class DeliveryAgentRepository : IDeliveryAgentRepository
{
    private readonly FoodOrderingAPIDBContext _context;
    public DeliveryAgentRepository(FoodOrderingAPIDBContext context)
    {
        _context = context;
    }
    DeliveryAgent IDeliveryAgentRepository.Add(DeliveryAgent deliveryAgent)
    {
        _context.DeliveryAgents.Add(deliveryAgent);
        _context.SaveChanges();
        return deliveryAgent;
    }

    IEnumerable<DeliveryAgent> IDeliveryAgentRepository.GetAll()
    {
        var deliveryAgentList = _context.DeliveryAgents.ToList();
        return deliveryAgentList;
    }

    DeliveryAgent IDeliveryAgentRepository.GetById(int id)
    {
        var deliveryAgent = _context.DeliveryAgents.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return deliveryAgent;
    }

    DeliveryAgent IDeliveryAgentRepository.Delete(int id)
    {
        var deliveryAgentFound = _context.DeliveryAgents.FirstOrDefault(x => x.Id == id);
        var deliveryAgent = _context.Remove(deliveryAgentFound);
        _context.SaveChanges();
        return deliveryAgentFound;
    }

    DeliveryAgent IDeliveryAgentRepository.Update(DeliveryAgent deliveryAgent)
    {
        _context.DeliveryAgents.Update(deliveryAgent);
        _context.SaveChanges();
        return deliveryAgent;
    }
}
