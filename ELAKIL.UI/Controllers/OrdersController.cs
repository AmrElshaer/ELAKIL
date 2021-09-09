using ELAKIL.Business.Common;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using ELAKIL.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELAKIL.UI.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserProfileService _userProfileService;

        public OrdersController(IOrderService orderService, IUserProfileService userProfileService)
        {
            _orderService = orderService;
            _userProfileService = userProfileService;
        }

        public async Task<IActionResult> Index(DateTime? orderDate, DateTime? deliverDate, OrderStatus? status, int? code, string user)
        {
            var orders = await _orderService.GetOrdersAsync(orderDate, deliverDate, status?.ToString(), code, user);
            var orderSearch = new OrderSearchModel(orderDate, deliverDate, status, code, user, orders);
            return View(orderSearch);
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _orderService.GetOrderAsync(id));
        }

        public async Task<IActionResult> Delete(int id)
        {

            return View(await _orderService.GetOrderAsync(id));
        }

        public async Task<IActionResult> Print(int id)
        {
            return new ViewAsPdf(await _orderService.GetOrderAsync(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _orderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _orderService.GetOrderAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, OrderStatus status, DateTime? deliverDate)
        {
            await _orderService.UpdateOrderStatusAsync(id, status, deliverDate);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            int userId = await _userProfileService.GetUserProfileIdAsync(User.Identity.Name);
            return View(await _orderService.GetOrdersAsync(userId));
        }
    }
}
