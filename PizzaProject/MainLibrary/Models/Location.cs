using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace MainLibrary.Models
{

    public class Location
    {
        //fields

        //public List<Order> LocOrderHistory = new List<Order>();
        //the string will be the toppings ex "sausage" and the int will be the amount of that topping left. 
        // assuming 1 per order. 


        //inventory below
        public int deductionModifier = 1;
        public int StoredDough = 10;
        public int StoredCheese = 10;
        public int StoredPep = 10;
        public int StoredPineapple = 10;

        // dictionarys cant serialize with xml serialzer so trying something else. 
        //public Dictionary<string, int> Inventory = new Dictionary<string, int>
        // {
        //     //consider the numbers as units. ex 5 units of pep in inventory. 1 unit per order. 
        //     {"Pepporoni", 10 },
        //     {"Sausage", 10 },
        //     {"Cheese", 10 },
        //     {"Veggies", 10 },
        //     {"Sauce", 10 },
        //     {"Pineapple" , 5 },  //not that many people order pineapple so we stock less
        //     {"Dough", 10},



        // };








        public int StoreNum { get; set; } = 1; // 1 2 or 3 for three stores. 

        
        public void setInventory(Order order)
        {
            StoredDough = order.Location.StoredDough;
            StoredCheese = order.Location.StoredCheese;
            StoredPep = order.Location.StoredPep;
            StoredPineapple = order.Location.StoredPineapple;

         }

    /**    public Location(int StoreNum)
        {
            this.StoreNum = StoreNum;

        }*/


        //constructor below. requires address or store name. 



        public bool RemoveFromInventory(Order order)
        {

            foreach (Pizza pizza in order.PizzaList)

            {
                if (pizza.pizzaSize == 1)
                {
                    deductionModifier = 1;

                }
                else if (pizza.pizzaSize == 2)
                {
                    deductionModifier = 2;

                }
                else if (pizza.pizzaSize == 3)
                {
                    deductionModifier = 3;

                }


                StoredDough = StoredDough - (1 * deductionModifier); //when you dont realize you multiplied by 1 uneccessarily
                if (ValidateInventory() == false)
                {
                    StoredDough = StoredDough + deductionModifier; //undoes the above if order takes too much. 
                    return false;
                }

                StoredCheese = StoredCheese - (1 * deductionModifier);
                if (ValidateInventory() == false)
                {
                    StoredCheese = StoredCheese + deductionModifier; //undoes the above if order takes too much. 
                    return false;
                }

                if (pizza.ListofToppings[0])
                {
                    StoredPep = StoredPep - (1 * deductionModifier);
                    if (ValidateInventory() == false)
                    {
                        StoredPep = StoredPep + deductionModifier; //undoes the above if order takes too much. 
                        return false;
                    }

                }
                if (pizza.ListofToppings[1])
                {
                    StoredPineapple = StoredPineapple - (1 * deductionModifier);
                    if (ValidateInventory() == false)
                    {
                        StoredPineapple = StoredPineapple + deductionModifier; //undoes the above if order takes too much. 
                        return false;
                    }
                }



            }

            return true; // if it makes it here, the order should have the available ingredients

            //foreach (Pizza pizza in order.PizzaList)
            // {
            //     foreach (string ingredient in pizza.ListofToppings)
            //     {
            //         if (Inventory.ContainsKey(ingredient))
            //         {
            //             Inventory[ingredient] = Inventory[ingredient] - 1;

            //         }
            //         else
            //         {
            //             Console.WriteLine("Invalid Ingredient");
            //         }

            //     }

            // }

        }

        public void AddToInventory(string thingToAdd, int howMany)
        {


        }

        public void ResetInventory()
        {

             StoredDough = 10;
             StoredCheese = 10;
             StoredPep = 10;
            StoredPineapple = 10;
        //    Dictionary<string, int> Inventory = new Dictionary<string, int>
        //{
        //    //consider the numbers as units. ex 5 units of pep in inventory. 1 unit per order. 
        //    //{"Pepporoni", 10 },
        //    //{"Sausage", 10 },
        //    //{"Cheese", 10 },
        //    //{"Veggies", 10 },
        //    //{"Sauce", 10 },
        //    //{"Pineapple" , 5 },  //not that many people order pineapple so we stock less
        //    //{"Dough", 10},




        //};

            
    }
        public bool ValidateInventory()
        {


            if (StoredDough < 0)
                return false;
            else if (StoredCheese < 0)
                return false;
            else if (StoredPep < 0)
                return false;
            else if (StoredPineapple < 0)
                return false;
            else
                return true;


        }


    }
}
