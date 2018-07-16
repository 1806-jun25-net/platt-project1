using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBContext.Models;

namespace WebApp.Controllers
{
    public class OrderDbsController : Controller
    {
        private readonly PizzaStoreContext _context;

        public OrderDbsController(PizzaStoreContext context)
        {
            _context = context;
        }

        // GET: OrderDbs
        public async Task<IActionResult> Index(string sortOrder, string userID, string userIDLast, string StoreID)
        {
            var pizzaStoreContext = _context.OrderDb.Include(o => o.Loc).Include(o => o.User);

            ViewBag.PriceSortParm =  sortOrder == "Price" ? "price_desc": "Price";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var orders = from s in _context.OrderDb
                           select s;

            //Convert.ToInt32(userID);
           
            if (!String.IsNullOrEmpty(userID) && !String.IsNullOrEmpty(userIDLast))
            {

                orders = orders.Where(u => u.User.FirstName.Equals(userID) && u.User.LastName.Equals(userIDLast));
                //students = students.Where(s => s.LastName.Contains(searchString)
                  //             || s.FirstMidName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(StoreID))
            {

                orders = orders.Where(u => u.Loc.Address.Equals(StoreID));
                //students = students.Where(s => s.LastName.Contains(searchString)
                //             || s.FirstMidName.Contains(searchString));
            }


            switch (sortOrder)
            {
                
                case "Price":
                    orders = orders.OrderBy(s => s.OrderTotalPrice);
                    break;
                case "price_desc":
                    orders = orders.OrderByDescending(s => s.OrderTotalPrice);
                    break;

                case "Date":
                    orders = orders.OrderBy(s => s.TimeofOrder);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(s => s.TimeofOrder);
                    break;

                default:
                    orders = orders.OrderBy(s => s.TimeofOrder);
                    break;
            }
            return View(orders.ToList());



            return View(await pizzaStoreContext.ToListAsync());
        }

        // GET: OrderDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDb = await _context.OrderDb
                .Include(o => o.Loc)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderDb == null)
            {
                return NotFound();
            }

            return View(orderDb);
        }

        // GET: OrderDbs/Create
        public IActionResult Create()
        {
            ViewData["LocId"] = new SelectList(_context.LocationDb, "LocationId", "LocationId");
            ViewData["UserId"] = new SelectList(_context.UserDb, "UserId", "UserId");
            return View();
        }

        // POST: OrderDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,LocId,Opizza1,Opizza2,Opizza3,Opizza4,Opizza5,Opizza6,Opizza7,Opizza8,Opizza9,Opizza10,Opizza11,Opizza12,TimeofOrder,OrderTotalPrice")] OrderDb orderDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocId"] = new SelectList(_context.LocationDb, "LocationId", "LocationId", orderDb.LocId);
            ViewData["UserId"] = new SelectList(_context.UserDb, "UserId", "UserId", orderDb.UserId);
            return View(orderDb);
        }

        // GET: OrderDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDb = await _context.OrderDb.FindAsync(id);
            if (orderDb == null)
            {
                return NotFound();
            }
            ViewData["LocId"] = new SelectList(_context.LocationDb, "LocationId", "LocationId", orderDb.LocId);
            ViewData["UserId"] = new SelectList(_context.UserDb, "UserId", "UserId", orderDb.UserId);
            return View(orderDb);
        }

        // POST: OrderDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,UserId,LocId,Opizza1,Opizza2,Opizza3,Opizza4,Opizza5,Opizza6,Opizza7,Opizza8,Opizza9,Opizza10,Opizza11,Opizza12,TimeofOrder,OrderTotalPrice")] OrderDb orderDb)
        {
            if (id != orderDb.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDbExists(orderDb.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocId"] = new SelectList(_context.LocationDb, "LocationId", "LocationId", orderDb.LocId);
            ViewData["UserId"] = new SelectList(_context.UserDb, "UserId", "UserId", orderDb.UserId);
            return View(orderDb);
        }

        // GET: OrderDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDb = await _context.OrderDb
                .Include(o => o.Loc)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderDb == null)
            {
                return NotFound();
            }

            return View(orderDb);
        }

        // POST: OrderDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDb = await _context.OrderDb.FindAsync(id);
            _context.OrderDb.Remove(orderDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDbExists(int id)
        {
            return _context.OrderDb.Any(e => e.OrderId == id);
        }
    }
}
