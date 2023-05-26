using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationExampleUI.Data;
using WebApplicationExampleUI.Models;

namespace WebApplicationExampleUI.Controllers
{
    public class AircraftsController : Controller
    {
        private readonly MyContext _context;

        public AircraftsController(MyContext context)
        {
            _context = context;
        }

        // GET: Aircrafts
        public async Task<IActionResult> Index()
        {
              return _context.Aircrafts != null ? 
                          View(await _context.Aircrafts.ToListAsync()) :
                          Problem("Entity set 'MyContext.Aircrafts'  is null.");
        }

        // GET: Aircrafts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aircrafts == null)
            {
                return NotFound();
            }

            var aircrafts = await _context.Aircrafts
                .FirstOrDefaultAsync(m => m.AircraftID == id);
            if (aircrafts == null)
            {
                return NotFound();
            }

            return View(aircrafts);
        }

        // GET: Aircrafts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aircrafts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AircraftID,PlaneType,NumberOfSeats")] Aircrafts aircrafts)
        {
                _context.Add(aircrafts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Aircrafts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aircrafts == null)
            {
                return NotFound();
            }

            var aircrafts = await _context.Aircrafts.FindAsync(id);
            if (aircrafts == null)
            {
                return NotFound();
            }
            return View(aircrafts);
        }

        // POST: Aircrafts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AircraftID,PlaneType,NumberOfSeats")] Aircrafts aircrafts)
        {
            if (id != aircrafts.AircraftID)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(aircrafts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftsExists(aircrafts.AircraftID))
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

        // GET: Aircrafts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aircrafts == null)
            {
                return NotFound();
            }

            var aircrafts = await _context.Aircrafts
                .FirstOrDefaultAsync(m => m.AircraftID == id);
            if (aircrafts == null)
            {
                return NotFound();
            }

            return View(aircrafts);
        }

        // POST: Aircrafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aircrafts == null)
            {
                return Problem("Entity set 'MyContext.Aircrafts'  is null.");
            }
            var aircrafts = await _context.Aircrafts.FindAsync(id);
            if (aircrafts != null)
            {
                _context.Aircrafts.Remove(aircrafts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftsExists(int id)
        {
          return (_context.Aircrafts?.Any(e => e.AircraftID == id)).GetValueOrDefault();
        }
    }
}
