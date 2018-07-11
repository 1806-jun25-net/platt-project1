using DBContext.Models;
using MainLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MainLibrary.Repositories
{
    public class PizzaStoreRepo
    {

        private readonly PizzaStoreContext _db;

        /// <summary>
        /// Initializes a new pizzastore repo given a suitable Entity Framework DbContext.
        /// </summary>
        /// <param name="db">The DbContext</param>
        public PizzaStoreRepo(PizzaStoreContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        /// <summary>
        /// get all users from database as a list
        /// </summary>
        /// 
        public IEnumerable<Models.User> GetUsers()
        {
            // disable pointless tracking for performance
            var UserList = Mapper.Map(_db.User);
            //  return Mapper.Map(_db.User).ToList();
            return UserList;
        }

        public void AddOrder(Models.Order order)
        {
            _db.Add(Mapper.Map(order));
        }

        public void AddUser(Models.User user)
        {
            _db.Add(Mapper.Map(user)); 
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        /// <summary>
        /// Add a restaurant, including any associated reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant</param>
        //public void AddRestaurant(Models.Restaurant restaurant)
        //{
        //    _db.Add(Mapper.Map(restaurant));
        //}

        ///// <summary>
        ///// Delete a restaurant by ID. Any reviews associated to it will not be deleted.
        ///// </summary>
        ///// <param name="restaurantId">The ID of the restaurant</param>
        //public void DeleteRestaurant(int restaurantId)
        //{
        //    _db.Remove(_db.Restaurant.Find(restaurantId));
        //}
    }
}
