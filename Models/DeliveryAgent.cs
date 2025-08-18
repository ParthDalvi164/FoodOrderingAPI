using System.ComponentModel.DataAnnotations;

namespace FoodOrderingAPI.Models;

public class DeliveryAgent
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name of delivery agent required!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Phone of delivery agent required!")]
    [RegularExpression("^[0-9]{3}-[0-9]{3}$", ErrorMessage = "Phone number must be in the format")]
    public string Phone { get; set; }
    public virtual ICollection<Invoice>? Invoices { get; set; }
}
