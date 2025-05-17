using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Komunikacja;

namespace Firma.Intranet.Controllers
{
    public class ZapytanieController : Controller
    {
        private readonly FirmaContext _context;

        public ZapytanieController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Zapytanie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zapytania.ToListAsync());
        }

        // GET: Zapytanie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapytanie = await _context.Zapytania
                .FirstOrDefaultAsync(m => m.IdZapytania == id);
            if (zapytanie == null)
            {
                return NotFound();
            }

            return View(zapytanie);
        }

        // GET: Zapytanie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zapytanie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZapytania,Temat,Tresc,Email,DataWyslania")] Zapytanie zapytanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zapytanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zapytanie);
        }

        // GET: Zapytanie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapytanie = await _context.Zapytania.FindAsync(id);
            if (zapytanie == null)
            {
                return NotFound();
            }
            return View(zapytanie);
        }

        // POST: Zapytanie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZapytania,Temat,Tresc,Email,DataWyslania")] Zapytanie zapytanie)
        {
            if (id != zapytanie.IdZapytania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zapytanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZapytanieExists(zapytanie.IdZapytania))
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
            return View(zapytanie);
        }

        // GET: Zapytanie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapytanie = await _context.Zapytania
                .FirstOrDefaultAsync(m => m.IdZapytania == id);
            if (zapytanie == null)
            {
                return NotFound();
            }

            return View(zapytanie);
        }

        // POST: Zapytanie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zapytanie = await _context.Zapytania.FindAsync(id);
            if (zapytanie != null)
            {
                _context.Zapytania.Remove(zapytanie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZapytanieExists(int id)
        {
            return _context.Zapytania.Any(e => e.IdZapytania == id);
        }
    }
}
