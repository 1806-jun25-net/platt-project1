using System;
using System.Collections.Generic;
using System.Text;

namespace MainLibrary
{



    public class Pizza
    {
        //public bool hasPepporoni { get; set; }
        //public bool hasOnions { get; set; }


        //public Pizza(string hasPepporoni, string hasOnions)
        //{
        //    if (hasPepporoni == "y")
        //        this.hasPepporoni = true;
        //    else
        //        this.hasPepporoni = false;
        //    if (hasOnions == "y")
        //        this.hasOnions = true;
        //    else
        //        this.hasOnions = false;
        //}

        public List<String> ListofToppings = new List<String>();
        decimal pizzaCost = 0;
        string pizzaSize = "medium";


        public void addToppings(List<String> toppingList)
        {

            foreach (String topping in toppingList)
                ListofToppings.Add(topping);


        }

        public decimal calculatePizzaPrice()
        {
            foreach (string topping in ListofToppings)
            {
                if (topping == "Pepporoni")
                {
                    pizzaCost += 0.50m;

                }
                else if (topping == "Sausage")
                {
                    pizzaCost += 0.50m;

                }

               
            }


            if (pizzaSize == "large")
            {
                pizzaCost += 8.00m;

            }

            else if (pizzaSize == "medium")
            {
                pizzaCost += 6.00m;
            }

            else if (pizzaSize == "small")
            {
                pizzaCost += 5.00m;
            }

            return pizzaCost;

        }


    }
}
