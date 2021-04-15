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
    public class ComicCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComicCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComicCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComicCategories.ToListAsync());
        }

        // GET: ComicCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicCategory = await _context.ComicCategories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (comicCategory == null)
            {
                return NotFound();
            }

            return View(comicCategory);
        }

        // GET: ComicCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComicCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName")] ComicCategory comicCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comicCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comicCategory);
        }

        // GET: ComicCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicCategory = await _context.ComicCategories.FindAsync(id);
            if (comicCategory == null)
            {
                return NotFound();
            }
            return View(comicCategory);
        }

        // POST: ComicCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName")] ComicCategory comicCategory)
        {
            if (id != comicCategory.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comicCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicCategoryExists(comicCategory.CategoryID))
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
            return View(comicCategory);
        }

        // GET: ComicCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicCategory = await _context.ComicCategories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (comicCategory == null)
            {
                return NotFound();
            }

            return View(comicCategory);
        }

        // POST: ComicCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comicCategory = await _context.ComicCategories.FindAsync(id);
            _context.ComicCategories.Remove(comicCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicCategoryExists(int id)
        {
            return _context.ComicCategories.Any(e => e.CategoryID == id);
        }
    }
}
