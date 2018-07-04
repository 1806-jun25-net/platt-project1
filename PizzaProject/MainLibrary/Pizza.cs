//old way

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

using System;
using System.Collections.Generic;
using System.Text;

namespace MainLibrary
{



    public class Pizza
    {


        public List<String> ListofToppings = new List<String>(new string[] { "Sauce", "Dough", "Cheese" });


        string pizzaSize = "medium";

        decimal pizzaCost = 0;

       
        public void addToppings(List<String> toppingList)
        {

            foreach (String topping in toppingList)
                ListofToppings.Add(topping);


        }

        public void setPizzaSize (String size)
        {
            pizzaSize = size;

        }

        public decimal calculatePizzaPrice()
        {


            // instead of all the if elses here. could use a data structure (2d array or dictionary) to
            //associate a topping or size for example with its price. Then run through a for each and just add
            // the price section to the running total. 
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
                else if (topping == "Pineapple")
                {
                    pizzaCost += 0.50m;
                }
                else if (topping == "Veggies")
                {
                    pizzaCost += 0.50m;
                }

               
            }


            if (pizzaSize == "large")
            {
                pizzaCost += 10.00m;

            }

            else if (pizzaSize == "medium")
            {
                pizzaCost += 8.00m;
            }

            else if (pizzaSize == "small")
            {
                pizzaCost += 5.00m;
            }

            return pizzaCost;

        }


    }
}
