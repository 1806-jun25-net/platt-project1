using System;
using System.Collections.Generic;
using MainLibrary;
using System.Xml.Serialization;

namespace PizzaUI
{
    class Program
    {
        static void Main(string[] args)
        {

            User test = new User();
            Console.WriteLine(test.RecentOrderLocation);
            Console.WriteLine(test.timeOfOrder);

            test.timeOfOrder = DateTime.Now;

            Console.WriteLine(test.timeOfOrder);
            //int optionSelect = 0;
         
            //do
            //{
            
            //    Console.WriteLine("Welcome to Phil's Pizza. What would you like to do?");
            //    Console.WriteLine("0. Sign In");
            //    Console.WriteLine("1. Choose Location");
            //    Console.WriteLine("2. Place an Order");
            //    Console.WriteLine("3. Review Current Cart");
            //    Console.WriteLine("4. Review Your Order History");
            //    Console.WriteLine("5. Recommended Order\n\n");

            //    Console.WriteLine("Management Features \n" +
            //        "6. Order History by Location \n" +
            //        "7. Save data to disk \n" +
            //        "8. Load Data from disk \n" +
            //        "9. Quit");

            //    optionSelect = Convert.ToInt32(Console.ReadLine());



            //    //now begin flow to each selection

            //    if (optionSelect == 0)
            //    {
            //        User User1 = new User();
            //        Console.WriteLine("Please enter your first name: ");
            //        User1.firstName = Console.ReadLine(); 
            //        Console.WriteLine("Please enter your last name: ");
            //        User1.lastName = Console.ReadLine();


            //    }
            //    else if (optionSelect == 1)
            //    {
            //        Console.WriteLine("Choose a location: \n" +
            //            "Store 1\n" +
            //            "Store 2");
            //        Location Location1 = new Location(Console.ReadLine());
            //    }

            //    else if (optionSelect == 2)
            //    {

            //        Console.WriteLine("How many pizzas do you want?");
            //        Order Order1 = new Order(Convert.ToInt32(Console.ReadLine()));
            //        //Console.WriteLine("How many pizzas do you want?");

            //        //int numPizzas = Convert.ToInt32(Console.ReadLine());

            //        //Order Order1 = new Order(numPizzas);



            //        //for (int i = 1; i <= numPizzas; i++)

            //        //{
            //        //    Console.WriteLine("Pizza" + i);
            //        //    Console.WriteLine("Do you want pepperoni? y/n");

            //        //    string hasPep = Console.ReadLine();

            //        //    Console.WriteLine("Great. Now do you want onions? y/n");

            //        //    string hasOnions = Console.ReadLine();

            //        //    Pizza Pizza = new Pizza(hasPep, hasOnions);


            //        //    Order1.PizzaList.Add(Pizza);


            //        //}

            //        //serialize the data. 







            //    }



            //} while (optionSelect != 9);

       


        }
    }
}
