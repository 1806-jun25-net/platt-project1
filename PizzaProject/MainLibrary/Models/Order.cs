﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MainLibrary.Models
{

    public class Order
    {
        [XmlElement]

        public Location Location { get; set; }
        public User User { get; set; }

        public int OrderID { get; set; }
        public decimal OrderPrice { get; set; }

        public DateTime TimeOfOrder { get; set; } = new DateTime();



        public string Pizza1 { get; set; }
        public string Pizza2 { get; set; }
        public string Pizza3 { get; set; }
        public string Pizza4 { get; set; }
        public string Pizza5 { get; set; }
        public string Pizza6 { get; set; }
        public string Pizza7 { get; set; }
        public string Pizza8 { get; set; }
        public string Pizza9 { get; set; }
        public string Pizza10 { get; set; }
        public string Pizza11 { get; set; }
        public string Pizza12 { get; set; }


        public void CalcOrderPrice()
        {
            decimal runningTotal = 0m;

            List<String> pizzaList = new List<String>();

            pizzaList.Add(Pizza1);
            pizzaList.Add(Pizza2);
            pizzaList.Add(Pizza3);
            pizzaList.Add(Pizza4);
            pizzaList.Add(Pizza5);
            pizzaList.Add(Pizza6);
            pizzaList.Add(Pizza7);
            pizzaList.Add(Pizza8);
            pizzaList.Add(Pizza9);
            pizzaList.Add(Pizza10);
            pizzaList.Add(Pizza11);
            pizzaList.Add(Pizza12);


            foreach(string pizza in pizzaList)
            {

                if (pizza == null)
                    runningTotal += 0m;
                else if (pizza == "Small")
                    runningTotal += 5.00m;
                else if (pizza == "Medium")
                    runningTotal += 7.00m;
                else if (pizza == "Large")
                    runningTotal += 9.00m;
                else if (pizza == "Gold") 
                    runningTotal += 100.00m;
            }

            OrderPrice = runningTotal;

        }

       

        


    }
}