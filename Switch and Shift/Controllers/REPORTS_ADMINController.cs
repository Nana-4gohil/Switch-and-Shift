using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Switch_and_Shift.Models;

namespace Switch_and_Shift.Controllers
{
    public class REPORTS_ADMINController : Controller
    {
        private readonly ApplicationDbContext _context;

        public REPORTS_ADMINController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: REPORTS_ADMIN
        public async Task<IActionResult> Index()
        {
            return View(await _context.REPORTS_ADMIN.ToListAsync());
        }


        // GET: REPORTS_ADMIN/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPORTS_ADMIN = await _context.REPORTS_ADMIN
                .FirstOrDefaultAsync(m => m.report_admin_id == id);
            if (rEPORTS_ADMIN == null)
            {
                return NotFound();
            }

            return View(rEPORTS_ADMIN);
        }

        // GET: REPORTS_ADMIN/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: REPORTS_ADMIN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("report_admin_id,reporter_email,reportee_email")] REPORTS_ADMIN rEPORTS_ADMIN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rEPORTS_ADMIN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rEPORTS_ADMIN);
        }

        // GET: REPORTS_ADMIN/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPORTS_ADMIN = await _context.REPORTS_ADMIN.FindAsync(id);
            if (rEPORTS_ADMIN == null)
            {
                return NotFound();
            }
            return View(rEPORTS_ADMIN);
        }


        [HttpGet]
        public async Task<IActionResult> ReportPost2(int? id)
        {
            if (id.HasValue)
            {
                var rEPORTS_ADMIN = await _context.REPORTS_ADMIN
                 .FirstOrDefaultAsync(m => m.report_admin_id == id);
                rEPORTS_ADMIN.report_show = 0;
                _context.Update(rEPORTS_ADMIN);
                await _context.SaveChangesAsync();
            }
            
            var  reportQuery =  from x in _context.REPORTS_ADMIN select x;
            reportQuery = reportQuery.Where(x => x.report_show == 1);
            return View(await reportQuery.AsNoTracking().ToListAsync());
        }



        // POST: REPORTS_ADMIN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("report_admin_id,reporter_email,reportee_email")] REPORTS_ADMIN rEPORTS_ADMIN)
        {
            if (id != rEPORTS_ADMIN.report_admin_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rEPORTS_ADMIN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!REPORTS_ADMINExists(rEPORTS_ADMIN.report_admin_id))
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
            return View(rEPORTS_ADMIN);
        }

        // GET: REPORTS_ADMIN/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPORTS_ADMIN = await _context.REPORTS_ADMIN
                .FirstOrDefaultAsync(m => m.report_admin_id == id);
            if (rEPORTS_ADMIN == null)
            {
                return NotFound();
            }

            return View(rEPORTS_ADMIN);
        }

        // POST: REPORTS_ADMIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rEPORTS_ADMIN = await _context.REPORTS_ADMIN.FindAsync(id);
            _context.REPORTS_ADMIN.Remove(rEPORTS_ADMIN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool REPORTS_ADMINExists(int id)
        {
            return _context.REPORTS_ADMIN.Any(e => e.report_admin_id == id);
        }
    }
}
