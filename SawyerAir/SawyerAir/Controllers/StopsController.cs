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
    public class StopsController : Controller
    {
        private readonly FlightsContext _context;

        public StopsController(FlightsContext context)
        {
            _context = context;
        }

        // GET: Stops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stops.ToListAsync());
        }

        public IActionResult IndexRouteId(Guid routeId)
        {
            var routeStop = _context.Route_Stops.Where(s => s.RouteId == routeId);
            
            List<Guid> stopList = new List<Guid>();
            foreach (var id in routeStop)
            {
                stopList.Add(id.StopId);
            }
           List<Stop> stopsEnum = new List<Stop>();

            foreach(var id in stopList)
            {
                stopsEnum.Add(_context.Stops.Find(id));
            }

            return View(stopsEnum.AsEnumerable());
        }

        // GET: Stops/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stop = await _context.Stops
                .FirstOrDefaultAsync(m => m.StopId == id);
            if (stop == null)
            {
                return NotFound();
            }

            return View(stop);
        }

        // GET: Stops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StopId,StopLocation")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                stop.StopId = Guid.NewGuid();
                _context.Add(stop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stop);
        }

        // GET: Stops/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stop = await _context.Stops.FindAsync(id);
            if (stop == null)
            {
                return NotFound();
            }
            return View(stop);
        }

        // POST: Stops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StopId,StopLocation")] Stop stop)
        {
            if (id != stop.StopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StopExists(stop.StopId))
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
            return View(stop);
        }

        // GET: Stops/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stop = await _context.Stops
                .FirstOrDefaultAsync(m => m.StopId == id);
            if (stop == null)
            {
                return NotFound();
            }

            return View(stop);
        }

        // POST: Stops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var stop = await _context.Stops.FindAsync(id);
            _context.Stops.Remove(stop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StopExists(Guid id)
        {
            return _context.Stops.Any(e => e.StopId == id);
        }
    }
}
