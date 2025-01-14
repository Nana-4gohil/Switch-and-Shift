﻿using System;
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
    public class ADMINsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ADMINsController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public ActionResult AdminLogIn()
        {
            string email = HttpContext.Session.GetString("Admin_Email");
            if(email!=null)
            {
                return RedirectToAction("Index", "ADMINs");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogIn(ADMIN aDMIN)
        {
            var checklogin = db.ADMIN.Where(x => x.Admin_Email.Equals(aDMIN.Admin_Email) &&
            x.Admin_Password.Equals(aDMIN.Admin_Password)).FirstOrDefault();

            if (checklogin != null)
            {

                HttpContext.Session.SetString("Admin_Email", checklogin.Admin_Email.ToString());
                HttpContext.Session.SetString("Admin_Password", checklogin.Admin_Password.ToString());
                ModelState.Clear();
                return RedirectToAction("Index", "ADMINs");
            }
            else
            {
                ModelState.Clear();
                ViewBag.Notification = "Wrong username or password";
            }
            return View();
        }
        [HttpGet]
        public ActionResult ShowReview(int? id)
        {
            var reviewee = db.USERS.Where(c => c.UserId == id).FirstOrDefault();
            return View(db.USERREVIEW.Where(x => x.reviewee_email == reviewee.Email).ToList().FirstOrDefault());
        }

        [HttpGet]
        public ActionResult Ban(int? id)
        {
            
                var rEPORTS_User = db.USERS.Where(m => m.UserId == id)
               .FirstOrDefault();
                rEPORTS_User.report_show = 0;
                db.Update(rEPORTS_User);
                db.SaveChanges();
            
            return RedirectToAction("Index", "ADMINs");
        }

        [HttpGet]
        public ActionResult Unban(int? id)
        {

            var rEPORTS_User = db.USERS.Where(m => m.UserId == id)
           .FirstOrDefault();
            rEPORTS_User.report_show = 1;
            db.Update(rEPORTS_User);
            db.SaveChanges();

            return RedirectToAction("Index", "ADMINs");
        }


        public IActionResult Index()
        {
            var displaydata = db.USERS.ToList();
            return View(displaydata);
        }

   

        [HttpGet ]
        //GET: ADMINs
        public async Task<IActionResult> Index(string UserSearch)
         {
            ViewData["GetUserDetails"] = UserSearch;
            var userQuery = from x in db.USERS select x;
            if (!String.IsNullOrEmpty(UserSearch))
            {
                userQuery = userQuery.Where(x => x.Email.Contains(UserSearch));
            }
            return View(await userQuery.AsNoTracking().ToListAsync());

        }

         // GET: ADMINs/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var uSERS = await db.USERS
                 .FirstOrDefaultAsync(m => m.UserId == id);
             if (uSERS == null)
             {
                 return NotFound();
             }

             return View(uSERS);
         }

          //GET: ADMINs/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: ADMINs/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create(ADMIN uSERS)
         {
             if (ModelState.IsValid)
             {
                 db.Add(uSERS);
                 await db.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(uSERS);
         }

         // GET: ADMINs/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var uSERS = await db.USERS.FindAsync(id);
             if (uSERS == null)
             {
                 return NotFound();
             }
             return View(uSERS);
         }

         // POST: ADMINs/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("UserID,FisrtName,LastName,District,Loaction,Email,Phone,Pasword")] USERS uSERS)
         {
             if (id != uSERS.UserId)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     db.Update(uSERS);
                     await db.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!USERSExists(uSERS.UserId))
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
             return View(uSERS);
         }

        private bool USERSExists(int userId)
        {
            throw new NotImplementedException();
        }

        // GET: ADMINs/Delete/5
        public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var uSERS = await db.USERS
                 .FirstOrDefaultAsync(m => m.UserId == id);
             if (uSERS == null)
             {
                 return NotFound();
             }

             return View(uSERS);
         }

         // POST: ADMINs/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var uSERS = await db.USERS.FindAsync(id);
             db.USERS.Remove(uSERS);
             await db.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

        
    }
}
