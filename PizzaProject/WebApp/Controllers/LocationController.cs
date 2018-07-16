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
    public class LocationController : Controller
    {

        public PizzaStoreRepo Repo { get; }

        public LocationController(PizzaStoreRepo repo)
        {
            Repo = repo;
        }


        public ActionResult Index()
        {
            OrderWeb weborder = new OrderWeb();
            //var libUsers = Repo.Get(search);
            //var webRests = libRests.Select(x => new Restaurant
            return View(weborder);
        }

        // GET: Location
        public ActionResult Index(LocationWeb locationweb)
        {
            int herndoninventoryfromdb = Repo.getHerndonInventory();
            int restoninventoryfromdb = Repo.getRestonInventory();

            if (herndoninventoryfromdb == 20)
            {
                ModelState.AddModelError("", "yay herndonis20!!!");
            }
        

            return View(locationweb);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
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

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
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

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
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