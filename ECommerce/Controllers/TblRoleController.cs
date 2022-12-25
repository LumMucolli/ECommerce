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
    public class TblRoleController : Controller
    {
        private readonly EcommerceContext _context;

        public TblRoleController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: TblRole
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblRoles.ToListAsync());
        }
        
        // GET: TblRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblRoles == null)
            {
                return NotFound();
            }

            var tblRole = await _context.TblRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tblRole == null)
            {
                return NotFound();
            }

            return View(tblRole);
        }

        // GET: TblRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName")] TblRole tblRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblRole);
        }

        // GET: TblRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblRoles == null)
            {
                return NotFound();
            }

            var tblRole = await _context.TblRoles.FindAsync(id);
            if (tblRole == null)
            {
                return NotFound();
            }
            return View(tblRole);
        }

        // POST: TblRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName")] TblRole tblRole)
        {
            if (id != tblRole.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRoleExists(tblRole.RoleId))
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
            return View(tblRole);
        }

        // GET: TblRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblRoles == null)
            {
                return NotFound();
            }

            var tblRole = await _context.TblRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tblRole == null)
            {
                return NotFound();
            }

            return View(tblRole);
        }

        // POST: TblRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblRoles == null)
            {
                return Problem("Entity set 'ECommerceContext.TblRole'  is null.");
            }
            var tblRole = await _context.TblRoles.FindAsync(id);
            if (tblRole != null)
            {
                _context.TblRoles.Remove(tblRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRoleExists(int id)
        {
          return _context.TblRoles.Any(e => e.RoleId == id);
        }
    }
}
