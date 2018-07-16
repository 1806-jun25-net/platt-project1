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
    public class UserController : Controller
    {

        public PizzaStoreRepo Repo { get; }

        public UserController(PizzaStoreRepo repo)
        {
            Repo = repo;
        }

        // GET: User
        public ActionResult Index()
        {
            UserWeb user = new UserWeb();
            //var libUsers = Repo.Get(search);
            //var webRests = libRests.Select(x => new Restaurant
            return View(user);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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
        public ActionResult Index(UserWeb User)
        {
            
            


            List < MainLibrary.Models.User > listofusersfromdb= new List<MainLibrary.Models.User>();

            listofusersfromdb = Repo.GetUsers().ToList();

            bool useralreadyexists = false;

            foreach(MainLibrary.Models.User usersthatexist in listofusersfromdb)
            {
                if(usersthatexist.FirstName == User.FirstName && usersthatexist.LastName == User.LastName)
                {

                    User.UserID = Repo.getUserID(usersthatexist.FirstName, usersthatexist.LastName);
                    TempData["CurrentUserID"] = User.UserID;
                    useralreadyexists = true;
                    break;

                }

            }

            if(useralreadyexists)
            {

                ModelState.AddModelError("", "User Already Exists! ");

            }
            else
            {
                Repo.AddUser(Mapper.Map(User));
                Repo.SaveChanges();
                User.UserID = Repo.getUserID(User.FirstName, User.LastName);

                TempData["CurrentUserID"] = User.UserID;


                return RedirectToAction("Index", ""); 
            }



            return View(User);

        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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