using ELAKIL.Business.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELAKIL.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMealService _mealService;
        private readonly ICategoryService _categoryService;

        public HomeController(IMealService mealService, ICategoryService categoryService)
        {
            _mealService = mealService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.AllCats = _categoryService.GetCategoriesAsync().Result;
            ViewBag.AllMels = _mealService.GetMealsAsync().Result;
            return View();
        }

        // TODO by Ahmed Zaghloul Add To Cart Action
        // Should add to user's cart and do nothing
        [HttpPost]
        public IActionResult AddItemToCart(int Id)
        {
            return View();
        }

        // TODO by Ahmed Yahia Checkout Action
        // Should finish all items added to user
        // Make the VIEW and COMPLETE Order
        public IActionResult CheckOut(int Id)
        {
            return View();
        }

        // TODO by Ahmed Nasr Elmasry Item Details Action
        // Should display item details
        // Make the VIEW
        [HttpPost]
        public IActionResult ItemDetail(int Id)
        {
            return View();
        }
    }
}
