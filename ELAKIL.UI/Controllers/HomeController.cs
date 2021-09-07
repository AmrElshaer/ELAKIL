using ELAKIL.Business.Contexts;
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
        private readonly IUserCartItemService _userCartItemService;
        public HomeController(IUserCartItemService userCartItemService)
        {
            _userCartItemService = userCartItemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // TODO by Ahmed Mansour Add To Cart Action
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
            var AllMeals = _userCartItemService.GetUserCartItemsAsync()
                .Result.Where(x => x.UserID == Id).ToList();
            return View(AllMeals);
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
