using System;
using MainLibrary;

namespace PizzaUI
{
    class Program
    {
        static void Main(string[] args)
        {

            int optionSelect = 0;
         
            do
            {
            
                Console.WriteLine("Welcome to Phil's Pizza. What would you like to do?");
                Console.WriteLine("0. Sign In");
                Console.WriteLine("1. Choose Location");
                Console.WriteLine("2. Place an Order");
                Console.WriteLine("3. Review Current Cart");
                Console.WriteLine("4. Review Your Order History");
                Console.WriteLine("5. Recommended Order\n\n");

                Console.WriteLine("Management Features \n" +
                    "6. Order History by Location \n" +
                    "7. Save data to disk \n" +
                    "8. Load Data from disk");
                Location Store1 = new Location("Store1");
                Console.WriteLine(Store1.address);
                optionSelect = Convert.ToInt32(Console.ReadLine());



            } while (optionSelect != 4);

         
        

        }
    }
}
