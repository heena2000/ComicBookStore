using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicBookStore.Data;
using ComicBookStore.Models;

namespace ComicBookStore.Controllers
{
    public class ComicOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComicOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComicOrders
        public async Task<IActionResult> Index()
        {
            var orders = _context.ComicOrders;
            if (orders.Count() > 0)
            {
                foreach (ComicOrder order in orders)
                {
                    order.ComicInfo = _context.ComicInfos
                        .FirstOrDefault(m => m.ComicID == order.ComicID);
                }
            }
            return View(await orders.ToListAsync());
        }

        
        // GET: ComicOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicOrder = await _context.ComicOrders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (comicOrder == null)
            {
                return NotFound();
            }
            else
            {
                comicOrder.ComicInfo = _context.ComicInfos
                        .FirstOrDefault(m => m.ComicID == comicOrder.ComicID);
            }
            return View(comicOrder);
        }

        // POST: ComicOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comicOrder = await _context.ComicOrders.FindAsync(id);
            _context.ComicOrders.Remove(comicOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicOrderExists(int id)
        {
            return _context.ComicOrders.Any(e => e.OrderID == id);
        }
    }
}
