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
using Microsoft.AspNetCore.Authorization;
using ELAKIL.Business.Common;

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
        [Authorize]
        // TODO by Ahmed Mansour Add To Cart Action
        // Should add to user's cart and do nothing
        public async Task<IActionResult> AddItemToCart(int Id)
        {
            var userId = _userProfileService.GetUserProfileId(User.Identity.Name);
            await  _userCartItemService.AddUserCartItemAsync(new UserCartItem
            {
                MealID = Id,
                UserID = userId
            });
            return View(viewName: "Index");
        }
        [Authorize]
        public async Task<IActionResult> DeleteItemFromCart(int Id, int UId)
        {
            await _userCartItemService.DeleteUserCartItemAsync(Id);
            return RedirectToAction("CheckOut", new { Id = UId });
        }
        [Authorize]
        // TODO by Ahmed Yahia Checkout Action
        // Should finish all items added to user
        // Make the VIEW and COMPLETE Order
        public async Task< IActionResult> CheckOut(int id)
        {
            var allMeals = await _userCartItemService.GetUserCartItemsAsync(id);
            return View(allMeals);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(Order order)
        {
            order.Status = OrderStatus.Active.ToString();
            var allMeals =await _userCartItemService.GetUserCartItemsAsync(order.UserProfileId);
            order.OrderLines = allMeals.Select(a=>new OrderLine() { MealId=a.MealID,Quantity=1}).ToList();
             await _orderService.AddOrderAsync(order);
            allMeals.ToList().ForEach(a=> _userCartItemService.DeleteUserCartItemAsync(a.ID).GetAwaiter().GetResult());
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
