using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SawyerAir.Models;
using SawyerAir.Data;

namespace SawyerAir.Controllers
{
    public class RoutesController : Controller
    {
        private readonly FlightsContext _context;

        public string RouteDestLoc { get; private set; }

        public IActionResult Routes()
        {
            return View();
        }

        public RoutesController(FlightsContext context)
        {
            _context = context;
        }

        // GET: Routes
        public async Task<IActionResult> Index(string RouteDestLoc, string searchString)
        {
            IQueryable<string> destlocQuery = from m in _context.Routes
                                              orderby m.DestinationLocation
                                              select m.DestinationLocation;

            var routes = from m in _context.Routes
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                routes = routes.Where(s => s.DestinationLocation.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(RouteDestLoc))
            {
                routes = routes.Where(x => x.DestinationLocation == RouteDestLoc);
            }

            var RouteDestLocVM = new RouteDestLocView
            {
                DestinationLocations = new SelectList(await destlocQuery.Distinct().ToListAsync()),
                Routes = await routes.ToListAsync()
            };

            return View(RouteDestLocVM);
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteId,DepartureLocation,DestinationLocation")] Route route)
        {
            if (ModelState.IsValid)
            {
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Flights(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Flights(Guid id, [Bind("RouteId,DepartureLocation,DestinationLocation")] Route route)
        {
            if (id != route.RouteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.RouteId))
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
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(Guid id)
        {
            return _context.Routes.Any(e => e.RouteId == id);
        }
    }
}
