using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Database;

namespace ECommerce.Controllers
{
    public class TblCartController : Controller
    {
        private readonly EcommerceContext _context;

        public TblCartController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: TblCart
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.TblCarts.Include(t => t.Product);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: TblCart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblCarts == null)
            {
                return NotFound();
            }

            var tblCart = await _context.TblCarts
                .Include(t => t.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (tblCart == null)
            {
                return NotFound();
            }

            return View(tblCart);
        }

        // GET: TblCart/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId");
            return View();
        }

        // POST: TblCart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,ProductId,MemberId,CartStatusId")] TblCart tblCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId", tblCart.ProductId);
            return View(tblCart);
        }

        // GET: TblCart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblCarts == null)
            {
                return NotFound();
            }

            var tblCart = await _context.TblCarts.FindAsync(id);
            if (tblCart == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId", tblCart.ProductId);
            return View(tblCart);
        }

        // POST: TblCart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,ProductId,MemberId,CartStatusId")] TblCart tblCart)
        {
            if (id != tblCart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCartExists(tblCart.CartId))
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
            ViewData["ProductId"] = new SelectList(_context.TblProducts, "ProductId", "ProductId", tblCart.ProductId);
            return View(tblCart);
        }

        // GET: TblCart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblCarts == null)
            {
                return NotFound();
            }

            var tblCart = await _context.TblCarts
                .Include(t => t.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (tblCart == null)
            {
                return NotFound();
            }

            return View(tblCart);
        }

        // POST: TblCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblCarts == null)
            {
                return Problem("Entity set 'EcommerceContext.TblCarts'  is null.");
            }
            var tblCart = await _context.TblCarts.FindAsync(id);
            if (tblCart != null)
            {
                _context.TblCarts.Remove(tblCart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCartExists(int id)
        {
          return _context.TblCarts.Any(e => e.CartId == id);
        }
    }
}
