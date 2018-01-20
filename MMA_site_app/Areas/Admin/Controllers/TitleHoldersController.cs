using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMA_site_app.Data;
using MMA_site_app.Models;
using Microsoft.AspNetCore.Authorization;

namespace MMA_site_app.Areas.Admin.Controllers {

    [Area("Admin")]
    //[Authorize]
    public class TitleHoldersController : Controller {
        private readonly FighterContext _context;

        public TitleHoldersController(FighterContext context) {
            _context = context;
        }

        // GET: TitleHolders
        public async Task<IActionResult> Index() {
            return View(await _context.TitleHolders.ToListAsync());
        }

        // GET: TitleHolders/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var titleHolder = await _context.TitleHolders
                .SingleOrDefaultAsync(m => m.TitleHolderID == id);
            if (titleHolder == null) {
                return NotFound();
            }

            return View(titleHolder);
        }

        // GET: TitleHolders/Create
        public IActionResult Create() {
            return View();
        }

        // POST: TitleHolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleHolderID,FirstName,LastName,Record,WeightCategory,Order,ProfileLink,ImageTitle")] TitleHolder titleHolder) {
            if (ModelState.IsValid) {
                _context.Add(titleHolder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titleHolder);
        }

        // GET: TitleHolders/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var titleHolder = await _context.TitleHolders.SingleOrDefaultAsync(m => m.TitleHolderID == id);
            if (titleHolder == null) {
                return NotFound();
            }
            return View(titleHolder);
        }

        // POST: TitleHolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TitleHolderID,FirstName,LastName,Record,WeightCategory,Order,ProfileLink,ImageTitle")] TitleHolder titleHolder) {
            if (id != titleHolder.TitleHolderID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(titleHolder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TitleHolderExists(titleHolder.TitleHolderID)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(titleHolder);
        }

        // GET: TitleHolders/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var titleHolder = await _context.TitleHolders
                .SingleOrDefaultAsync(m => m.TitleHolderID == id);
            if (titleHolder == null) {
                return NotFound();
            }

            return View(titleHolder);
        }

        // POST: TitleHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var titleHolder = await _context.TitleHolders.SingleOrDefaultAsync(m => m.TitleHolderID == id);
            _context.TitleHolders.Remove(titleHolder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleHolderExists(int id) {
            return _context.TitleHolders.Any(e => e.TitleHolderID == id);
        }
    }
}
