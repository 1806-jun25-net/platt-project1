using System;
using System.Collections.Generic;

namespace DBContext.Models
{
    public partial class UserDb
    {
        public UserDb()
        {
            OrderDb = new HashSet<OrderDb>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DefaultStore { get; set; }

        public ICollection<OrderDb> OrderDb { get; set; }
    }
}
