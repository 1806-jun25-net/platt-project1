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
//        this.hasOnions = false
//}

using System;
using System.Collections.Generic;
using System.Text;

namespace MainLibrary.Models
{



    public class Pizza
    {

        //dough and sauce is on by default
        //has pep, has pinapple
        public List<Boolean> ListofToppings { get; set; } //default toppings = new List<Boolean>(new Boolean[] {false,false }); 


        //1 for small, 2 for medium, 3 for large
        public int pizzaSize { get; set; }

        decimal pizzaCost = 0;


        public Pizza()
        {

        }

       public void setPizza(int size, List<Boolean> toppingList)
        {
            pizzaSize = size;
            ListofToppings = toppingList;

            if (size == 1)
                pizzaCost += 5.00m;
            else if (size == 2)
                pizzaCost += 7.00m;
            else if (size == 3)
                pizzaCost += 9.00m;

            foreach (Boolean topping in toppingList)
            {

                if (topping)
                {
                    pizzaCost += 0.50m;
                }//each topping cost an extra 50 cents
            }
                


        }

        public decimal GetPizzaCost()
        {
            return this.pizzaCost;

        }


       


    }
}
