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
    public class ComicCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComicCompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComicCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComicCompanies.ToListAsync());
        }

        // GET: ComicCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicCompany = await _context.ComicCompanies
                .FirstOrDefaultAsync(m => m.CompanyID == id);
            if (comicCompany == null)
            {
                return NotFound();
            }

            return View(comicCompany);
        }

        // GET: ComicCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComicCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyID,CompanyName")] ComicCompany comicCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comicCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comicCompany);
        }

        // GET: ComicCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicCompany = await _context.ComicCompanies.FindAsync(id);
            if (comicCompany == null)
            {
                return NotFound();
            }
            return View(comicCompany);
        }

        // POST: ComicCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyID,CompanyName")] ComicCompany comicCompany)
        {
            if (id != comicCompany.CompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comicCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicCompanyExists(comicCompany.CompanyID))
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
            return View(comicCompany);
        }

        // GET: ComicCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicCompany = await _context.ComicCompanies
                .FirstOrDefaultAsync(m => m.CompanyID == id);
            if (comicCompany == null)
            {
                return NotFound();
            }

            return View(comicCompany);
        }

        // POST: ComicCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comicCompany = await _context.ComicCompanies.FindAsync(id);
            _context.ComicCompanies.Remove(comicCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicCompanyExists(int id)
        {
            return _context.ComicCompanies.Any(e => e.CompanyID == id);
        }
    }
}
