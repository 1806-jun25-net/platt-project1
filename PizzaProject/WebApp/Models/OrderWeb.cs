using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderWeb
    {

        public LocationWeb Location { get; set; }
        public UserWeb User;

        public int OrderID;
        public decimal OrderPrice;

        public DateTime TimeOfOrder { get; set; } = new DateTime();


        [Required(AllowEmptyStrings = false)]
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


        public List<SelectListItem> PizzaEnumerable = new List<SelectListItem>
       {
            new SelectListItem {Value = null, Text = "No Pizza" },
           new SelectListItem {Value = "Small", Text = "Small"},
           new SelectListItem {Value = "Medium", Text = "Medium"},
            new SelectListItem {Value = "Large", Text = "Large"},
            new SelectListItem {Value = "Gold", Text = "Gold"},

       };


        public int amountDough()
        {

            int count = 0;

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


            foreach(String pizza in pizzaList)
            {
                if (pizza == null)
                    count += 0;
                else if (pizza == "Small")
                    count += 1;
                else if (pizza == "Medium")
                    count += 2;
                else if (pizza == "Large")
                    count += 3;


                

            }
            return count;

        }

        public decimal CalcOrderPrice()
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


            foreach (string pizza in pizzaList)
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

            return OrderPrice;

        }
    }
}
