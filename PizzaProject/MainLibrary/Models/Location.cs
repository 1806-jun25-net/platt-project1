using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace MainLibrary.Models
{

    public class Location
    {
     

        public int StoredPizza { get; set; } = 10;
        public int LocID { get; set; }
        public string StoreName { get; set; }



        public void RemoveFromInventory(Order order)
        {

            int count = 0;
            if (order.Pizza1 != null)
                count++;
            if (order.Pizza2 != null)
                count++;
            if (order.Pizza3 != null)
                count++;
            if (order.Pizza4 != null)
                count++;
            if (order.Pizza5 != null)
                count++;
            if (order.Pizza6 != null)
                count++;
            if (order.Pizza7 != null)
                count++;
            if (order.Pizza8 != null)
                count++;
            if (order.Pizza9 != null)
                count++;
            if (order.Pizza10 != null)
                count++;
            if (order.Pizza11 != null)
                count++;
            if (order.Pizza12 != null)
                count++;

            StoredPizza = StoredPizza - count;


        }

        public void AddToInventory(int howMany)
        {

            StoredPizza = StoredPizza + howMany;
        }

        public void ResetInventory()
        {

            StoredPizza = 10;
    
            
         }
        


    }
}
