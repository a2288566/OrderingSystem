using InStoreOrdering.Models;

namespace InStoreOrdering.IServices
{
    public interface IMealService
    {
        IEnumerable<MealModel> GetMeals();
        bool AddMeals(List<MealModel> mealList);
    }
}
