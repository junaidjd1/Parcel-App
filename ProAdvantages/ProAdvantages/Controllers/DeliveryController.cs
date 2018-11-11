using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProAdvantages.Db;
using ProAdvantages.Models;

namespace ProAdvantages.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly XPOSTDbContext _context;

        public DeliveryController(XPOSTDbContext context)
        {
            _context = context;
        }

        // GET: Delivery
        public async Task<IActionResult> Index()
        {
            var xPOSTDbContext = _context.Deliveryservices.Include(d => d.Parcel);
            return View(await xPOSTDbContext.ToListAsync());
        }

        // GET: Delivery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryService = await _context.Deliveryservices
                .Include(d => d.Parcel)
                .FirstOrDefaultAsync(m => m.DSID == id);
            if (deliveryService == null)
            {
                return NotFound();
            }

            return View(deliveryService);
        }

        // GET: Delivery/Create
        public IActionResult Create()
        {
            ViewData["PID"] = new SelectList(_context.Parcels, "PID", "PID");
            return View();
        }

        // POST: Delivery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DSID,Type,DeliveryRoute,PID")] DeliveryService deliveryService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PID"] = new SelectList(_context.Parcels, "PID", "PID", deliveryService.PID);
            return View(deliveryService);
        }

        // GET: Delivery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryService = await _context.Deliveryservices.FindAsync(id);
            if (deliveryService == null)
            {
                return NotFound();
            }
            ViewData["PID"] = new SelectList(_context.Parcels, "PID", "PID", deliveryService.PID);
            return View(deliveryService);
        }

        // POST: Delivery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DSID,Type,DeliveryRoute,PID")] DeliveryService deliveryService)
        {
            if (id != deliveryService.DSID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryServiceExists(deliveryService.DSID))
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
            ViewData["PID"] = new SelectList(_context.Parcels, "PID", "PID", deliveryService.PID);
            return View(deliveryService);
        }

        // GET: Delivery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryService = await _context.Deliveryservices
                .Include(d => d.Parcel)
                .FirstOrDefaultAsync(m => m.DSID == id);
            if (deliveryService == null)
            {
                return NotFound();
            }

            return View(deliveryService);
        }

        // POST: Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryService = await _context.Deliveryservices.FindAsync(id);
            _context.Deliveryservices.Remove(deliveryService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryServiceExists(int id)
        {
            return _context.Deliveryservices.Any(e => e.DSID == id);
        }
    }
}
