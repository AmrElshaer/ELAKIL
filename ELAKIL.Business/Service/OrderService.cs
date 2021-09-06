using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Service
{
    public class OrderService:IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(DateTime? orderDate, DateTime? deliverDate, string status, int? code, string user)
        {
            return await _context.Orders.Include(a => a.UserProfile).Where(a=>
            (!orderDate.HasValue|| (a.OrderDate==orderDate.Value))&&
            (!deliverDate.HasValue || a.DeliverDate==deliverDate.Value )&&
             (status==null||a.Status==status)&&
             (!code.HasValue||a.Id==code.Value)&&
             (user==null||a.UserProfile.Name.ToLower().Contains(user.ToLower()))).ToListAsync();
        }
        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders.Include(a => a.OrderLines).ThenInclude(a => a.Meal)
                .Include(a => a.UserProfile).FirstOrDefaultAsync(a=>a.Id==id);
        }
    }
}
