using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MainLibrary
{
    [DataContract]
   public class Location
    {
        //fields

        public List<Order> LocOrderHistory = new List<Order>();
        //the string will be the toppings ex "sausage" and the int will be the amount of that topping left. 
        // assuming 1 per order. 

       public Dictionary<string, int> Inventory = new Dictionary<string, int>
        {
            //consider the numbers as units. ex 5 units of pep in inventory. 1 unit per order. 
            {"Pepporoni", 10 },
            {"Sausage", 10 },
            {"Cheese", 10 },
            {"Veggies", 10 },
            {"Sauce", 10 },
            {"Pineapple" , 5 },  //not that many people order pineapple so we stock less
            {"Dough", 10},

            

        };
       
            
        

      
      

        public string address { get; set; } = "Main Store";
  

        //constructor below. requires address or store name. 
       
    

        public void removeFromInventory(Order order)
        {


           foreach (Pizza pizza in order.PizzaList)
            {
                foreach (string ingredient in pizza.ListofToppings)
                {
                    if (Inventory.ContainsKey(ingredient))
                    {
                        Inventory[ingredient] = Inventory[ingredient] - 1;

                    }
                    else
                    {
                        Console.WriteLine("Invalid Ingredient");
                    }

                }

            }

        }

        public void addToInventory(string thingToAdd, int howMany)
        {


        }

        public void resetInventory()
        {
            Dictionary<string, int> Inventory = new Dictionary<string, int>
        {
            //consider the numbers as units. ex 5 units of pep in inventory. 1 unit per order. 
            {"Pepporoni", 10 },
            {"Sausage", 10 },
            {"Cheese", 10 },
            {"Veggies", 10 },
            {"Sauce", 10 },
            {"Pineapple" , 5 },  //not that many people order pineapple so we stock less
            {"Dough", 10},



        };
        }

     

    }
}
