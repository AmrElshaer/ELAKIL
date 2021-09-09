using System;
using System.Collections.Generic;

namespace ELAKIL.Business.Entities
{
    public class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public string Remarks { get; set; }
        public string Governorate { get; set; }
        public string Station { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string AnotherPhone { get; set; }
        public string Status { get; set; }
    }
}