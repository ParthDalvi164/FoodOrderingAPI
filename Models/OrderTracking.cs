namespace FoodOrderingAPI.Models;

public class OrderTracking
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public virtual Dish? Dish { get; set; }
    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public int? QuantityOrdered { get; set; }
}
