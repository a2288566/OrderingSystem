using InStoreOrdering.IRepositorys;
using InStoreOrdering.IServices;
using InStoreOrdering.Models;

namespace InStoreOrdering.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;

        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public IEnumerable<MealModel> GetMeals()
        {
            try
            {
                return _mealRepository.GetMeals();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddMeals(List<MealModel> mealModel)
        {
            try
            {
                return _mealRepository.AddMeals(mealModel);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
