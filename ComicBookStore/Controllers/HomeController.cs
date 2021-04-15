using ComicBookStore.Data;
using ComicBookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ComicCompanies.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> AllCategories()
        {
            return View(await _context.ComicCategories.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewComicByCompany(int? id)
        {
            var applicationDbContext = _context.ComicInfos
                .Include(j => j.CompanyComic)
            .Include(j => j.CategoryComic).Where(m => m.CompanyID == id);
            return View(await applicationDbContext.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewComicByCategory(int? id)
        {
            var applicationDbContext = _context.ComicInfos
                .Include(j => j.CompanyComic)
            .Include(j => j.CategoryComic).Where(m => m.CategoryID == id);
            return View(await applicationDbContext.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> AllComics()
        {
            var applicationDbContext = _context.ComicInfos
                .Include(j => j.CompanyComic)
            .Include(j => j.CategoryComic);
            return View(await applicationDbContext.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }

        public async Task<IActionResult> ViewComicDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicInfo = await _context.ComicInfos
                .Include(j => j.CompanyComic)
                .Include(j => j.CategoryComic)
                .FirstOrDefaultAsync(m => m.ComicID == id);
            if (comicInfo == null)
            {
                return NotFound();
            }

            return View(comicInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult PlaceOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comicInfo = _context.ComicInfos
                .FirstOrDefault(m => m.ComicID == id);
            if (comicInfo == null)
            {
                return NotFound();
            }

            ViewData["ComicID"] = comicInfo.ComicID;
            ViewData["ComicName"] = comicInfo.ComicName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder([Bind("OrderID,Address,Quantity,ComicID")] ComicOrder comicOrder)
        {
            ModelState.Remove("Price");
            ModelState.Remove("Total");
            ModelState.Remove("UserID");
            ModelState.Remove("OrderDate");
            if (ModelState.IsValid)
            {
                comicOrder.UserID = _userManager.GetUserName(this.User);
                comicOrder.OrderDate = DateTime.Now;
                var comicInfo = await _context.ComicInfos.FirstOrDefaultAsync(m => m.ComicID == comicOrder.ComicID);
                if(comicInfo!=null)
                {
                    comicOrder.Price = comicInfo.Price;
                    comicOrder.Total = comicOrder.Price * comicOrder.Quantity;
                }
                _context.Add(comicOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PlaceOrderSuccess));
            }
            return RedirectToAction(nameof(PlaceOrderFailure));
        }

        public IActionResult PlaceOrderSuccess()
        {
            return View();
        }

        public IActionResult PlaceOrderFailure()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            string userid = _userManager.GetUserName(this.User); 
            var orders = _context.ComicOrders
                .Where(m => m.UserID == userid);
            if(orders.Count() > 0)
            {
                foreach(ComicOrder order in orders)
                {
                    order.ComicInfo = _context.ComicInfos
                        .FirstOrDefault(m => m.ComicID == order.ComicID);
                }
            }
            return View(await orders.ToListAsync());
        }
    }
}
