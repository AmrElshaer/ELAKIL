using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int? MealId { get; set; }
        public Meal Meal { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public double Quantity { get; set; }
    }
}
