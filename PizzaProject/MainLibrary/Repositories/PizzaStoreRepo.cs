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

       
        public int getHerndonInventory()
        {
            int herndoninvfromdb = (from herndoninv in _db.LocationDb
                              where herndoninv.Address.Equals("Herndon")
                              select herndoninv.StoredPizza).SingleOrDefault();

            return herndoninvfromdb;

        }

        public int getRestonInventory()
        {
            int herndoninvfromdb = (from restoninv in _db.LocationDb
                                    where restoninv.Address.Equals("Reston")
                                    select restoninv.StoredPizza).SingleOrDefault();

            return herndoninvfromdb;

        }

        public int getUserID(string firstname, string lastname)
        {
            int userID = (from userid in _db.UserDb
                          where userid.FirstName.Equals(firstname)&& userid.LastName.Equals(lastname)
                          select userid.UserId).SingleOrDefault();

            return userID;

            
        }

        public string getUserStore(int userID)
        {
            string userStore = (from favstore in _db.UserDb
                          where favstore.UserId.Equals(userID)
                          select favstore.DefaultStore).SingleOrDefault();

            return userStore;


        }

        public string getFirstName(int userID)
        {
            string userFirst = (from first in _db.UserDb
                                where first.UserId.Equals(userID)
                                select first.FirstName).SingleOrDefault();

            return userFirst;


        }



        public string getLastName(int userID)
        {
            string userLast = (from last in _db.UserDb
                                where last.UserId.Equals(userID)
                                select last.LastName).SingleOrDefault();

            return userLast;


        }

        public void removeFromRestonInv(int amountDough)
        {

            Location loc = new Location();
            loc.StoreName = "Reston";
            loc.LocID = 2;
            loc.StoredPizza = getRestonInventory() - amountDough;

            _db.Entry(_db.LocationDb.Find(loc.LocID)).CurrentValues.SetValues(Mapper.Map(loc));





        }
        public void removeFromHerndonInv(int amountDough)
        {

            Location loc = new Location();
            loc.StoreName = "Herndon";
            loc.LocID = 1;
            loc.StoredPizza = getHerndonInventory() - amountDough;

            _db.Entry(_db.LocationDb.Find(loc.LocID)).CurrentValues.SetValues(Mapper.Map(loc));



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
