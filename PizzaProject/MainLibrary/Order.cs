using System;
using System.Collections.Generic;
using System.Text;

namespace MainLibrary
{
    public class Order
    {

        Location location;
        User user;
        DateTime orderTime;
        public List<Pizza> PizzaList; 
        int pizzaCount; //max 12
        decimal totalValue; //max 500 dollars


        public Order(int numPizzas)
        {
            int pizzaCount = numPizzas;
            PizzaList = new List<Pizza>();



            for (int i = 1; i <= numPizzas; i++)

            {
                Console.WriteLine("Pizza" + i);
                Console.WriteLine("Do you want pepperoni? y/n");

                string hasPep = Console.ReadLine();

                Console.WriteLine("Great. Now do you want onions? y/n");

                string hasOnions = Console.ReadLine();

                Pizza Pizza = new Pizza();


                PizzaList.Add(Pizza);

            }
        }

       

        
    }
}
