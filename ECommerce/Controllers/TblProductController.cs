using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Database;

namespace ECommerce.Controllers
{
    public class TblProductController : Controller
    {
        private readonly ECommerceContext _context;

        public TblProductController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: TblProduct
        public async Task<IActionResult> Index()
        {
            var eCommerceContext = _context.TblProduct.Include(t => t.Category);
            return View(await eCommerceContext.ToListAsync());
        }

        // GET: TblProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProduct == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: TblProduct/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<TblCategory>(), "CategoryId", "CategoryId");
            return View();
        }

        // POST: TblProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,ProductImage,IsFeatured,Quantity")] TblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<TblCategory>(), "CategoryId", "CategoryId", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // GET: TblProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblProduct == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<TblCategory>(), "CategoryId", "CategoryId", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // POST: TblProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,ProductImage,IsFeatured,Quantity")] TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<TblCategory>(), "CategoryId", "CategoryId", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // GET: TblProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblProduct == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: TblProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblProduct == null)
            {
                return Problem("Entity set 'ECommerceContext.TblProduct'  is null.");
            }
            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct != null)
            {
                _context.TblProduct.Remove(tblProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
          return _context.TblProduct.Any(e => e.ProductId == id);
        }
    }
}
