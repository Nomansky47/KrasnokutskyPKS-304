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
    public class AirportsController : Controller
    {
        private readonly MyContext _context;

        public AirportsController(MyContext context)
        {
            _context = context;
        }

        // GET: Airports
        public async Task<IActionResult> Index()
        {
              return _context.Airports != null ? 
                          View(await _context.Airports.ToListAsync()) :
                          Problem("Entity set 'MyContext.Airports'  is null.");
        }

        // GET: Airports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Airports == null)
            {
                return NotFound();
            }

            var airports = await _context.Airports
                .FirstOrDefaultAsync(m => m.AirportID == id);
            if (airports == null)
            {
                return NotFound();
            }

            return View(airports);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirportID,AirportName")] Airports airports)
        {
           
                _context.Add(airports);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Airports == null)
            {
                return NotFound();
            }

            var airports = await _context.Airports.FindAsync(id);
            if (airports == null)
            {
                return NotFound();
            }
            return View(airports);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirportID,AirportName")] Airports airports)
        {
            if (id != airports.AirportID)
            {
                return NotFound();
            }

          
                try
                {
                    _context.Update(airports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportsExists(airports.AirportID))
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

        // GET: Airports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Airports == null)
            {
                return NotFound();
            }

            var airports = await _context.Airports
                .FirstOrDefaultAsync(m => m.AirportID == id);
            if (airports == null)
            {
                return NotFound();
            }

            return View(airports);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Airports == null)
            {
                return Problem("Entity set 'MyContext.Airports'  is null.");
            }
            var airports = await _context.Airports.FindAsync(id);
            if (airports != null)
            {
                _context.Airports.Remove(airports);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirportsExists(int id)
        {
          return (_context.Airports?.Any(e => e.AirportID == id)).GetValueOrDefault();
        }
    }
}
