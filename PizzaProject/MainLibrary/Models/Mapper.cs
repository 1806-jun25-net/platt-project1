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
            public static User Map(DBContext.Models.User user) => new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
                
            };

        //user from class to DB
        public static DBContext.Models.User Map(User user) => new DBContext.Models.User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefStore = user.DefaultStoreNum

        };


        //order from class to DB
        public static DBContext.Models.Order Map(Order order) => new DBContext.Models.Order
        {
            OrderUser = order.User.UserID,
            NumPizzas = order.pizzaCount,
            Price = order.totalValue,
            OrderLoc = order.Location.StoreNum,
            OrderTime = order.TimeOfOrder
            
        };


        //Order from DB to order class
        public static Order Map(DBContext.Models.Order order) => new Order
        {
            OrderID = order.OrderId,
            pizzaCount = order.NumPizzas ?? default(int) ,
            totalValue = order.Price ?? default(int),
            TimeOfOrder = order.OrderTime ?? default(DateTime)
            

        };



        /*       public static Context.Models.Restaurant Map(Restaurant restaurant) => new Context.Models.Restaurant
               {
                   Id = restaurant.Id,
                   Name = restaurant.Name,
                   Review = Map(restaurant.Reviews).ToList()
               };

               public static Review Map(Context.Models.Review review) => new Review
               {
                   Id = review.Id,
                   ReviewerName = review.ReviewerName,
                   Score = review.Score,
                   Text = review.Text
               };

               public static Context.Models.Review Map(Review review) => new Context.Models.Review
               {
                   Id = review.Id,
                   ReviewerName = review.ReviewerName,
                   Score = review.Score ?? throw new ArgumentException("review score cannot be null.", nameof(review)),
                   Text = review.Text
               };*/

        public static List<User> Map(IEnumerable<DBContext.Models.User> users) => users.Select(Map).ToList();

//            public static IEnumerable<Context.Models.Restaurant> Map(IEnumerable<Restaurant> restaurants) => restaurants.Select(Map);

  //          public static IEnumerable<Review> Map(IEnumerable<Context.Models.Review> reviews) => reviews.Select(Map);

    //        public static IEnumerable<Context.Models.Review> Map(IEnumerable<Review> reviews) => reviews.Select(Map);
        }
    
}
