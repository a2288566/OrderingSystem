using InStoreOrdering.Models;
using InStoreOrdering.Services;
using InStoreOrdering.IRepositorys;
using InStoreOrdering.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InStoreOrdering.IServices;
using System.Collections.Generic;

namespace InStoreOrdering.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMealService _mealService;

        public HomeController(IMealService mealService)
        {
            _mealService = mealService;
        }

        public IActionResult Index()
        {
            List<MealModel> mealsList = _mealService.GetMeals().ToList();            

            return View(mealsList);
        }

        [HttpPost]
        public IActionResult AddMeals(List<MealModel> mealsList)
        {
            //°²¸ê®Æ
            for (int i = 1; i < 6; i++)
            {
                MealModel a = new MealModel
                {
                    ProductName = $"t{i}",
                    Price = i
                };
                mealsList.Add(a);
            }

            bool add = _mealService.AddMeals(mealsList);
            return View();
        }

        [HttpPost]
        public IActionResult AddToShoppingCart(int mealId)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
