using InStoreOrdering.Models;

namespace InStoreOrdering.IRepositorys
{
    public interface IMealRepository
    {
        IEnumerable<MealModel> GetMeals();
        bool AddMeals(List<MealModel> mealModel);
    }
}
