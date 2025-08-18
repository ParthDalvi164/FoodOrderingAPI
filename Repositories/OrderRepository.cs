using FoodOrderingAPI.Data;
using FoodOrderingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingAPI;

public class OrderRepository : IOrderRepository
{
    private readonly FoodOrderingAPIDBContext _context;
    public OrderRepository(FoodOrderingAPIDBContext context)
    {
        _context = context;
    }
    Order IOrderRepository.Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();

        Invoice invoice = new Invoice();
        DateTime now = DateTime.Now;
        invoice.OrderDateTime = now;
        invoice.OrderId = order.Id;
        var deliveryAgentIdList = _context.DeliveryAgents.Select(da => da.Id).ToList();
        Random rnd = new Random();
        int randomIndex = rnd.Next(deliveryAgentIdList.Count);
        invoice.DeliveryAgentId = deliveryAgentIdList[randomIndex];
        _context.Invoices.Add(invoice);
        _context.SaveChanges();

        foreach (var dishid in order.DishIds)
        {
            OrderTracking orderTracking = new OrderTracking();
            orderTracking.DishId = dishid;
            orderTracking.OrderId = order.Id;
            _context.OrderTrackings.Add(orderTracking);
            _context.SaveChanges();
        }
        invoice.TotalAmount = _context.OrderTrackings.Where(ot => ot.OrderId == order.Id).Sum(ot => ot.Dish.Price);
        _context.SaveChanges();
        
        return order;
    }

    IEnumerable<Order> IOrderRepository.GetAll()
    {
        var orderList = _context.Orders.Include(o => o.Invoice).Include(o => o.OrderTrackings).ToList();
        return orderList;
    }

    Order IOrderRepository.GetById(int id)
    {
        var order = _context.Orders.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return order;
    }

    Order IOrderRepository.Delete(int id)
    {
        var orderFound = _context.Orders.FirstOrDefault(x => x.Id == id);
        var order = _context.Remove(orderFound);
        _context.SaveChanges();
        return orderFound;
    }

    Order IOrderRepository.Update(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
        return order;
    }
}
