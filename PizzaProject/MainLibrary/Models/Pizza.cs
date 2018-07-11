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
        public List<Boolean> ListofToppings; //default toppings = new List<Boolean>(new Boolean[] {false,false }); 


        //1 for small, 2 for medium, 3 for large
        public int pizzaSize;

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

                if(topping == true)
                pizzaCost += 0.50m;  //each topping cost an extra 50 cents
            }
                


        }

        public decimal GetPizzaCost()
        {
            return this.pizzaCost;

        }


        //public void AddToppings(List<String> toppingList)
        //{

        //    foreach (Boolean topping in toppingList)
        //        ListofToppings.Add(topping);


        //}

        //public void SetPizzaSize (int size)
        //{
        //    pizzaSize = size;

        //}

        //public decimal CalculatePizzaPrice()
        //{


        //    // instead of all the if elses here. could use a data structure (2d array or dictionary) to
        //    //associate a topping or size for example with its price. Then run through a for each and just add
        //    // the price section to the running total. 
        //    foreach (string topping in ListofToppings)
        //    {
        //        if (topping == "Pepporoni")
        //        {
        //            pizzaCost += 0.50m;

        //        }
        //        //else if (topping == "Sausage")
        //        //{
        //        //    pizzaCost += 0.50m;

        //        //}
        //        //else if (topping == "Pineapple")
        //        //{
        //        //    pizzaCost += 0.50m;
        //        //}
        //        //else if (topping == "Veggies")
        //        //{
        //        //    pizzaCost += 0.50m;
        //        //}

               
        //    }


        //    if (pizzaSize == "large")
        //    {
        //        pizzaCost += 10.00m;

        //    }

        //    else if (pizzaSize == "medium")
        //    {
        //        pizzaCost += 8.00m;
        //    }

        //    else if (pizzaSize == "small")
        //    {
        //        pizzaCost += 5.00m;
        //    }

        //    return pizzaCost;

        //}


    }
}
