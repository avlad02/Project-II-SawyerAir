using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SawyerAir.Models;

namespace SawyerAir.Controllers
{
    public class Route_StopController : Controller
    {
        private readonly FlightsContext _context;

        public Route_StopController(FlightsContext context)
        {
            _context = context;
        }

        // GET: Route_Stop
        public async Task<IActionResult> Index()
        {
            var flightsContext = _context.Route_Stops.Include(r => r.Route).Include(r => r.Stop);
            return View(await flightsContext.ToListAsync());
        }

        // GET: Route_Stop/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route_Stop = await _context.Route_Stops
                .Include(r => r.Route)
                .Include(r => r.Stop)
                .FirstOrDefaultAsync(m => m.Route_StopId == id);
            if (route_Stop == null)
            {
                return NotFound();
            }

            return View(route_Stop);
        }

        // GET: Route_Stop/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId");
            ViewData["StopId"] = new SelectList(_context.Stops, "StopId", "StopId");
            return View();
        }

        // POST: Route_Stop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Route_StopId,StopId,RouteId,StopTime")] Route_Stop route_Stop)
        {
            if (ModelState.IsValid)
            {
                route_Stop.Route_StopId = Guid.NewGuid();
                _context.Add(route_Stop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", route_Stop.RouteId);
            ViewData["StopId"] = new SelectList(_context.Stops, "StopId", "StopId", route_Stop.StopId);
            return View(route_Stop);
        }

        // GET: Route_Stop/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route_Stop = await _context.Route_Stops.FindAsync(id);
            if (route_Stop == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", route_Stop.RouteId);
            ViewData["StopId"] = new SelectList(_context.Stops, "StopId", "StopId", route_Stop.StopId);
            return View(route_Stop);
        }

        // POST: Route_Stop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Route_StopId,StopId,RouteId,StopTime")] Route_Stop route_Stop)
        {
            if (id != route_Stop.Route_StopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route_Stop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Route_StopExists(route_Stop.Route_StopId))
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
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", route_Stop.RouteId);
            ViewData["StopId"] = new SelectList(_context.Stops, "StopId", "StopId", route_Stop.StopId);
            return View(route_Stop);
        }

        // GET: Route_Stop/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route_Stop = await _context.Route_Stops
                .Include(r => r.Route)
                .Include(r => r.Stop)
                .FirstOrDefaultAsync(m => m.Route_StopId == id);
            if (route_Stop == null)
            {
                return NotFound();
            }

            return View(route_Stop);
        }

        // POST: Route_Stop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var route_Stop = await _context.Route_Stops.FindAsync(id);
            _context.Route_Stops.Remove(route_Stop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Route_StopExists(Guid id)
        {
            return _context.Route_Stops.Any(e => e.Route_StopId == id);
        }
    }
}
