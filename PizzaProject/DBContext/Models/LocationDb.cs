using System;
using System.Collections.Generic;

namespace DBContext.Models
{
    public partial class LocationDb
    {
        public LocationDb()
        {
            OrderDb = new HashSet<OrderDb>();
        }

        public int LocationId { get; set; }
        public string Address { get; set; }
        public int StoredPizza { get; set; }

        public ICollection<OrderDb> OrderDb { get; set; }
    }
}
