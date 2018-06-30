using System;
using System.Collections.Generic;
using System.Text;

namespace MainLibrary
{
    class Order
    {
        string location;
        string user;
        DateTime orderTime;
        int pizzaCount; //max 12
        int totalValue; //max 500 dollars
    }
}
