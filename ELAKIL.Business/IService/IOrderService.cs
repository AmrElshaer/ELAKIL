﻿using ELAKIL.Business.Common;
using ELAKIL.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IOrderService
    {
        Task AddOrderAsync(Order order);
        Task DeleteAsync(int id);
        Task<Order> GetOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync(DateTime? orderDate, DateTime? deliverDate, string status, int? code, string user);
        Task UpdateOrderStatusAsync(int id, OrderStatus orderStatus);
    }
}
