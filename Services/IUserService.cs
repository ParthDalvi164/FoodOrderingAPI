namespace FoodOrderingAPI;

public interface IUserService
{
    User Add(User user);
    IEnumerable<User> GetAll();
    User GetById(int id);
    User Delete(int id);
    User Update(User user);
    LoginResponseViewModel Login(LoginViewModel loginVM);
}
