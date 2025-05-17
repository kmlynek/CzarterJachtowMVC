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
    public class JachtController : Controller
    {
        private readonly FirmaContext _context;

        public JachtController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Jacht
        public async Task<IActionResult> Index()
        {
            var jachty = _context.Jachty
                .Include(j => j.KategoriaJachtu)
                .Include(j => j.Port);
            return View(await jachty.ToListAsync());
        }

        // GET: Jacht/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var jacht = await _context.Jachty
                .Include(j => j.KategoriaJachtu)
                .Include(j => j.Port)
                .FirstOrDefaultAsync(m => m.IdJachtu == id);

            if (jacht == null) return NotFound();

            return View(jacht);
        }

        // GET: Jacht/Create
        public IActionResult Create()
        {
            ViewData["IdKategorii"] = new SelectList(_context.KategorieJachtow, "IdKategorii", "Nazwa");
            ViewData["IdPortu"] = new SelectList(_context.Porty, "IdPortu", "Nazwa");
            return View();
        }

        // POST: Jacht/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJachtu,Nazwa,RokBudowy,CenaZaDzien,Opis,IdKategorii,IdPortu")] Jacht jacht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jacht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdKategorii"] = new SelectList(_context.KategorieJachtow, "IdKategorii", "Nazwa", jacht.IdKategorii);
            ViewData["IdPortu"] = new SelectList(_context.Porty, "IdPortu", "Nazwa", jacht.IdPortu);
            return View(jacht);
        }

        // GET: Jacht/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var jacht = await _context.Jachty.FindAsync(id);
            if (jacht == null) return NotFound();
            
            ViewData["IdKategorii"] = new SelectList(_context.KategorieJachtow, "IdKategorii", "Nazwa", jacht.IdKategorii);
            ViewData["IdPortu"] = new SelectList(_context.Porty, "IdPortu", "Nazwa", jacht.IdPortu);
            return View(jacht);
        }

        // POST: Jacht/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJachtu,Nazwa,RokBudowy,CenaZaDzien,Opis,IdKategorii,IdPortu")] Jacht jacht)
        {
            if (id != jacht.IdJachtu) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jacht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JachtExists(jacht.IdJachtu)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdKategorii"] = new SelectList(_context.KategorieJachtow, "IdKategorii", "Nazwa", jacht.IdKategorii);
            ViewData["IdPortu"] = new SelectList(_context.Porty, "IdPortu", "Nazwa", jacht.IdPortu);
            return View(jacht);
        }

        // GET: Jacht/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var jacht = await _context.Jachty
                .Include(j => j.KategoriaJachtu)
                .Include(j => j.Port)
                .FirstOrDefaultAsync(m => m.IdJachtu == id);

            if (jacht == null) return NotFound();

            return View(jacht);
        }

        // POST: Jacht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jacht = await _context.Jachty.FindAsync(id);
            if (jacht != null)
            {
                _context.Jachty.Remove(jacht);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool JachtExists(int id)
        {
            return _context.Jachty.Any(e => e.IdJachtu == id);
        }
    }
}
