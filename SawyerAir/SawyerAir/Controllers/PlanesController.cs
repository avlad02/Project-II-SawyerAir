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
    public class PlanesController : Controller
    {
        private readonly FlightsContext _context;

        public PlanesController(FlightsContext context)
        {
            _context = context;
        }

        // GET: Planes
        public async Task<IActionResult> Index()
        {
            var flightsContext = _context.Planes.Include(p => p.Line);
            return View(await flightsContext.ToListAsync());
        }

        // GET: Planes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _context.Planes
                .Include(p => p.Line)
                .FirstOrDefaultAsync(m => m.PlaneId == id);
            if (plane == null)
            {
                return NotFound();
            }

            return View(plane);
        }

        // GET: Planes/Create
        public IActionResult Create()
        {
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId");
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneId,Model,Manufacturer,LineId")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                plane.PlaneId = Guid.NewGuid();
                _context.Add(plane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId", plane.LineId);
            return View(plane);
        }

        // GET: Planes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _context.Planes.FindAsync(id);
            if (plane == null)
            {
                return NotFound();
            }
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId", plane.LineId);
            return View(plane);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PlaneId,Model,Manufacturer,LineId")] Plane plane)
        {
            if (id != plane.PlaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaneExists(plane.PlaneId))
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
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId", plane.LineId);
            return View(plane);
        }

        // GET: Planes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _context.Planes
                .Include(p => p.Line)
                .FirstOrDefaultAsync(m => m.PlaneId == id);
            if (plane == null)
            {
                return NotFound();
            }

            return View(plane);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var plane = await _context.Planes.FindAsync(id);
            _context.Planes.Remove(plane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneExists(Guid id)
        {
            return _context.Planes.Any(e => e.PlaneId == id);
        }
    }
}
