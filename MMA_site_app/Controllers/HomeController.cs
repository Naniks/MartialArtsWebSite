using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMA_site_app.Data;
using MMA_site_app.Models;
using MMA_site_app.Models.ViewModels;
using System.Linq;
using System;

namespace MMA_site_app.Controllers {
    public class HomeController : Controller {

        private readonly FighterContext _context;

        public HomeController(FighterContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            var titleHolders = await _context.TitleHolders.
                AsNoTracking()
                .OrderBy(h => h.Order)
                .ToListAsync();
            return View(titleHolders);
        }

        //public ViewResult FighterProfile() {
        //    return View();
        //}

        public async Task<IActionResult> AllFighters(string sortOrder, string searchString, string divisionCategory) {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewData["RecordSortParm"] = sortOrder == "Record" ? "Record_desc" : "Record";
            ViewData["HeightSortParm"] = sortOrder == "Height" ? "Height_desc" : "Height";
            ViewData["WeightSortParm"] = sortOrder == "Weight" ? "Weight_desc" : "Weight";

            ViewData["CurrentSearchFilter"] = searchString;

            ViewData["CurrentDivisionFilter"] = divisionCategory;

            var fighters = from f in _context.Fighters
                           select f;

            if (!String.IsNullOrEmpty(divisionCategory)) {
                fighters = fighters.Where(f => f.Weight == divisionCategory);
            }

            if (!String.IsNullOrEmpty(searchString)) {
                fighters = fighters.Where(f => f.LastName.Contains(searchString)
                                       || f.FirstName.Contains(searchString));
            }

            switch (sortOrder) {
                case "Name_desc":
                    fighters = fighters.OrderByDescending(f => f.FirstName);
                    break;
                case "Record":
                    fighters = fighters.OrderBy(f => f.Record);
                    break;
                case "Record_desc":
                    fighters = fighters.OrderByDescending(f => f.Record);
                    break;
                case "Height":
                    fighters = fighters.OrderBy(f => f.HeightCm);
                    break;
                case "Height_desc":
                    fighters = fighters.OrderByDescending(f => f.HeightCm);
                    break;
                case "Weight":
                    fighters = fighters.OrderBy(f => f.Weight);
                    break;
                case "Weight_desc":
                    fighters = fighters.OrderByDescending(f => f.Weight);
                    break;
                default:
                    fighters = fighters.OrderBy(s => s.LastName);
                    break;
            }

            return View(await fighters.AsNoTracking().ToListAsync());
        }

        [Route("[controller]/AllFighters/{fullName}")]
        public async Task<IActionResult> FighterProfile(string fullName) {
            //if (id == null) {
            //    return NotFound();
            //}

            //var fighter = await _context.Fighters
            //    .Include(f => f.Perfomanses)
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync(f => f.ID == id);

            var fighter = await _context.Fighters
                .Include(f => f.Perfomanses)
                .AsNoTracking()
                .SingleOrDefaultAsync(f => (f.FirstName+f.LastName) == fullName);

            if (fighter == null) {
                return NotFound();
            }

            return View(fighter);
        }

        [Route("[controller]/AllFighters/{fullName}/[action]/{perfomanceId}")]
        public async Task<IActionResult> Video(string fullName, int perfomanceId) {
            //if (perfomanceId == null) {
            //    return NotFound();
            //}

            var fighter = await _context.Fighters
                .AsNoTracking()
                .SingleOrDefaultAsync(f => (f.FirstName + f.LastName) == fullName);

            var perfomance = await _context.Perfomanses
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PerfomanseID == perfomanceId);

            var viewModel = new VideoPerfomance();
            viewModel.Fighter = fighter;
            viewModel.Perfomace = perfomance;

            if (viewModel.Perfomace == null|| viewModel.Fighter == null) {
                return NotFound();
            }

            return View(viewModel);
        }


    }
}
