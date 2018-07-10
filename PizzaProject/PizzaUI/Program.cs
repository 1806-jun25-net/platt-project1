using System;
using System.Collections.Generic;
using MainLibrary.Models;
using System.Xml.Serialization;
using System.Linq;
using PS = DBContext.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace PizzaUI
{
    class Program
    {
        static void Main(string[] args)
        {


            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PS.PizzaStoreContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStore"));
            var options = optionsBuilder.Options;

            var dbContext = new PS.PizzaStoreContext(options);

            Location Store1 = new Location { StoreNum = 1 };
            Location Store2 = new Location { StoreNum = 2 };
            Location Store3 = new Location { StoreNum = 3 };

            List<Order> allOrders = new List<Order>();

           allOrders = Serializer.DeserializeFromFile("orderlist.xml");

            foreach(Order order in allOrders.Reverse<Order>())
            {
                if (order.Location.StoreNum == 1)
                {
                    Store1 = order.Location;
                    break;
                }

            }

            foreach (Order order in allOrders.Reverse<Order>())
            {
                if (order.Location.StoreNum == 2)
                {
                    Store2 = order.Location;
                    break;
                }

            }


            foreach (Order order in allOrders.Reverse<Order>())
            {
                if (order.Location.StoreNum == 3)
                {
                    Store3 = order.Location;
                    break;
                }

            }

            //foreach (Order order in allOrders)
            //{
            //    //User UserTestUser = allOrders[i].User;
            //    //User NextUser = allOrders.Distinct<>

            //}

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

                while (true)
                {
                    optionSelect = Convert.ToInt32(Console.ReadLine());
                    if (optionSelect >= 1 && optionSelect < 10)
                        break;
                    else
                        continue;
                }



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

                    int numberPizzasinOrder = 0;

                    while (true)
                    {
                        Console.WriteLine("How many pizzas do you want? (1-12)");
                        numberPizzasinOrder = Convert.ToInt32(Console.ReadLine());

                        if (numberPizzasinOrder > 0 && numberPizzasinOrder <= 12)
                            break;
                        else
                            continue;
                    }

                    List<Pizza> PizzaList = new List<Pizza>();

                    for(int i = 1; i <= numberPizzasinOrder; i++)
                    {
                        int Size;

                        Console.WriteLine("Current Pizza Number is: " + i);

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
                        

                        
                       bool success = Store1.RemoveFromInventory(Order);

                        if (success)
                        {
                            User.RecentOrderLocation = 1;
                            //User.UserOrderHistory.Add(Order);
                            // Store1.LocOrderHistory.Add(Order);
                            allOrders.Add(Order);

                            Serializer.SerializeToFile("orderlist.xml", allOrders);
                        }
                        else
                            Console.WriteLine("Not enough inventory left");


                    }
                    else if (User.DefaultStoreNum == 2)
                    {
                        Order Order = new Order();
                        Order.makeOrder(PizzaList, User, Store2);
                        bool success = Store2.RemoveFromInventory(Order);

                        if (success)
                        {
                            User.RecentOrderLocation = 2;

                            allOrders.Add(Order);

                            Serializer.SerializeToFile("orderlist.xml", allOrders);
                        }
                        else
                            Console.WriteLine("Not enough inventory left");
                        // User.UserOrderHistory.Add(Order);
                        //  Store2.LocOrderHistory.Add(Order);
                    }
                    else if (User.DefaultStoreNum == 3)
                    {
                        Order Order = new Order();
                        Order.makeOrder(PizzaList, User, Store3);
                        bool success = Store3.RemoveFromInventory(Order);

                        if (success)
                        {
                            User.RecentOrderLocation = 3;

                            allOrders.Add(Order);

                            Serializer.SerializeToFile("orderlist.xml", allOrders);
                        }
                        else
                            Console.WriteLine("Not enough inventory left");
                        // User.UserOrderHistory.Add(Order);
                        //Store3.LocOrderHistory.Add(Order);
                    }

                   // Console.WriteLine("testing breakpint");
                }

                else if (optionSelect == 4)
                {


                }
                else if (optionSelect == 5)
                {

                    foreach (Order order in allOrders.Reverse<Order>())
                    {
                        if (order.User.FirstName == User.FirstName)
                        {
                            List<Pizza> pizzalist = order.PizzaList;
                            int i = 1;
                            foreach(Pizza pizza in pizzalist)
                            {
                                Console.WriteLine("Pizza number: " + i);
                                Console.WriteLine("Size is :" + pizza.pizzaSize);
                                Console.WriteLine("Has Pep?" + pizza.ListofToppings[0]);
                                Console.WriteLine("Has Pin?" + pizza.ListofToppings[1]);
                                i++;


                            }

                            break;

                        }
                           
                        

                    }
                    //Order suggOrder = suggestedOrder(allOrders, User);
                    //Console.WriteLine("Your suggested order is ");
                    //foreach (Pizza pizza in suggOrder.PizzaList)
                    //{
                    //    Console.WriteLine(")

                    //}

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


        public static Order suggestedOrder(List<Order> allOrders, User user)

        {
            Order defaultOrder = new Order();

            foreach (Order order in allOrders.Reverse<Order>())
            {


                if (order.User == user)
                {
                    return order;
                }

                

            }

            return defaultOrder;
        }


      

           

          


        
    }
}

