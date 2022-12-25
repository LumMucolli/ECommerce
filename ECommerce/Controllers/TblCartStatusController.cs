using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce;
using ECommerce.Database;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class TblCartStatusController : Controller
    {
        private readonly EcommerceContext _context;

        public TblCartStatusController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: TblCartStatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblCartStatuses.ToListAsync());
        }

        // GET: TblCartStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblCartStatuses == null)
            {
                return NotFound();
            }

            var tblCartStatus = await _context.TblCartStatuses
                .FirstOrDefaultAsync(m => m.CartStatusId == id);
            if (tblCartStatus == null)
            {
                return NotFound();
            }

            return View(tblCartStatus);
        }

        // GET: TblCartStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblCartStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartStatusId,CartStatus")] TblCartStatus tblCartStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCartStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCartStatus);
        }

        // GET: TblCartStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblCartStatuses == null)
            {
                return NotFound();
            }

            var tblCartStatus = await _context.TblCartStatuses.FindAsync(id);
            if (tblCartStatus == null)
            {
                return NotFound();
            }
            return View(tblCartStatus);
        }

        // POST: TblCartStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartStatusId,CartStatus")] TblCartStatus tblCartStatus)
        {
            if (id != tblCartStatus.CartStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCartStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCartStatusExists(tblCartStatus.CartStatusId))
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
            return View(tblCartStatus);
        }

        // GET: TblCartStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblCartStatuses == null)
            {
                return NotFound();
            }

            var tblCartStatus = await _context.TblCartStatuses
                .FirstOrDefaultAsync(m => m.CartStatusId == id);
            if (tblCartStatus == null)
            {
                return NotFound();
            }

            return View(tblCartStatus);
        }

        // POST: TblCartStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblCartStatuses == null)
            {
                return Problem("Entity set 'ECommerceContext.TblCartStatus'  is null.");
            }
            var tblCartStatus = await _context.TblCartStatuses.FindAsync(id);
            if (tblCartStatus != null)
            {
                _context.TblCartStatuses.Remove(tblCartStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCartStatusExists(int id)
        {
          return _context.TblCartStatuses.Any(e => e.CartStatusId == id);
        }
    }
}
