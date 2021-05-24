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
    public class FlightsController : Controller
    {
        private readonly FlightsContext _context;

        public FlightsController(FlightsContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var flightsContext = _context.Flights.Include(f => f.Plane).Include(f => f.Route);
            return View(await flightsContext.ToListAsync());
        }

        public async Task<IActionResult> IndexRouteId(Guid routeId)
        {
            var flightsContext = _context.Flights.Include(f => f.Plane).Include(f => f.Route).Where(f => f.RouteId == routeId);
            return View(await flightsContext.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Plane)
                .Include(f => f.Route)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId");
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,PlaneId,RouteId,DepartureDate,DepartureHour,DestinationHour")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                flight.FlightId = Guid.NewGuid();
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId", flight.PlaneId);
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", flight.RouteId);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId", flight.PlaneId);
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", flight.RouteId);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FlightId,PlaneId,RouteId,DepartureDate,DepartureHour,DestinationHour")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
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
            ViewData["PlaneId"] = new SelectList(_context.Planes, "PlaneId", "PlaneId", flight.PlaneId);
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", flight.RouteId);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Plane)
                .Include(f => f.Route)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var flight = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(Guid id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }
    }
}
