using System.ComponentModel.DataAnnotations;

namespace FoodOrderingAPI;
public enum Role { ADMIN, MEMBER }
public class UserRole
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Role is required!")]
    public Role Role { get; set; }
    public virtual IEnumerable<User>? Users { get; set; }
}
