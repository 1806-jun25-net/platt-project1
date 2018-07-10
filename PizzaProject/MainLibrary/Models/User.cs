using System;
using System.Collections.Generic;

namespace MainLibrary.Models
{
    public class User
    {
        public string FirstName { get; set; } = "Bob";
        public string LastName { get; set; } = "Ross";
        public int DefaultStoreNum { get; set; } = 1;
        public int RecentOrderLocation { get; set; } = 1;
        //public List<Order> UserOrderHistory = new List<Order>(); circular dependency?


      
       public DateTime TimeOfOrder { get; set; } = new DateTime();



    /*    public User (string first, string last, int defstorenum)

        {
            FirstName = first;
            LastName = last;
            DefaultStoreNum = defstorenum;


        }*/
     
        
    }
}
