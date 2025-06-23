    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using NhtLesson09.Models;

    namespace NhtLesson09.Controllers
    {
        public class NhtCategoriesController : Controller
        {
            private readonly NhtLesson09Context _context;

            public NhtCategoriesController(NhtLesson09Context context)
            {
                _context = context;
            }

            // GET: NhtCategories
            public async Task<IActionResult> NhtIndex1( string keyword)
            {
            var nhtCategories = await _context.Categories.ToListAsync();
            if(!string .IsNullOrEmpty (keyword))
            {
                nhtCategories = nhtCategories.Where(x => x.CategoryName.Contains(keyword)).ToList();

            }
            return View(nhtCategories);
            }

            // GET: NhtCategories/Details/5
            public async Task<IActionResult> NhtDetails(int? nhtId)
            {
                if (nhtId == null)
                {
                    return NotFound();
                }

                var category = await _context.Categories
                    .FirstOrDefaultAsync(m => m.CategoryId == nhtId);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }

            // GET: NhtCategories/Create
            public IActionResult NhtCreate()
            {
            var nhtCategory = new Category ();
                return View(nhtCategory);
            }

            // POST: NhtCategories/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> NhtCreate([Bind("CategoryId,CategoryName")] Category category)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(NhtIndex1));
                }
                return View(category);
            }

            // GET: NhtCategories/Edit/5
            public async Task<IActionResult> NhtEdit(int? nhtId)
            {
                if (nhtId == null)
                {
                    return NotFound();
                }

                var category = await _context.Categories.FindAsync(nhtId);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }

            // POST: NhtCategories/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> NhtEdit(int nhtId, [Bind("CategoryId,CategoryName")] Category category)
            {
                if (nhtId != category.CategoryId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.CategoryId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(NhtIndex1));
                }
                return View(category);
            }

            // GET: NhtCategories/Delete/5
            public async Task<IActionResult> NhtDelete(int? nhtId)
            {
                if (nhtId == null)
                {
                    return NotFound();
                }

                var category = await _context.Categories
                    .FirstOrDefaultAsync(m => m.CategoryId == nhtId);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }

            // POST: NhtCategories/Delete/5
            [HttpPost, ActionName("NhtDelete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int nhtId)
            {
                var category = await _context.Categories.FindAsync(nhtId);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NhtIndex1));
            }

            private bool CategoryExists(int nhtId)
            {
                return _context.Categories.Any(e => e.CategoryId == nhtId);
            }
        }
    }
