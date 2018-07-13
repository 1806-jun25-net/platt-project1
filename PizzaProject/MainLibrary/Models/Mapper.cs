using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace MainLibrary.Models
{
    //user from DB to class
    public static class Mapper
    {


        public static User Map(DBContext.Models.UserDb userdb) => new User
        {
            FirstName = userdb.FirstName,
            LastName = userdb.LastName,
            UserID = userdb.UserId
        };

        //user from class to DB
        public static DBContext.Models.UserDb Map(User user) => new DBContext.Models.UserDb
        {
            FirstName = user.FirstName,
            LastName = user.LastName,


        };


        //order from class to DB
        public static DBContext.Models.OrderDb Map(Order order) => new DBContext.Models.OrderDb
        {

            UserId = order.User.UserID,
            LocId = order.Location.LocID,
            Opizza1 = order.Pizza1,
            Opizza2 = order.Pizza2,
            Opizza3 = order.Pizza3,
            Opizza4 = order.Pizza4,
            Opizza5 = order.Pizza5,
            Opizza6 = order.Pizza6,
            Opizza7 = order.Pizza7,
            Opizza8 = order.Pizza8,
            Opizza9 = order.Pizza9,
            Opizza10 = order.Pizza10,
            Opizza11 = order.Pizza11,
            Opizza12 = order.Pizza12,
            TimeofOrder = order.TimeOfOrder,
            OrderTotalPrice = order.OrderPrice
           

        };


        //Order from DB to order class
        public static Order Map(DBContext.Models.OrderDb orderdb) => new Order
        {

            OrderID = orderdb.OrderId,
            User = Map(orderdb.User),
            Location = Map(orderdb.Loc),
            Pizza1 = orderdb.Opizza1,
            Pizza2 = orderdb.Opizza2,
            Pizza3 = orderdb.Opizza3,
            Pizza4 = orderdb.Opizza4,
            Pizza5 = orderdb.Opizza5,
            Pizza6 = orderdb.Opizza6,
            Pizza7 = orderdb.Opizza7,
            Pizza8 = orderdb.Opizza8,
            Pizza9 = orderdb.Opizza9,
            Pizza10 = orderdb.Opizza10,
            Pizza11 = orderdb.Opizza11,
            Pizza12 = orderdb.Opizza12,
            OrderPrice = orderdb.OrderTotalPrice,
            TimeOfOrder = orderdb.TimeofOrder





        };

        public static Location Map(DBContext.Models.LocationDb locdb) => new Location
        {
            StoredPizza = locdb.StoredPizza,
            LocID = locdb.LocationId,
            StoreName = locdb.Address



        };

        public static DBContext.Models.LocationDb Map(Location location) => new DBContext.Models.LocationDb
        {
            Address = location.StoreName,
            StoredPizza = location.StoredPizza


        };

    }

}



