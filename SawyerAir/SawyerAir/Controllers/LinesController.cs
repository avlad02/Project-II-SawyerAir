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
    public class LinesController : Controller
    {
        private readonly FlightsContext _context;

        public LinesController(FlightsContext context)
        {
            _context = context;
        }

        // GET: Lines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lines.ToListAsync());
        }

        // GET: Lines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // GET: Lines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineId,Name")] Line line)
        {
            if (ModelState.IsValid)
            {
                line.LineId = Guid.NewGuid();
                _context.Add(line);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(line);
        }

        // GET: Lines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }
            return View(line);
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("LineId,Name")] Line line)
        {
            if (id != line.LineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(line);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineExists(line.LineId))
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
            return View(line);
        }

        // GET: Lines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var line = await _context.Lines.FindAsync(id);
            _context.Lines.Remove(line);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineExists(Guid id)
        {
            return _context.Lines.Any(e => e.LineId == id);
        }
    }
}
