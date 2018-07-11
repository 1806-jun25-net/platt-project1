using System;
using System.Collections.Generic;

namespace DBContext.Models
{
    public partial class Order
    {
        public Order()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int OrderId { get; set; }
        public int? OrderUser { get; set; }
        public int? NumPizzas { get; set; }
        public decimal? Price { get; set; }
        public int? OrderLoc { get; set; }
        public DateTime? OrderTime { get; set; }

        public Location OrderLocNavigation { get; set; }
        public User OrderUserNavigation { get; set; }
        public ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
