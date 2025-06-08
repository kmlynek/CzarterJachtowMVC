using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.Intranet.Controllers
{
    public class ParametrController : Controller
    {
        private readonly FirmaContext _context;

        public ParametrController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Parametr
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parametry.ToListAsync());
        }

        // GET: Parametr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametr = await _context.Parametry
                .FirstOrDefaultAsync(m => m.IdParametru == id);
            if (parametr == null)
            {
                return NotFound();
            }

            return View(parametr);
        }

        // GET: Parametr/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parametr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametru,Klucz,Wartosc")] Parametr parametr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parametr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parametr);
        }

        // GET: Parametr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametr = await _context.Parametry.FindAsync(id);
            if (parametr == null)
            {
                return NotFound();
            }
            return View(parametr);
        }

        // POST: Parametr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParametru,Klucz,Wartosc")] Parametr parametr)
        {
            if (id != parametr.IdParametru)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parametr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametrExists(parametr.IdParametru))
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
            return View(parametr);
        }

        // GET: Parametr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametr = await _context.Parametry
                .FirstOrDefaultAsync(m => m.IdParametru == id);
            if (parametr == null)
            {
                return NotFound();
            }

            return View(parametr);
        }

        // POST: Parametr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parametr = await _context.Parametry.FindAsync(id);
            if (parametr != null)
            {
                _context.Parametry.Remove(parametr);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParametrExists(int id)
        {
            return _context.Parametry.Any(e => e.IdParametru == id);
        }
    }
}
