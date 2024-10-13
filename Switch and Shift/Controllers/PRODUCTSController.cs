using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Switch_and_Shift.Models;
using Microsoft.AspNetCore.Http;
using Switch_and_Shift.Models;

namespace Switch_and_Shift.Controllers
{
    public class PRODUCTSController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public PRODUCTSController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: PRODUCTS, if there is any problem in running index, uncomment this
        /*        [HttpGet]
                public async Task<IActionResult> Index()
                {                   
                    return View(await _context.PRODUCTS.ToListAsync());
                }*/

        [HttpGet]
        public async Task<IActionResult> Index(string productSearch, string districtSearch, int? upperRange, int? lowerRange)
        {
            int currentUserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewData["GetProductDetails"] = productSearch;
            ViewData["GetDistrictDetails"] = districtSearch;
            ViewData["GetUpperRange"] = upperRange;
            ViewData["GetLowerRange"] = lowerRange;
            var productQuery = from x in _context.PRODUCTS select x;
            productQuery = productQuery.Where(x => x.UserId != currentUserId &&
                _context.USERS.FirstOrDefault(m => m.UserId == x.UserId).report_show == 1);

            if (!String.IsNullOrEmpty(productSearch))
            {
                productQuery = productQuery.Where(x => x.product_category.Contains(productSearch));
            }
            if (!String.IsNullOrEmpty(districtSearch))
            {
                productQuery = productQuery.Where(x => x.user_location.Contains(districtSearch));
            }
            if (upperRange != null)
            {
                productQuery = productQuery.Where(x => x.product_price <= upperRange);
            }
            if (lowerRange != null)
            {
                productQuery = productQuery.Where(x => x.product_price >= lowerRange);
            }
            return View(await productQuery.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public IActionResult Clear(string productSearch, string districtSearch, int? upperRange, int? lowerRange)
        {
            ViewData["GetProductDetails"] = "";
            ViewData["GetDistrictDetails"] = "";
            ViewData["GetUpperRange"] = null;
            ViewData["GetLowerRange"] = null;
            return RedirectToAction("Index", "PRODUCTS");
        }


        [HttpGet]
        public IActionResult ClearForMyProducts(string myProductBrand, string myProductCategory)
        {
            ViewData["GetMyProductBrand"] = "";
            ViewData["GetMyProductCategory"] = "";
            myProductBrand = "";
            myProductCategory = "";
            return RedirectToAction("MyProducts", "PRODUCTS");
        }


        // GET: PRODUCTS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRODUCTS = await _context.PRODUCTS
                .FirstOrDefaultAsync(m => m.Product_ID == id);
            if (pRODUCTS == null)
            {
                return NotFound();
            }

            return View(pRODUCTS);
        }

        [HttpGet]
        public async Task<IActionResult> soldOut(int? id)
        {

            var product = await _context.PRODUCTS.FindAsync(id);
            ViewBag.reportBrand = product.product_brand;
            ViewBag.reportPrice = product.product_price;
            ViewBag.reportModel = product.product_model;
            ViewBag.reportImageLocation = product.image_name;
            
            _context.PRODUCTS.Remove(product);
            await _context.SaveChangesAsync();

            ViewBag.reportSellerEmail = HttpContext.Session.GetString("Email");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> soldOut(REPORT report)
        {   
            
            
            if (report.buyer_email == HttpContext.Session.GetString("Email"))
            {
                ViewBag.NotificationOfReport = "You cannot give your own email";
                ViewBag.reportBrand = report.product_brand;
                ViewBag.reportPrice = report.product_price;
                ViewBag.reportModel = report.product_model;
                ViewBag.reportImageLocation = report.image_name;
                ViewBag.reportSellerEmail = HttpContext.Session.GetString("Email");
                return View();
            }

            if (_context.USERS.Any(x => x.Email == report.buyer_email))
            {
                report.buyer_name = _context.USERS.FirstOrDefault(m => m.Email == report.buyer_email).FirstName.ToString() +
                    " " + _context.USERS.FirstOrDefault(m => m.Email == report.buyer_email).LastName.ToString();
                report.seller_name = _context.USERS.FirstOrDefault(m => m.Email == HttpContext.Session.GetString("Email")).FirstName.ToString() +
                    " " + _context.USERS.FirstOrDefault(m => m.Email == HttpContext.Session.GetString("Email")).LastName.ToString();
                _context.REPORT.Add(report);
                _context.SaveChanges();
                return RedirectToAction("Welcome", "Home");
            }
            else
            {
                ViewBag.NotificationOfReport = "Invalid Email, User Doesn't exist";
                ViewBag.reportBrand = report.product_brand;
                ViewBag.reportPrice = report.product_price;
                ViewBag.reportModel = report.product_model;
                ViewBag.reportImageLocation = report.image_name;
                ViewBag.reportSellerEmail = HttpContext.Session.GetString("Email");
                return View();
            }


        }



        // GET: PRODUCTS/Create
        public IActionResult Create()
        {
            var categories = _context.CATEGORIES.ToList();
            List<SelectListItem> selectlist = new List<SelectListItem>();
            foreach (CATEGORIES cat in categories)
            {
                selectlist.Add(new SelectListItem { Text = cat.categories_name, Value = cat.categories_id.ToString() });
            }
            ViewBag.categoryListItem = selectlist;
            return View();
        }

        // POST: PRODUCTS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_ID,product_category,product_price,product_brand,product_model,product_details,product_warranty,product_usage,product_condition,UserId,ImageFile")] PRODUCTS productsModel)
        {

            if (ModelState.IsValid)
            {
                int categoryId = Convert.ToInt32(productsModel.product_category);
                productsModel.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                productsModel.user_location = _context.USERS.FirstOrDefault(m => m.UserId == productsModel.UserId).District.ToString();
                productsModel.post_date = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                productsModel.product_category = _context.CATEGORIES.FirstOrDefault(m => m.categories_id == categoryId).categories_name.ToString();
                string wwwrootPath = _hostEnvironment.WebRootPath;
                string FileName = Path.GetFileNameWithoutExtension(productsModel.ImageFile.FileName);
                string extension = Path.GetExtension(productsModel.ImageFile.FileName);
                productsModel.image_name = FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwrootPath + "/Image/" + FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await productsModel.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(productsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyProducts", "PRODUCTS");
            }
            var categories = _context.CATEGORIES.ToList();
            List<SelectListItem> selectlist = new List<SelectListItem>();
            foreach (CATEGORIES cat in categories)
            {
                selectlist.Add(new SelectListItem { Text = cat.categories_name, Value = cat.categories_id.ToString() });
            }
            ViewBag.categoryListItem = selectlist;
            return View(productsModel);
        }


        [HttpGet]
        public async Task<IActionResult> MyProducts(string myProductBrand, string myProductCategory)
        {
            int currentUserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var productQuery = from x in _context.PRODUCTS select x;
            ViewData["GetMyProductBrand"] = myProductBrand;
            ViewData["GetMyProductCategory"] = myProductCategory;
            productQuery = productQuery.Where(x => x.UserId == currentUserId);
            if (!String.IsNullOrEmpty(myProductBrand))
            {
                productQuery = productQuery.Where(x => x.product_brand.Contains(myProductBrand) || x.product_model.Contains(myProductBrand));
            }
            if (!String.IsNullOrEmpty(myProductCategory))
            {
                productQuery = productQuery.Where(x => x.product_category.Contains(myProductCategory));
            }
            
            return View(await productQuery.AsNoTracking().ToListAsync());
        }

        // GET: PRODUCTS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRODUCTS = await _context.PRODUCTS.FindAsync(id);
            if (pRODUCTS == null)
            {
                return NotFound();
            }
            return View(pRODUCTS);
        }

        // POST: PRODUCTS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_ID,product_category,product_price,product_brand,product_model,product_details,product_warranty,product_usage,product_condition,UserId,image_name,post_date,user_location,ImageFile")] PRODUCTS pRODUCTS)
        {
            if (id != pRODUCTS.Product_ID)
            {
                return NotFound();
            }

            try
            {
                if (pRODUCTS.ImageFile != null)
                {
                    var productToDelete = _context.PRODUCTS.AsNoTracking().FirstOrDefault(m => m.Product_ID == pRODUCTS.Product_ID);
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", productToDelete.image_name);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    string wwwrootPath = _hostEnvironment.WebRootPath;
                    string FileName = Path.GetFileNameWithoutExtension(pRODUCTS.ImageFile.FileName);
                    string extension = Path.GetExtension(pRODUCTS.ImageFile.FileName);
                    pRODUCTS.image_name = FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwrootPath + "/Image/" + FileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await pRODUCTS.ImageFile.CopyToAsync(fileStream);
                    }
                }

                _context.Update(pRODUCTS);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTSExists(pRODUCTS.Product_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Welcome", "Home");

        }

        // GET: PRODUCTS/Delete/5

        // POST: PRODUCTS/Delete/5

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.PRODUCTS.FindAsync(id);


            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", product.image_name);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }


            _context.PRODUCTS.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PRODUCTSExists(int id)
        {
            return _context.PRODUCTS.Any(e => e.Product_ID == id);
        }
    }
}
