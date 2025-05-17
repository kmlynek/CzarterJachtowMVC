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
    public class KategoriaJachtuController : Controller
    {
        private readonly FirmaContext _context;

        public KategoriaJachtuController(FirmaContext context)
        {
            _context = context;
        }

        // GET: KategoriaJachtu
        public async Task<IActionResult> Index()
        {
            return View(await _context.KategorieJachtow.ToListAsync());
        }

        // GET: KategoriaJachtu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaJachtu = await _context.KategorieJachtow
                .FirstOrDefaultAsync(m => m.IdKategorii == id);
            if (kategoriaJachtu == null)
            {
                return NotFound();
            }

            return View(kategoriaJachtu);
        }

        // GET: KategoriaJachtu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategoriaJachtu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKategorii,Nazwa")] KategoriaJachtu kategoriaJachtu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriaJachtu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriaJachtu);
        }

        // GET: KategoriaJachtu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaJachtu = await _context.KategorieJachtow.FindAsync(id);
            if (kategoriaJachtu == null)
            {
                return NotFound();
            }
            return View(kategoriaJachtu);
        }

        // POST: KategoriaJachtu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKategorii,Nazwa")] KategoriaJachtu kategoriaJachtu)
        {
            if (id != kategoriaJachtu.IdKategorii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriaJachtu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriaJachtuExists(kategoriaJachtu.IdKategorii))
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
            return View(kategoriaJachtu);
        }

        // GET: KategoriaJachtu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriaJachtu = await _context.KategorieJachtow
                .FirstOrDefaultAsync(m => m.IdKategorii == id);
            if (kategoriaJachtu == null)
            {
                return NotFound();
            }

            return View(kategoriaJachtu);
        }

        // POST: KategoriaJachtu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategoriaJachtu = await _context.KategorieJachtow.FindAsync(id);
            if (kategoriaJachtu != null)
            {
                _context.KategorieJachtow.Remove(kategoriaJachtu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriaJachtuExists(int id)
        {
            return _context.KategorieJachtow.Any(e => e.IdKategorii == id);
        }
    }
}
