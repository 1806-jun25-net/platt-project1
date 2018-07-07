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

            Location Store1 = new Location { StoreNum = 1 };
            Location Store2 = new Location { StoreNum = 2 };
            Location Store3 = new Location { StoreNum = 3 };

            List<Order> allOrders = new List<Order>();

            //allOrders = Serializer.DeserializeFromFile("orders");


            Console.WriteLine("Please sign in:" +
                "First Name:");

            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name:");

            string lastName = Console.ReadLine();


            Console.WriteLine("Please choose a store 1 to 3");

            int defstorenum = Convert.ToInt32(Console.ReadLine());

            User User = new User { FirstName = firstName, LastName = lastName, DefaultStoreNum = defstorenum };


            int optionSelect = 0;


            //User User1 = new User();
            //Console.WriteLine("Please Login \n" +
            //    "First Name: ");
            //User1.FirstName = Console.ReadLine();
            //Console.WriteLine("Thanks. Now your last name please? " +
            //    "Last Name: ");
            //User1.LastName = Console.ReadLine();
        
            do
            {

                Console.WriteLine("Welcome to Phil's Pizza. What would you like to do?");
               // Console.WriteLine("0. Sign In");
                Console.WriteLine("1. Choose Location");
                Console.WriteLine("2. Place an Order");
                Console.WriteLine("3. Review Current Cart");
                Console.WriteLine("4. Review Your Order History");
                Console.WriteLine("5. Recommended Order\n\n");

                Console.WriteLine("Management Features \n" +
                    "6. Order History by Location \n" +
                    "7. Save data to disk \n" +
                    "8. Load Data from disk \n" +
                    "9. Quit");

                optionSelect = Convert.ToInt32(Console.ReadLine());



                //now begin flow to each selection

                //if (optionSelect == 0)
                //{
                    
                //    Console.WriteLine("Please enter your first name: ");
                //    User1.FirstName = Console.ReadLine();
                //    Console.WriteLine("Please enter your last name: ");
                //    User1.LastName = Console.ReadLine();


                //}
                if (optionSelect == 1)
                {

                    while (true)
                    {
                        Console.WriteLine("Choose a location: \n" +
                            "1. Store 1\n" +
                            "2. Store 2\n" +
                            "3. Store 3");

                        User.DefaultStoreNum = Convert.ToInt32(Console.ReadLine());

                        if (User.DefaultStoreNum == 1 || User.DefaultStoreNum == 2 || User.DefaultStoreNum == 3)
                            break;
                        else
                            continue;
                    }
                }

                else if (optionSelect == 2)
                {

                    Console.WriteLine("How many pizzas do you want? (1-12)");

                    int numberPizzasinOrder = Convert.ToInt32(Console.ReadLine());

                    List<Pizza> PizzaList = new List<Pizza>();

                    for(int i = 1; i <= numberPizzasinOrder; i++)
                    {
                        int Size;

                        Console.WriteLine("Current Pizza Number is: i");

                        while (true)
                        {
                            Console.WriteLine("Please choose a size: 1 for Small, 2 for Medium, 3 for Large");
                            Size = Convert.ToInt32(Console.ReadLine());
                            if (Size == 1 || Size == 2 || Size == 3)
                                break;
                            else
                                continue;
                        }


                        Pizza Pizza = new Pizza(Size, ToppingChooser());

                        PizzaList.Add(Pizza);
                       
                    }


                    if (User.DefaultStoreNum == 1)
                    {
                        Order Order = new Order();
                        Order.makeOrder(PizzaList, User, Store1);
                        

                        
                        Store1.RemoveFromInventory(Order);
                        User.RecentOrderLocation = 1;
                        //User.UserOrderHistory.Add(Order);
                       // Store1.LocOrderHistory.Add(Order);
                        allOrders.Add(Order);

                        Serializer.SerializeToFile("orderlist.xml", allOrders);


                    }
                    else if (User.DefaultStoreNum == 2)
                    {
                        Order Order = new Order();
                        Order.makeOrder(PizzaList, User, Store2);
                        Store2.RemoveFromInventory(Order);
                        User.RecentOrderLocation = 2;
                       // User.UserOrderHistory.Add(Order);
                      //  Store2.LocOrderHistory.Add(Order);
                    }
                    else if (User.DefaultStoreNum == 3)
                    {
                        Order Order = new Order();
                        Order.makeOrder(PizzaList, User, Store3);
                        Store3.RemoveFromInventory(Order);
                        User.RecentOrderLocation = 3;
                       // User.UserOrderHistory.Add(Order);
                        //Store3.LocOrderHistory.Add(Order);
                    }

                    Console.WriteLine("testing breakpint");
                }

                else if (optionSelect == 4)
                {


                }



            } while (optionSelect != 9);


         


        }



        public static List<Boolean> ToppingChooser()
        {
            List<Boolean> toppingList = new List<Boolean>();

            string hasPep = "none";
            string hasPin = "none";
           

            

              

                while (true)
                {
                    Console.WriteLine("Add Pepperoni? (y or n)");

                   
                    hasPep = Console.ReadLine();

                if (hasPep == "y" || hasPep == "n")
                    break;
                else
                    Console.WriteLine("Please enter y or n");

                   
                }


            while (true)
            {
                Console.WriteLine("Add Pineapple? (y or n)");


                hasPin = Console.ReadLine();

                if (hasPin == "y" || hasPin == "n")
                    break;
                else
                    Console.WriteLine("Please enter y or n");


            }

            if (hasPep == "y")
                toppingList.Add(true);
            else
                toppingList.Add(false);

            if (hasPin == "y")
                toppingList.Add(true);
            else
                toppingList.Add(false);


            return toppingList;


        }

           

          


        
    }
}

