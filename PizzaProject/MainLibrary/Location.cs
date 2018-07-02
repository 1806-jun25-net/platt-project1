using System;
using System.Collections.Generic;
using System.Text;

namespace MainLibrary
{
    public class Location
    {
        //fields 

        int ingredientCount;
        public string address { get; set; } = "Store 1";
  

        //constructor below. requires address or store name. 
        public Location(string address)
        {
            ingredientCount = 3;
            this.address = address;
        }

        public Location()
        {

        }

     

    }
}
