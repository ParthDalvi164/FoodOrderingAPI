using System.ComponentModel.DataAnnotations;

namespace FoodOrderingAPI;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Full name required")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Username required")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [RegularExpression("^[0-9]{3}-[0-9]{3}$", ErrorMessage = "Phone number must be in the format")]

    public string Phone { get; set; }

    [Required(ErrorMessage = "User email is required")]
    [EmailAddress(ErrorMessage = "Email not in proper format")]
    public string Email { get; set; }
    public int? UserRoleId { get; set; }
    public virtual UserRole? UserRole { get; set; }
}
