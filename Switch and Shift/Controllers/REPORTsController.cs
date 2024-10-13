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
    public class REPORTsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public REPORTsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: REPORTs
        public async Task<IActionResult> Index()
        {            
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> BoughtProducts()
        {
            var reportQuery = from x in _context.REPORT select x;
            reportQuery = reportQuery.Where(x => x.buyer_email == HttpContext.Session.GetString("Email"));
            return View(await reportQuery.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> SoldProducts()
        {
            var reportQuery = from x in _context.REPORT select x;
            reportQuery = reportQuery.Where(x => x.seller_email == HttpContext.Session.GetString("Email"));
            return View(await reportQuery.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> CreateReport(string id)
        {
            bool check = true;
            var reportQuery = from x in _context.REPORTS_ADMIN select x;
            foreach (REPORTS_ADMIN rep in reportQuery)
            {
                if (rep.reporter_email == HttpContext.Session.GetString("Email")
                    && rep.reportee_email == id)
                {
                    check = false;
                }
            }

            if (check)
            {                
                //success Toast
                REPORTS_ADMIN report = new REPORTS_ADMIN();
                report.reportee_email = id;
                report.report_show = 1;
                report.reporter_email = HttpContext.Session.GetString("Email");
                report.reportee_name = _context.USERS.FirstOrDefault(m => m.Email == report.reportee_email).FirstName.ToString() + " " +
                    _context.USERS.FirstOrDefault(m => m.Email == report.reportee_email).LastName.ToString();
                report.reporter_name = _context.USERS.FirstOrDefault(m => m.Email == report.reporter_email).FirstName.ToString() + " " +
                    _context.USERS.FirstOrDefault(m => m.Email == report.reporter_email).LastName.ToString();
                _context.REPORTS_ADMIN.Add(report);
                _context.SaveChanges();
            }
            else
            {
                
                //ERROR TOAST
                ViewBag.CreateReportNotification = "You've already submitted a report";
            }
            return RedirectToAction("SoldProducts", "REPORTS");
        }

        [HttpGet]
        public async Task<IActionResult> CreateReport2(string id)
        {
            bool check = true;
            var reportQuery = from x in _context.REPORTS_ADMIN select x;
            foreach (REPORTS_ADMIN rep in reportQuery)
            {
                if (rep.reporter_email == HttpContext.Session.GetString("Email")
                    && rep.reportee_email == id)
                {
                    check = false;
                }
            }
            if (check)
            {
                //success Toast
                REPORTS_ADMIN report = new REPORTS_ADMIN();
                report.reportee_email = id;
                report.report_show = 1;
                report.reporter_email = HttpContext.Session.GetString("Email");
                report.reportee_name = _context.USERS.FirstOrDefault(m => m.Email == report.reportee_email).FirstName.ToString() + " " +
                    _context.USERS.FirstOrDefault(m => m.Email == report.reportee_email).LastName.ToString();
                report.reporter_name = _context.USERS.FirstOrDefault(m => m.Email == report.reporter_email).FirstName.ToString() + " " +
                    _context.USERS.FirstOrDefault(m => m.Email == report.reporter_email).LastName.ToString();
                _context.REPORTS_ADMIN.Add(report);
                _context.SaveChanges();
            }
            else
            {
                //FIX BUG
                //ERROR TOAST
                ViewBag.CreateReportNotification2 = "You've already submitted a report";
            }
            return RedirectToAction("BoughtProducts", "REPORTS");
        }



        [HttpGet]
        public async Task<IActionResult> AddReview(string id)
        {
            var reviewee = _context.USERS.Where(c => c.Email == id).FirstOrDefault();
            return RedirectToAction("UserReview", "USERS", new { @id = reviewee.UserId });
        }


       


        // GET: REPORTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPORT = await _context.REPORT
                .FirstOrDefaultAsync(m => m.report_Id == id);
            if (rEPORT == null)
            {
                return NotFound();
            }

            return View(rEPORT);
        }

        // GET: REPORTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: REPORTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("report_Id,product_model,product_brand,product_price,buyer_email,seller_email")] REPORT rEPORT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rEPORT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rEPORT);
        }

        // GET: REPORTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPORT = await _context.REPORT.FindAsync(id);
            if (rEPORT == null)
            {
                return NotFound();
            }
            return View(rEPORT);
        }

        // POST: REPORTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("report_Id,product_model,product_brand,product_price,buyer_email,seller_email")] REPORT rEPORT)
        {
            if (id != rEPORT.report_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rEPORT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!REPORTExists(rEPORT.report_Id))
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
            return View(rEPORT);
        }

        // GET: REPORTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPORT = await _context.REPORT
                .FirstOrDefaultAsync(m => m.report_Id == id);
            if (rEPORT == null)
            {
                return NotFound();
            }

            return View(rEPORT);
        }

        // POST: REPORTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rEPORT = await _context.REPORT.FindAsync(id);
            _context.REPORT.Remove(rEPORT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool REPORTExists(int id)
        {
            return _context.REPORT.Any(e => e.report_Id == id);
        }
    }
}
