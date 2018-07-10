using System;
using System.Collections.Generic;

namespace DBContext.Models
{
    public partial class Location
    {
        public Location()
        {
            Order = new HashSet<Order>();
        }

        public int LocationId { get; set; }
        public int? StoredDough { get; set; }
        public int? StoredCheese { get; set; }
        public int? StoredPep { get; set; }
        public int? StoredPin { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
