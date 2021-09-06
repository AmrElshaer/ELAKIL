using ELAKIL.Business.Common;
using ELAKIL.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI.Models
{
    public class OrderSearchModel
    {
        public OrderSearchModel(DateTime? orderDate, DateTime? deliverDate, OrderStatus? status, int? code, string user, IEnumerable<Order> orders)
        {
            OrderDate = orderDate;
            DeliverDate = deliverDate;
            Status = status;
            Code = code;
            User = user;
            Orders = orders;
        }

        public DateTime? OrderDate { get; set; }
       public DateTime? DeliverDate { get; set; }
       public OrderStatus? Status { get; set; }
       public int? Code { get; set; }
       public string User { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
