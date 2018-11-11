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
    public class FranchiseController : Controller
    {
        private readonly XPOSTDbContext _context;

        public FranchiseController(XPOSTDbContext context)
        {
            _context = context;
        }

        // GET: Franchise
        public async Task<IActionResult> Index()
        {
            return View(await _context.Franchises.ToListAsync());
        }

        // GET: Franchise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises
                .FirstOrDefaultAsync(m => m.ID == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // GET: Franchise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Type,Address")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchise);
        }

        // GET: Franchise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            return View(franchise);
        }

        // POST: Franchise/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,Address")] Franchise franchise)
        {
            if (id != franchise.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchiseExists(franchise.ID))
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
            return View(franchise);
        }

        // GET: Franchise/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises
                .FirstOrDefaultAsync(m => m.ID == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // POST: Franchise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(e => e.ID == id);
        }
    }
}
