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
        //public IEnumerable<Models.User> GetUsers()
        //{
        //    // disable pointless tracking for performance
        //    var UserList = Mapper.Map(_db.User);
        //    //  return Mapper.Map(_db.User).ToList();
        //    return UserList;
        //}

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

        public IEnumerable<Models.Order> GetOrders()
        {


            return Mapper.Map(_db.OrderDb);
        }

        public IEnumerable<Models.User> GetUsers()
        {

            return Mapper.Map(_db.UserDb);
        }

        
    }
}
