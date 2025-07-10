using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nht_2310900105_De01.Models;

namespace Nht_2310900105_De01.Controllers
{
    public class NhtComputersController : Controller
    {
        private readonly NguyenHuuTuyen2310900105De01Context _context;

        public NhtComputersController(NguyenHuuTuyen2310900105De01Context context)
        {
            _context = context;
        }

        // GET: NhtComputers
        public async Task<IActionResult> NhtIndex1()
        {
            var nguyenHuuTuyen2310900105De01Context = _context.NhtComputers.Include(n => n.NhtCate);
            return View(await nguyenHuuTuyen2310900105De01Context.ToListAsync());
        }

        // GET: NhtComputers/Details/5
        public async Task<IActionResult> NhtDetails(int? id)
        {
            if (id == null) return NotFound();

            var nhtComputer = await _context.NhtComputers
                .Include(n => n.NhtCate)
                .FirstOrDefaultAsync(m => m.NhtComId == id);
            if (nhtComputer == null) return NotFound();

            return View(nhtComputer);
        }

        // GET: NhtComputers/Create
        public IActionResult NhtCreate()
        {
            ViewData["NhtCateId"] = new SelectList(_context.NhtCategories, "NhtCateId", "NhtCateId");
            return View();
        }

        // POST: NhtComputers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtCreate([Bind("NhtComId,NhtComName,NhtComPrice,NhtComStatus,NhtComImage,NhtCateId")] NhtComputer nhtComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhtComputer);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm máy tính thành công!";
                return RedirectToAction(nameof(NhtIndex1));
            }
            ViewData["NhtCateId"] = new SelectList(_context.NhtCategories, "NhtCateId", "NhtCateId", nhtComputer.NhtCateId);
            return View(nhtComputer);
        }

        // GET: NhtComputers/Edit/5
        public async Task<IActionResult> NhtEdit(int? id)
        {
            if (id == null) return NotFound();

            var nhtComputer = await _context.NhtComputers.FindAsync(id);
            if (nhtComputer == null) return NotFound();

            ViewData["NhtCateId"] = new SelectList(_context.NhtCategories, "NhtCateId", "NhtCateId", nhtComputer.NhtCateId);
            return View(nhtComputer);
        }

        // POST: NhtComputers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtEdit(int id, [Bind("NhtComId,NhtComName,NhtComPrice,NhtComStatus,NhtComImage,NhtCateId")] NhtComputer nhtComputer)
        {
            if (id != nhtComputer.NhtComId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhtComputer);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật máy tính thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhtComputerExists(nhtComputer.NhtComId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(NhtIndex1));
            }
            ViewData["NhtCateId"] = new SelectList(_context.NhtCategories, "NhtCateId", "NhtCateId", nhtComputer.NhtCateId);
            return View(nhtComputer);
        }

        // GET: NhtComputers/Delete/5
        public async Task<IActionResult> NhtDelete(int? id)
        {
            if (id == null) return NotFound();

            var nhtComputer = await _context.NhtComputers
                .Include(n => n.NhtCate)
                .FirstOrDefaultAsync(m => m.NhtComId == id);
            if (nhtComputer == null) return NotFound();

            return View(nhtComputer);
        }

        // POST: NhtComputers/Delete/5
        [HttpPost, ActionName("NhtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhtComputer = await _context.NhtComputers.FindAsync(id);
            if (nhtComputer != null)
            {
                _context.NhtComputers.Remove(nhtComputer);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa máy tính thành công!";
            }

            return RedirectToAction(nameof(NhtIndex1));
        }

        private bool NhtComputerExists(int id)
        {
            return _context.NhtComputers.Any(e => e.NhtComId == id);
        }
    }
}
