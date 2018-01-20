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
    public class PerfomansesController : Controller {
        private readonly FighterContext _context;

        public PerfomansesController(FighterContext context) {
            _context = context;
        }

        // GET: Perfomanses
        public async Task<IActionResult> Index() {
            return View(await _context.Perfomanses.ToListAsync());
        }

        [Route("[area]/Admin/Fighters/Edit/{id?}/[controller]/[action]")]
        public async Task<IActionResult> IndexById(int? id) {
            var fighter = await _context.Fighters
                .Include(f => f.Perfomanses)
                .AsNoTracking()
                .SingleOrDefaultAsync(f => f.ID == id);

            ViewBag.Title = $"{fighter.LastName} perfomanses";
            ViewBag.HideId = "yes";

            return View("Index", fighter.Perfomanses);
        }

        // GET: Perfomanses/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var perfomanse = await _context.Perfomanses
                .SingleOrDefaultAsync(m => m.PerfomanseID == id);
            if (perfomanse == null) {
                return NotFound();
            }

            return View(perfomanse);
        }

        // GET: Perfomanses/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Perfomanses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnemyName,EnemyLink,Result,Tournament,Date,Method,Round,Time,Video,FighterID")] Perfomanse perfomanse) {
            if (ModelState.IsValid) {
                _context.Add(perfomanse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfomanse);
        }

        // GET: Perfomanses/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var perfomanse = await _context.Perfomanses.SingleOrDefaultAsync(m => m.PerfomanseID == id);
            if (perfomanse == null) {
                return NotFound();
            }
            return View(perfomanse);
        }

        // POST: Perfomanses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerfomanseID,EnemyName,EnemyLink,Result,Tournament,Date,Method,Round,Time,Video,FighterID")] Perfomanse perfomanse) {
            if (id != perfomanse.PerfomanseID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(perfomanse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!PerfomanseExists(perfomanse.PerfomanseID)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(perfomanse);
        }

        // GET: Perfomanses/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var perfomanse = await _context.Perfomanses
                .SingleOrDefaultAsync(m => m.PerfomanseID == id);
            if (perfomanse == null) {
                return NotFound();
            }

            return View(perfomanse);
        }

        // POST: Perfomanses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var perfomanse = await _context.Perfomanses.SingleOrDefaultAsync(m => m.PerfomanseID == id);
            _context.Perfomanses.Remove(perfomanse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfomanseExists(int id) {
            return _context.Perfomanses.Any(e => e.PerfomanseID == id);
        }
    }
}
