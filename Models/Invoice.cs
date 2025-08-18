using System.ComponentModel.DataAnnotations;

namespace FoodOrderingAPI.Models;

public class Invoice
{
    public int Id { get; set; }
    public DateTime OrderDateTime { get; set; }
    public double? TotalAmount { get; set; }
    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public int DeliveryAgentId { get; set; }
    public virtual DeliveryAgent? DeliveryAgent { get; set; }
}
