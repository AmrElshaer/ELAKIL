using ELAKIL.Business.Contexts;
using ELAKIL.Business.IService;
using ELAKIL.Business.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;

namespace ELAKIL.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserCartItemService _userCartItemService;
        private readonly IUserProfileService _userProfileService;
        private readonly IOrderService _orderService;

        public HomeController(IUserCartItemService userCartItemService, IUserProfileService userProfileService
            , IOrderService orderService)
        {
            _userCartItemService = userCartItemService;
            _userProfileService = userProfileService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // TODO by Ahmed Mansour Add To Cart Action
        // Should add to user's cart and do nothing
        public IActionResult AddItemToCart(int Id)
        {
            var userId = _userProfileService.GetUserProfileId(User.Identity.Name);
            _userCartItemService.AddUserCartItemAsync(new UserCartItem
            {
                MealID = Id,
                UserID = userId
            });
            return View(viewName: "Index");
        }

        public IActionResult DeleteItemFromCart(int Id, int UId)
        {
            _userCartItemService.DeleteUserCartItemAsync(Id);
            Thread.Sleep(500);
            return RedirectToAction("CheckOut", new { Id = UId });
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

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _orderService.AddOrderAsync(order);
            Thread.Sleep(500);
            var countAllMeals = _userCartItemService.GetUserCartItemsAsync().Result
                .Where(x => x.UserID == order.UserProfileId).ToList();
            for (int i = 0; i < countAllMeals.Count; i++)
            {
                _userCartItemService.DeleteUserCartItemAsync(countAllMeals[i].ID);
                Thread.Sleep(500);
            }
            return RedirectToAction("Index");
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
