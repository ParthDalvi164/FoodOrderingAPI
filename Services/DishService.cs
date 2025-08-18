using FoodOrderingAPI.Models;

namespace FoodOrderingAPI;

public class DishService : IDishService
{
    private readonly IDishRepository _repository;
    private readonly IConfiguration _configuration;
    public DishService(IDishRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    Dish IDishService.Add(Dish dish)
    {
        var addedDish = _repository.Add(dish);
        return addedDish;
    }

    IEnumerable<Dish> IDishService.GetAll()
    {
        return _repository.GetAll();
    }
    Dish IDishService.GetById(int id)
    {
        return _repository.GetById(id);
    }
    Dish IDishService.Delete(int id)
    {
        return _repository.Delete(id);
    }
    Dish IDishService.Update(Dish dish)
    {
        return _repository.Update(dish);
    }
}
