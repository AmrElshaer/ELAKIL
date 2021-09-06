using ELAKIL.Business.Common;
using ELAKIL.Business.IService;
using ELAKIL.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELAKIL.UI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(DateTime? orderDate,DateTime? deliverDate,OrderStatus? status,int? code,string user)
        {
            var orders = await _orderService.GetOrdersAsync(orderDate, deliverDate, status?.ToString(), code, user);
            var orderSearch = new OrderSearchModel(orderDate,deliverDate,status,code,user,orders);
            return View(orderSearch);
        }
        public async Task<IActionResult> Details(int id)
        {
           return View(await _orderService.GetOrderAsync(id));
        }
    }
}
