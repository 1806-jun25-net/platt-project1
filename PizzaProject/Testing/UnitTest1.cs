using System;
using Xunit;
using MainLibrary.Models;
using System.Collections.Generic;

namespace Testing
{
    public class UnitTest1
    {
        [Fact]
        public void pizzaCostshouldbeaccurate()
        {
            List<Boolean> ListofToppings = new List<Boolean>(new Boolean[] { true, true }); //passes if true, true 
            //which represents the presence of pineapple and pepperoni. gross. 

            int Size = 3;
            Pizza pizza = new Pizza();
            pizza.setPizza(Size, ListofToppings);

            Assert.True(pizza.GetPizzaCost() == 10m);

        }

    }
        

            

         
    
}
