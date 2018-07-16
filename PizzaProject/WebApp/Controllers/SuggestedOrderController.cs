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
    public class SuggestedOrderController : Controller
    {
        private readonly PizzaStoreContext _context;

        public SuggestedOrderController(PizzaStoreContext context)
        {
            _context = context;
        }

        // GET: SuggestedOrder
        public async Task<IActionResult> Index()
        {
            var pizzaStoreContext = _context.OrderDb.Include(o => o.Loc).Include(o => o.User);
            return View(await pizzaStoreContext.ToListAsync());
        }

        // GET: SuggestedOrder/Details/5
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

        // GET: SuggestedOrder/Create
        public IActionResult Create()
        {
            ViewData["LocId"] = new SelectList(_context.LocationDb, "LocationId", "LocationId");
            ViewData["UserId"] = new SelectList(_context.UserDb, "UserId", "UserId");
            return View();
        }

        // POST: SuggestedOrder/Create
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

        // GET: SuggestedOrder/Edit/5
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

        // POST: SuggestedOrder/Edit/5
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

        // GET: SuggestedOrder/Delete/5
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

        // POST: SuggestedOrder/Delete/5
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
