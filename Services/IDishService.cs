using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public interface IDishService
{
    Dish Add(Dish dish);
    IEnumerable<Dish> GetAll();
    Dish GetById(int id);
    Dish Delete(int id);
    Dish Update(Dish dish);
}
