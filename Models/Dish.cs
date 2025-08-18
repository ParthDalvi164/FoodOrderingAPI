using System.ComponentModel.DataAnnotations;

namespace FoodOrderingAPI.Models;

public class Dish
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name of dish required!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description of dish required!")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Price of dish required!")]
    public double Price { get; set; }
    [Required(ErrorMessage = "Category of dish required!")]
    public bool IsVeg { get; set; }
    public virtual ICollection<OrderTracking>? OrderTrackings { get; set; }
}
