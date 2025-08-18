using FoodOrderingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingAPI;

public class UserRepository : IUserRepository
{
    private readonly FoodOrderingAPIDBContext _context;
    public UserRepository(FoodOrderingAPIDBContext context)
    {
        _context = context;
    }
    User IUserRepository.Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    IEnumerable<User> IUserRepository.GetAll()
    {
        var userList = _context.Users.ToList();
        return userList;
    }

    User IUserRepository.GetById(int id)
    {
        var user = _context.Users.AsNoTracking().Include(u => u.UserRole).FirstOrDefault(x => x.Id == id);
        return user;
    }

    User IUserRepository.Delete(int id)
    {
        var userFound = _context.Users.FirstOrDefault(x => x.Id == id);
        var user = _context.Remove(userFound);
        _context.SaveChanges();
        return userFound;
    }

    User IUserRepository.Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return user;
    }

    LoginResponseViewModel IUserRepository.Login(LoginViewModel loginVM)
    {
        var user = _context.Users.Include(u => u.UserRole).FirstOrDefault(u => u.UserName == loginVM.Username && u.Password == loginVM.Password);

        if (user != null)
        {
            return new LoginResponseViewModel() { IsSuccess = true, User = user, Token = "" };
        }

        return new LoginResponseViewModel() { IsSuccess = false, User = null, Token = "" };
    }
}
