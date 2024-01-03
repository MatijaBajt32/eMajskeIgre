using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    [Authorize(Roles ="Administrator, Maneger")]
    public class DormitoriesController : Controller
    {
        private readonly EMIContext _context;

        public DormitoriesController(EMIContext context)
        {
            _context = context;
        }

        // GET: Dormitories
        public async Task<IActionResult> Index()
        {
              return _context.Dormitories != null ? 
                          View(await _context.Dormitories.ToListAsync()) :
                          Problem("Entity set 'EMIContext.Dormitories'  is null.");
        }

        // GET: Dormitories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dormitories == null)
            {
                return NotFound();
            }

            var dormitory = await _context.Dormitories
                .FirstOrDefaultAsync(m => m.DormitoryID == id);
            if (dormitory == null)
            {
                return NotFound();
            }

            return View(dormitory);
        }

        // GET: Dormitories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dormitories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DormitoryID,DormitoryTitle,JanitorPhoneNumber")] Dormitory dormitory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dormitory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dormitory);
        }

        // GET: Dormitories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dormitories == null)
            {
                return NotFound();
            }

            var dormitory = await _context.Dormitories.FindAsync(id);
            if (dormitory == null)
            {
                return NotFound();
            }
            return View(dormitory);
        }

        // POST: Dormitories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DormitoryID,DormitoryTitle,JanitorPhoneNumber")] Dormitory dormitory)
        {
            if (id != dormitory.DormitoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dormitory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DormitoryExists(dormitory.DormitoryID))
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
            return View(dormitory);
        }

        // GET: Dormitories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dormitories == null)
            {
                return NotFound();
            }

            var dormitory = await _context.Dormitories
                .FirstOrDefaultAsync(m => m.DormitoryID == id);
            if (dormitory == null)
            {
                return NotFound();
            }

            return View(dormitory);
        }

        // POST: Dormitories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dormitories == null)
            {
                return Problem("Entity set 'EMIContext.Dormitories'  is null.");
            }
            var dormitory = await _context.Dormitories.FindAsync(id);
            if (dormitory != null)
            {
                _context.Dormitories.Remove(dormitory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DormitoryExists(int id)
        {
          return (_context.Dormitories?.Any(e => e.DormitoryID == id)).GetValueOrDefault();
        }
    }
}
