namespace FoodOrderingAPI.Models;
public enum PaymentMode { CASH, UPI }
public class Order
{
    public int Id { get; set; }
    public List<int> DishIds { get; set; } = new List<int>();
    public int? UserId { get; set; }
    public User? User { get; set; }
    public PaymentMode PaymentMode { get; set; }
    public virtual Invoice? Invoice { get; set; }
    public virtual ICollection<OrderTracking>? OrderTrackings { get; set; }
}
