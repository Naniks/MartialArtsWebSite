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
    [Authorize]
    public class FightersController : Controller {
        private readonly FighterContext _context;

        public FightersController(FighterContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult SeedDatabase() {
            SeedData.EnsurePopulated(HttpContext.RequestServices);
            return RedirectToAction(nameof(Index));
        }

        // GET: Fighters

        public async Task<IActionResult> Index() {
            return View(await _context.Fighters.ToListAsync());
        }

        // GET: Fighters/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var fighter = await _context.Fighters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (fighter == null) {
                return NotFound();
            }

            return View(fighter);
        }

        // GET: Fighters/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Fighters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Nickname,From,FightsOutOf,Age,Height,Weight,HeightCm,WeightKg,Reach,LegReach,Record,Summary,ImageInList,ImageMainProfile")] Fighter fighter) {
            if (ModelState.IsValid) {
                _context.Add(fighter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fighter);
        }

        
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var fighter = await _context.Fighters.SingleOrDefaultAsync(m => m.ID == id);
            if (fighter == null) {
                return NotFound();
            }
            return View(fighter);
        }

        // POST: Fighters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Nickname,From,FightsOutOf,Age,Height,Weight,HeightCm,WeightKg,Reach,LegReach,Record,Summary,ImageInList,ImageMainProfile")] Fighter fighter) {
            if (id != fighter.ID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(fighter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!FighterExists(fighter.ID)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fighter);
        }

        // GET: Fighters/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var fighter = await _context.Fighters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (fighter == null) {
                return NotFound();
            }

            return View(fighter);
        }

        // POST: Fighters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var fighter = await _context.Fighters.SingleOrDefaultAsync(m => m.ID == id);
            _context.Fighters.Remove(fighter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FighterExists(int id) {
            return _context.Fighters.Any(e => e.ID == id);
        }
    }
}
