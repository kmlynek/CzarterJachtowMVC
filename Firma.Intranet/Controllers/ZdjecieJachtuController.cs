using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Flota;

namespace Firma.Intranet.Controllers
{
    public class ZdjecieJachtuController : Controller
    {
        private readonly FirmaContext _context;

        public ZdjecieJachtuController(FirmaContext context)
        {
            _context = context;
        }

        // Lista
        public async Task<IActionResult> Index()
        {
            var lista = await _context.ZdjeciaJachtow
                .Include(z => z.Jacht)
                .ToListAsync();

            return View(lista);
        }

        // Dodawanie
        public IActionResult Create()
        {
            ViewData["IdJachtu"] = new SelectList(_context.Jachty, "IdJachtu", "Nazwa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZdjecia,Sciezka,IdJachtu")] ZdjecieJachtu zdjecieJachtu)
        {
            if (ModelState.IsValid)
            {
                if (!zdjecieJachtu.Sciezka!.StartsWith("/content/"))
                    zdjecieJachtu.Sciezka = "/content/" + zdjecieJachtu.Sciezka;

                _context.Add(zdjecieJachtu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdJachtu"] = new SelectList(_context.Jachty, "IdJachtu", "Nazwa", zdjecieJachtu.IdJachtu);
            return View(zdjecieJachtu);
        }

        // Edycja
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var zdjecie = await _context.ZdjeciaJachtow.FindAsync(id);
            if (zdjecie == null) return NotFound();

            ViewData["IdJachtu"] = new SelectList(_context.Jachty, "IdJachtu", "Nazwa", zdjecie.IdJachtu);
            return View(zdjecie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZdjecia,Sciezka,IdJachtu")] ZdjecieJachtu zdjecieJachtu)
        {
            if (id != zdjecieJachtu.IdZdjecia) return NotFound();

            if (ModelState.IsValid)
            {
                if (!zdjecieJachtu.Sciezka!.StartsWith("/content/"))
                    zdjecieJachtu.Sciezka = "/content/" + zdjecieJachtu.Sciezka;

                try
                {
                    _context.Update(zdjecieJachtu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ZdjeciaJachtow.Any(e => e.IdZdjecia == id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["IdJachtu"] = new SelectList(_context.Jachty, "IdJachtu", "Nazwa", zdjecieJachtu.IdJachtu);
            return View(zdjecieJachtu);
        }

        // Usuwanie
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var zdjecie = await _context.ZdjeciaJachtow
                .Include(z => z.Jacht)
                .FirstOrDefaultAsync(m => m.IdZdjecia == id);

            if (zdjecie == null) return NotFound();

            return View(zdjecie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zdjecie = await _context.ZdjeciaJachtow.FindAsync(id);
            if (zdjecie != null)
                _context.ZdjeciaJachtow.Remove(zdjecie);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
