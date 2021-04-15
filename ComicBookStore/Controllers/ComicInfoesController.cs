using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicBookStore.Data;
using ComicBookStore.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ComicBookStore.Controllers
{
    public class ComicInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ComicInfoesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: ComicInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ComicInfos.Include(c => c.CategoryComic).Include(c => c.CompanyComic);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ComicInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicInfo = await _context.ComicInfos
                .Include(c => c.CategoryComic)
                .Include(c => c.CompanyComic)
                .FirstOrDefaultAsync(m => m.ComicID == id);
            if (comicInfo == null)
            {
                return NotFound();
            }

            return View(comicInfo);
        }

        // GET: ComicInfoes/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.ComicCategories, "CategoryID", "CategoryName");
            ViewData["CompanyID"] = new SelectList(_context.ComicCompanies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: ComicInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComicID,ComicName,Description,Pages,Price,File,CompanyID,CategoryID")] ComicInfo comicInfo)
        {
            using (var memoryStream = new MemoryStream())
            {
                await comicInfo.File.FormFile.CopyToAsync(memoryStream);

                string photoname = comicInfo.File.FormFile.FileName;
                comicInfo.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(comicInfo.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(comicInfo);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "photos");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = comicInfo.ComicID + comicInfo.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await comicInfo.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.ComicCategories, "CategoryID", "CategoryName", comicInfo.CategoryID);
            ViewData["CompanyID"] = new SelectList(_context.ComicCompanies, "CompanyID", "CompanyName", comicInfo.CompanyID);
            return View(comicInfo);
        }

        // GET: ComicInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicInfo = await _context.ComicInfos.FindAsync(id);
            if (comicInfo == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.ComicCategories, "CategoryID", "CategoryName", comicInfo.CategoryID);
            ViewData["CompanyID"] = new SelectList(_context.ComicCompanies, "CompanyID", "CompanyName", comicInfo.CompanyID);
            return View(comicInfo);
        }

        // POST: ComicInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComicID,ComicName,Description,Pages,Price,Extension,CompanyID,CategoryID")] ComicInfo comicInfo)
        {
            if (id != comicInfo.ComicID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comicInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicInfoExists(comicInfo.ComicID))
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
            ViewData["CategoryID"] = new SelectList(_context.ComicCategories, "CategoryID", "CategoryName", comicInfo.CategoryID);
            ViewData["CompanyID"] = new SelectList(_context.ComicCompanies, "CompanyID", "CompanyName", comicInfo.CompanyID);
            return View(comicInfo);
        }

        // GET: ComicInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicInfo = await _context.ComicInfos
                .Include(c => c.CategoryComic)
                .Include(c => c.CompanyComic)
                .FirstOrDefaultAsync(m => m.ComicID == id);
            if (comicInfo == null)
            {
                return NotFound();
            }

            return View(comicInfo);
        }

        // POST: ComicInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comicInfo = await _context.ComicInfos.FindAsync(id);
            _context.ComicInfos.Remove(comicInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicInfoExists(int id)
        {
            return _context.ComicInfos.Any(e => e.ComicID == id);
        }
    }
}
