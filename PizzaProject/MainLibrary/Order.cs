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
        public DateTime TimeOfOrder { get; set; } = new DateTime();

       
        public Order()
        {
            Pizza Pizza1 = new Pizza();
            Pizza Pizza2 = new Pizza();
            Pizza Pizza3 = new Pizza();

            PizzaList = new List<Pizza> { Pizza1, Pizza2, Pizza3};

        }

        public Order(List<Pizza> pizzasInOrder)
        {

            PizzaList = pizzasInOrder;
            TimeOfOrder = DateTime.Now;


        }

        public decimal calculateOrderPrice()
        {
            decimal runningTotal = 0m;

            foreach (Pizza pizza in PizzaList)
                runningTotal += pizza.calculatePizzaPrice();


            return runningTotal;
        }


        
       

        
    }
}
