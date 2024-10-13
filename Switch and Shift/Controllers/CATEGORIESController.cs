using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Switch_and_Shift.Models;

namespace Switch_and_Shift.Controllers
{
    public class CATEGORIESController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CATEGORIESController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CATEGORIES
        public async Task<IActionResult> Index()
        {
            return View(await _context.CATEGORIES.ToListAsync());
        }

        // GET: CATEGORIES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cATEGORIES = await _context.CATEGORIES
                .FirstOrDefaultAsync(m => m.categories_id == id);
            if (cATEGORIES == null)
            {
                return NotFound();
            }

            return View(cATEGORIES);
        }

        // GET: CATEGORIES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("categories_id,categories_name")] CATEGORIES cATEGORIES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cATEGORIES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cATEGORIES);
        }

        // GET: CATEGORIES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cATEGORIES = await _context.CATEGORIES.FindAsync(id);
            if (cATEGORIES == null)
            {
                return NotFound();
            }
            return View(cATEGORIES);
        }

        // POST: CATEGORIES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("categories_id,categories_name")] CATEGORIES cATEGORIES)
        {
            if (id != cATEGORIES.categories_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cATEGORIES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CATEGORIESExists(cATEGORIES.categories_id))
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
            return View(cATEGORIES);
        }

        // GET: CATEGORIES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cATEGORIES = await _context.CATEGORIES
                .FirstOrDefaultAsync(m => m.categories_id == id);
            if (cATEGORIES == null)
            {
                return NotFound();
            }

            return View(cATEGORIES);
        }

        // POST: CATEGORIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cATEGORIES = await _context.CATEGORIES.FindAsync(id);
            _context.CATEGORIES.Remove(cATEGORIES);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CATEGORIESExists(int id)
        {
            return _context.CATEGORIES.Any(e => e.categories_id == id);
        }
    }
}
