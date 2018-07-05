using System;
using System.Collections.Generic;

namespace MainLibrary
{
    public class User
    {
        public string firstName { get; set; } = "Bob";
        public string lastName { get; set; } = "Ross";
        Location defaultLocation = new Location();
        public string RecentOrderLocation { get; set; } = "Main Store";
        public List<Order> UserOrderHistory = new List<Order>();


      
       public DateTime timeOfOrder { get; set; } = new DateTime();



        public void placeOrder(Location location, List<Pizza> pizzas)

        {


        }
        
    }
}
