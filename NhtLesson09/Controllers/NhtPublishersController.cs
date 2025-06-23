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
    public class NhtPublishersController : Controller
    {
        private readonly NhtLesson09Context _context;

        public NhtPublishersController(NhtLesson09Context context)
        {
            _context = context;
        }

        // GET: NhtPublishers
        public async Task<IActionResult>NhtIndex2()
        {
            return View(await _context.Publishers.ToListAsync());
        }

        // GET: NhtPublishers/Details/5
        public async Task<IActionResult>NhtDetails(int? nhtId)
        {
            if (nhtId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == nhtId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: NhtPublishers/Create
        public IActionResult NhtCreate()
        {
            return View();
        }

        // POST: NhtPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtCreate([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NhtIndex2));
            }
            return View(publisher);
        }

        // GET: NhtPublishers/Edit/5
        public async Task<IActionResult> NhtEdit(int? nhtId)
        {
            if (nhtId    == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(nhtId);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: NhtPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtEdit(int nhtId, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (nhtId != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NhtIndex2));
            }
            return View(publisher);
        }

        // GET: NhtPublishers/Delete/5
        public async Task<IActionResult> NhtDelete(int? nhtId)
        {
            if (nhtId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == nhtId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: NhtPublishers/Delete/5
        [HttpPost, ActionName("NhtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int nhtId)
        {
            var publisher = await _context.Publishers.FindAsync(nhtId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NhtIndex2));
        }

        private bool PublisherExists(int nhtId)
        {
            return _context.Publishers.Any(e => e.PublisherId == nhtId);
        }
    }
}
