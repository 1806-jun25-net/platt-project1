using System;
using System.Collections.Generic;

namespace DBContext.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int PizzaId { get; set; }
        public int? Size { get; set; }
        public bool? HasPep { get; set; }
        public bool? HasPin { get; set; }

        public ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
