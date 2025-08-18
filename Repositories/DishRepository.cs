using FoodOrderingAPI.Data;
using FoodOrderingAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace FoodOrderingAPI;

public class DishRepository : IDishRepository
{
    private readonly FoodOrderingAPIDBContext _context;
    public DishRepository(FoodOrderingAPIDBContext context)
    {
        _context = context;
    }
    Dish IDishRepository.Add(Dish dish)
    {
        _context.Dishes.Add(dish);
        _context.SaveChanges();
        return dish;
    }

    IEnumerable<Dish> IDishRepository.GetAll()
    {
        var dishList = _context.Dishes.ToList();
        return dishList;
    }

    Dish IDishRepository.GetById(int id)
    {
        var dish = _context.Dishes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return dish;
    }

    Dish IDishRepository.Delete(int id)
    {
        var dishFound = _context.Dishes.FirstOrDefault(x => x.Id == id);
        var dish = _context.Remove(dishFound);
        _context.SaveChanges();
        return dishFound;
    }

    Dish IDishRepository.Update(Dish dish)
    {
        _context.Dishes.Update(dish);
        _context.SaveChanges();
        return dish;
    }
}
