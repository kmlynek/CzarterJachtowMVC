using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Flota;

namespace Firma.Intranet.Controllers
{
    public class PortController : Controller
    {
        private readonly FirmaContext _context;

        public PortController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Port
        public async Task<IActionResult> Index()
        {
            return View(await _context.Porty.ToListAsync());
        }

        // GET: Port/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Porty
                .FirstOrDefaultAsync(m => m.IdPortu == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }

        // GET: Port/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Port/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPortu,Nazwa,Lokalizacja")] Port port)
        {
            if (ModelState.IsValid)
            {
                _context.Add(port);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(port);
        }

        // GET: Port/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Porty.FindAsync(id);
            if (port == null)
            {
                return NotFound();
            }
            return View(port);
        }

        // POST: Port/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPortu,Nazwa,Lokalizacja")] Port port)
        {
            if (id != port.IdPortu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(port);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortExists(port.IdPortu))
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
            return View(port);
        }

        // GET: Port/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Porty
                .FirstOrDefaultAsync(m => m.IdPortu == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }

        // POST: Port/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var port = await _context.Porty.FindAsync(id);
            if (port != null)
            {
                _context.Porty.Remove(port);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortExists(int id)
        {
            return _context.Porty.Any(e => e.IdPortu == id);
        }
    }
}
