using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {

        public PizzaStoreRepo Repo { get; }

        public OrderController(PizzaStoreRepo repo)
        {
            Repo = repo;
        }
        // GET: Order

        public ActionResult Index()
        {
            OrderWeb weborder = new OrderWeb();
            //var libUsers = Repo.Get(search);
            //var webRests = libRests.Select(x => new Restaurant
            return View(weborder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OrderWeb ordertoplace)
        {
            int herndoninventoryfromdb = Repo.getHerndonInventory();
            int restoninventoryfromdb = Repo.getRestonInventory();

            int userID = (int)TempData["CurrentUserID"];

            UserWeb currentuser = new UserWeb();
            LocationWeb location = new LocationWeb();

            //List<MainLibrary.Models.Order> allOrders = Repo.GetOrders().Reverse().ToList();

            //foreach (MainLibrary.Models.Order order in allOrders)

            //{
            //    if(order.User.UserID == userID)
            //    {
            //        TimeSpan diff = DateTime.Now - order.TimeOfOrder;

            //        if (diff.TotalHours > 2)
            //        {
            //            ModelState.AddModelError("", "You ordered less than two hours ago!!!!");
            //            TempData["CurrentUserID"] = userID;
            //            break;

            //        }
            //    }

            //}


            


            string userStore = Repo.getUserStore(userID);
            location.StoreName = userStore;

            if (userStore == "Reston")
            {
                location.LocID = 2;
                location.StoredPizza = Repo.getRestonInventory();
            }
            else if (userStore == "Herndon")
            {
                location.StoredPizza = Repo.getHerndonInventory();
                location.LocID = 1;
            }

            string firstName = Repo.getFirstName(userID);
            string lastName = Repo.getLastName(userID);

            currentuser.setUser(firstName, lastName, userStore, userID);


            ordertoplace.Location = location;
            ordertoplace.User = currentuser;


            if(Decimal.Compare(ordertoplace.CalcOrderPrice(), 500.0m) > 0)
            {
                ModelState.AddModelError("", "That is more than $500!!!!");
                TempData["CurrentUserID"] = userID;
                return View(ordertoplace);

            }

            if (userStore == "Herndon")
            {

                if ((herndoninventoryfromdb - ordertoplace.amountDough()) < 0)
                {
                    ModelState.AddModelError("", "Not enough inventory left from Herndon please order less!!!!");
                    TempData["CurrentUserID"] = userID;

                }
                else
                    {
                    Repo.AddOrder(Mapper.Map(ordertoplace));
                    Repo.SaveChanges();
                    Repo.removeFromHerndonInv(ordertoplace.amountDough());
                    Repo.SaveChanges();
                    return RedirectToAction("Index", "");

                }
            }

            else if(userStore == "Reston")
            {
                if ((restoninventoryfromdb - ordertoplace.amountDough()) < 0)
                {
                    ModelState.AddModelError("", "Not enough inventory left from Reston please order less!!!!");
                    TempData["CurrentUserID"] = userID;
                }
                else
                    {
                    int doughtosubtract = ordertoplace.amountDough();
                    Repo.AddOrder(Mapper.Map(ordertoplace));
                    Repo.SaveChanges();
                    Repo.removeFromRestonInv(doughtosubtract);
                    Repo.SaveChanges();
                    return RedirectToAction("Index", "");
                }
            }

            

            return View(ordertoplace);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(OrderWeb Ordertoplace)
        {

            return View();
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}