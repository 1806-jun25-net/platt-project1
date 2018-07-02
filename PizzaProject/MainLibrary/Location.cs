using System;
using System.Collections.Generic;
using System.Text;

namespace MainLibrary
{
    public class Location
    {
        //fields 


        //the string will be the toppings ex "sausage" and the int will be the amount of that topping left. 
        // assuming 1 per order. 

        Dictionary<string, int> Inventory = new Dictionary<string, int>
        {
            {"Pepporoni", 5 },
            {"Sausage", 5 },
            {"Dough", 10},

            

        };
       
            
        

      
      

        public string address { get; set; } = "Store 1";
  

        //constructor below. requires address or store name. 
        public Location(string address)
        {
            //ingredientCount = 3;
            this.address = address;
           
        }

        public Location()
        {

        }

        public void removeInventory(string thingtoRemove)
        {
           

        }

     

    }
}
