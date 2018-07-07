using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MainLibrary
{
    
    public class Order
    {
        [XmlElement]
        public Location Location { get; set; }
        public User User;
       
        public List<Pizza> PizzaList; 
        public int pizzaCount; //max 12
        public decimal totalValue; //max 500 dollars
        public DateTime TimeOfOrder { get; set; } = new DateTime();

       
        public Order()
        {
            Pizza Pizza1 = new Pizza();
            Pizza Pizza2 = new Pizza();
            Pizza Pizza3 = new Pizza();

            PizzaList = new List<Pizza> { Pizza1, Pizza2, Pizza3};

        }

        public Order(int numPizzasinOrder)
        {
            this.pizzaCount = numPizzasinOrder;

        }

        //public void BuildOrderHelper()
        //{


        //}

        public void makeOrder(List<Pizza> pizzasInOrder, User username, Location storenumber)
        {
            User = username;
            PizzaList = pizzasInOrder;
            TimeOfOrder = DateTime.Now;
            Location = storenumber;
            pizzaCount = pizzasInOrder.Count;
            totalValue = 33;


        }

        public decimal calculateOrderPrice()
        {
            decimal runningTotal = 0m;

            foreach (Pizza pizza in PizzaList)
                runningTotal += pizza.GetPizzaCost();


            return runningTotal;
        }


        
       

        
    }
}
