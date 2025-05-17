using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Rezerwacje;

namespace Firma.Intranet.Controllers
{
    public class RezerwacjaController : Controller
    {
        private readonly FirmaContext _context;

        public RezerwacjaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Rezerwacja
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rezerwacje.ToListAsync());
        }

        // GET: Rezerwacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .FirstOrDefaultAsync(m => m.IdRezerwacji == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacja/Create
        public IActionResult Create()
        {
            ViewData["IdJachtu"] = new SelectList(_context.Jachty, "IdJachtu", "Nazwa");
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email");

            return View();
        }

        // POST: Rezerwacja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRezerwacji,DataOd,DataDo,IdJachtu,IdKlienta")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJachtu"] = new SelectList(_context.Jachty, "IdJachtu", "Nazwa");
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email");

            return View(rezerwacja);
        }

        // GET: Rezerwacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }
            ViewData["IdJachtu"] = new SelectList(_context.Jachty, "IdJachtu", "Nazwa", rezerwacja.IdJachtu);
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email", rezerwacja.IdKlienta);

            return View(rezerwacja);
        }

        // POST: Rezerwacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRezerwacji,DataOd,DataDo,IdJachtu,IdKlienta")] Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.IdRezerwacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaExists(rezerwacja.IdRezerwacji))
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
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .FirstOrDefaultAsync(m => m.IdRezerwacji == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja != null)
            {
                _context.Rezerwacje.Remove(rezerwacja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacje.Any(e => e.IdRezerwacji == id);
        }
    }
}
