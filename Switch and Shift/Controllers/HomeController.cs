﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Switch_and_Shift.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Switch_and_Shift.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {   
            HttpContext.Session.Clear();
            return View(await _context.PRODUCTS.ToListAsync());
        }
        

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Team()
        {
            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Welcome()
        {   

            int currentUserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if (currentUserId == 0)
            {
                return RedirectToAction("Index","HOME");
            }
            var productQuery = from x in _context.PRODUCTS select x;
            var loc = _context.USERS.FirstOrDefault(m => m.UserId == currentUserId).District.ToString();
            productQuery = productQuery.Where(x => x.user_location == loc && x.UserId != currentUserId);
            productQuery = productQuery.Where(x => x.UserId != currentUserId &&
                _context.USERS.FirstOrDefault(m => m.UserId == x.UserId).report_show == 1);
            ViewBag.userLocationTitle = loc;
            return View(await productQuery.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
