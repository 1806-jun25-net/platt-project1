using MainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Mapper
    {

        public static User Map(WebApp.Models.UserWeb userweb) => new User
        {
            FirstName = userweb.FirstName,
            LastName = userweb.LastName,
            defStore = userweb.defStore,
            UserID = userweb.UserID
          
        };

        public static Location Map(WebApp.Models.LocationWeb locweb) => new Location
        {
            StoreName = locweb.StoreName,
            StoredPizza = locweb.StoredPizza,
            LocID = locweb.LocID

        };

        public static Order Map(WebApp.Models.OrderWeb orderweb) => new Order
        {
            TimeOfOrder = DateTime.Now,
            Pizza1 = orderweb.Pizza1,
            Pizza2 = orderweb.Pizza2,
            Pizza3 = orderweb.Pizza3,
            Pizza4 = orderweb.Pizza4,
            Pizza5 = orderweb.Pizza5,
            Pizza6 = orderweb.Pizza6,
            Pizza7 = orderweb.Pizza7,
            Pizza8 = orderweb.Pizza8,
            Pizza9 = orderweb.Pizza9,
            Pizza10 = orderweb.Pizza10,
            Pizza11 = orderweb.Pizza11,
            Pizza12 = orderweb.Pizza12,
           OrderPrice = orderweb.OrderPrice,
           User = Map(orderweb.User),
           Location = Map(orderweb.Location)

             
           


            


        };

    }
}
