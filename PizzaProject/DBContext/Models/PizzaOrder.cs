using System;
using System.Collections.Generic;

namespace DBContext.Models
{
    public partial class PizzaOrder
    {
        public int JunctionId { get; set; }
        public int? PizzaId { get; set; }
        public int? OrderId { get; set; }

        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
    }
}
