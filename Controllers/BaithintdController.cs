using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaithiNTD0195.Models;

namespace BaithiNTD0195.Controllers
{
    public class BaithintdController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaithintdController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Baithintd
        public async Task<IActionResult> Index()
        {
              return _context.Baithintd != null ? 
                          View(await _context.Baithintd.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Baithintd'  is null.");
        }

        // GET: Baithintd/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Baithintd == null)
            {
                return NotFound();
            }

            var baithintd = await _context.Baithintd
                .FirstOrDefaultAsync(m => m.ID == id);
            if (baithintd == null)
            {
                return NotFound();
            }

            return View(baithintd);
        }

        // GET: Baithintd/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baithintd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName,Number")] Baithintd baithintd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baithintd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baithintd);
        }

        // GET: Baithintd/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Baithintd == null)
            {
                return NotFound();
            }

            var baithintd = await _context.Baithintd.FindAsync(id);
            if (baithintd == null)
            {
                return NotFound();
            }
            return View(baithintd);
        }

        // POST: Baithintd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,FullName,Number")] Baithintd baithintd)
        {
            if (id != baithintd.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baithintd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaithintdExists(baithintd.ID))
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
            return View(baithintd);
        }

        // GET: Baithintd/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Baithintd == null)
            {
                return NotFound();
            }

            var baithintd = await _context.Baithintd
                .FirstOrDefaultAsync(m => m.ID == id);
            if (baithintd == null)
            {
                return NotFound();
            }

            return View(baithintd);
        }

        // POST: Baithintd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Baithintd == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Baithintd'  is null.");
            }
            var baithintd = await _context.Baithintd.FindAsync(id);
            if (baithintd != null)
            {
                _context.Baithintd.Remove(baithintd);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaithintdExists(string id)
        {
          return (_context.Baithintd?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
