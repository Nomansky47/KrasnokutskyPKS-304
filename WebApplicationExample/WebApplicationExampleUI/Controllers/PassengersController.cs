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
    public class PassengersController : Controller
    {
        private MyContext _context;

        public PassengersController(MyContext context)
        {
            _context = context;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
              return _context.Passengers != null ? 
                          View(await _context.Passengers.ToListAsync()) :
                          Problem("Entity set 'MyContext.Passengers'  is null.");
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passengers = await _context.Passengers
                .FirstOrDefaultAsync(m => m.Userlogin == id);
            if (passengers == null)
            {
                return NotFound();
            }

            return View(passengers);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userlogin,password,UserType,Surname,Name,Patronymic")] Passengers passengers)
        {
                _context.Add(passengers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passengers = await _context.Passengers.FindAsync(id);
            if (passengers == null)
            {
                return NotFound();
            }
            return View(passengers);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Userlogin,password,UserType,Surname,Name,Patronymic")] Passengers passengers)
        {
            if (id != passengers.Userlogin)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(passengers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengersExists(passengers.Userlogin))
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

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passengers = await _context.Passengers
                .FirstOrDefaultAsync(m => m.Userlogin == id);
            if (passengers == null)
            {
                return NotFound();
            }

            return View(passengers);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'MyContext.Passengers'  is null.");
            }
            var passengers = await _context.Passengers.FindAsync(id);
            if (passengers != null)
            {
                _context.Passengers.Remove(passengers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengersExists(string id)
        {
          return (_context.Passengers?.Any(e => e.Userlogin == id)).GetValueOrDefault();
        }
    }
}
