using System;
using System.Collections.Generic;
using MainLibrary.Models;
using System.Xml.Serialization;
using System.Linq;
using PS = DBContext.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using MainLibrary.Repositories;

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
            var pizzaRepository = new PizzaStoreRepo(dbContext);

            Location Store1 = new Location { StoreNum = 1 };
            Location Store2 = new Location { StoreNum = 2 };
            Location Store3 = new Location { StoreNum = 3 };

            List<Order> allOrders = new List<Order>();

            allOrders = Serializer.DeserializeFromFile("orderlist.xml");

            List<User> Users = pizzaRepository.GetUsers().ToList();

            //Console.WriteLine("testing breakpoint");

            foreach (Order order in allOrders.Reverse<Order>())
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

            pizzaRepository.AddUser(User);
            pizzaRepository.SaveChanges();


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
                 Console.WriteLine("0. Display users from database");
                Console.WriteLine("1. Choose Location");
                Console.WriteLine("2. Place an Order");
                Console.WriteLine("3. Search users by name");
                Console.WriteLine("4. Review details of your order");
                Console.WriteLine("5. Recommended Order\n\n");

                Console.WriteLine("Management Features \n" +
                    "6. Order History by Location \n" +
                    "7. Order History by User \n" +
                    "8. Sort Order History\n" +
                    "9. Quit\n" +
                    "10. Add User to DB");

                while (true)
                {
                    optionSelect = Convert.ToInt32(Console.ReadLine());
                    if (optionSelect >= 0 && optionSelect < 11)
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
                if(optionSelect == 0)
                {

                    List<User> Usersrecent = pizzaRepository.GetUsers().ToList();
                    int i = 1;
                    foreach(User user in Usersrecent)
                    {
                        Console.WriteLine("User " + i + " " + user.FirstName + " " + user.LastName);


                            i++;
                    }


                }
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

                    for (int i = 1; i <= numberPizzasinOrder; i++)
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


                        Pizza pizza = new Pizza();
                        pizza.setPizza(Size, ToppingChooser());

                        PizzaList.Add(pizza);

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

                else if (optionSelect == 3)
                {
                    List<User> userlist = new List<User>();
                    foreach (Order order in allOrders)
                    {
                        userlist.Add(order.User);

                    }

                    foreach (User user in userlist.Distinct())
                    {
                        Console.WriteLine("first name is" + user.FirstName);
                        Console.WriteLine("Last name is " + user.LastName);

                    }


                }

                else if (optionSelect == 4)
                {
                    allOrders = Serializer.DeserializeFromFile("orderlist.xml");

                    foreach (Order order in allOrders.Reverse<Order>())  //.Reverse<Order>()
                    {
                        int i = 1;
                        foreach (Pizza pizza in order.PizzaList)
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
                else if (optionSelect == 5)
                {

                    foreach (Order order in allOrders.Reverse<Order>())
                    {
                        if (order.User.FirstName == User.FirstName)
                        {
                            List<Pizza> pizzalist = order.PizzaList;
                            int i = 1;
                            foreach (Pizza pizza in pizzalist)
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

                else if (optionSelect == 6)
                {
                    List<Order> locationhistorystore1 = new List<Order>();
                    List<Order> locationhistorystore2 = new List<Order>();
                    List<Order> locationhistorystore3 = new List<Order>();

                    foreach (Order order in allOrders)
                    {
                        if (order.Location.StoreNum == 1)
                        {
                            locationhistorystore1.Add(order);

                        }
                        else if (order.Location.StoreNum == 2)
                        {
                            locationhistorystore2.Add(order);
                        }
                        else if (order.Location.StoreNum == 3)
                        {
                            locationhistorystore3.Add(order);
                        }

    


                    }

                    Console.WriteLine("Which Store (1-3) would you like the order history for?");
                    int storechoice = Convert.ToInt32(Console.ReadLine());

                    if (storechoice == 1)
                    {
                        DisplayListofOrder(locationhistorystore1);

                    }
                    else if (storechoice == 2)
                    {
                        DisplayListofOrder(locationhistorystore2);

                    }
                    else if (storechoice == 3)
                    {
                        DisplayListofOrder(locationhistorystore3);
                    }

                }
                else if(optionSelect == 7)
                {
                    List<Order> userorderhistory = new List<Order>();

                    Console.WriteLine("Please enter a first name to search for : ");
                    string name = Console.ReadLine();

                    foreach(Order order in allOrders)

                    {
                        if (order.User.FirstName == name)
                            userorderhistory.Add(order);
                        else
                            continue;

                    }

                    if (userorderhistory.Count() > 0)
                    {
                        DisplayListofOrder(userorderhistory);

                    }
                    else
                        Console.WriteLine("Could not find any orders for this user");



                }

                else if (optionSelect == 8)
                {
                    Console.WriteLine("What do you want to sort by?" +
                        "1. Earliest Order on Top \n" +
                        "2. Most Recent Order on Top \n" +
                        "3. Cheapest Order on Top\n" +
                        "4. Most Expensive Order on Top\n");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if(choice == 1)
                    {
                        EarliestOrdersOnTop(allOrders);

                    }
                    else if(choice ==2)
                    {
                       LatestOrdersOnTop(allOrders);
                       

                    }

                    else if(choice ==3)
                    {
                        CostlyOrdersOnTop(allOrders);

                    }
                    else if (choice ==4)
                    {
                        CheapOrdersOnTop(allOrders);

                    }

                }

                else if(optionSelect == 10)

                {

                    Console.WriteLine("Please sign in:" +
               "First Name:");

                    string firstName1 = Console.ReadLine();

                    Console.WriteLine("Last Name:");

                    string lastName1 = Console.ReadLine();


                    Console.WriteLine("Please choose a store 1 to 3");

                    int defstorenum1 = Convert.ToInt32(Console.ReadLine());

                    User User1 = new User { FirstName = firstName1, LastName = lastName1, DefaultStoreNum = defstorenum1 };

                    pizzaRepository.AddUser(User);
                    pizzaRepository.SaveChanges();


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

        public static void DisplayListofOrder(List<Order> orderlist)

        {
            int j = 0;
            int numorders = orderlist.Count();
            Console.WriteLine("\nTotal number of orders is " + numorders);
            foreach (Order order in orderlist.Reverse<Order>())  //gets by most recent

            {
                j++;
                int i = 1;

                
                Console.WriteLine("\nCurrent Order number is " + j);
                Console.WriteLine("Order Cost: " + order.totalValue);
                Console.WriteLine("Time of order is " + order.TimeOfOrder);
                Console.WriteLine("First Name: " + order.User.FirstName);
                Console.WriteLine("Last Name: " + order.User.LastName);

                foreach (Pizza pizza in order.PizzaList)
                {
                    Console.WriteLine("\nPizza number: " + i);
                    Console.WriteLine("Size is :" + pizza.pizzaSize);
                    Console.WriteLine("Has Pep?" + pizza.ListofToppings[0]);
                    Console.WriteLine("Has Pin?" + pizza.ListofToppings[1]);
                    i++;


                }
            }


        }
        //display order history sorted by earliest, latest, cheapest, most expensive
        public static void EarliestOrdersOnTop(List<Order> orderliste)
        {
            orderliste.Sort((x, y) => y.TimeOfOrder.CompareTo(x.TimeOfOrder));


            DisplayListofOrder(orderliste);


        }

        public static void LatestOrdersOnTop(List<Order> orderliste)
        {
            orderliste.Sort((x, y) => x.TimeOfOrder.CompareTo(y.TimeOfOrder));


            DisplayListofOrder(orderliste);


        }

        public static void CostlyOrdersOnTop(List<Order> orderliste)
        {
            orderliste.Sort((x, y) => y.totalValue.CompareTo(x.totalValue));


            DisplayListofOrder(orderliste);


        }
        public static void CheapOrdersOnTop(List<Order> orderliste)
        {
            orderliste.Sort((x, y) => x.totalValue.CompareTo(y.totalValue));


            DisplayListofOrder(orderliste);


        }












    }
}

