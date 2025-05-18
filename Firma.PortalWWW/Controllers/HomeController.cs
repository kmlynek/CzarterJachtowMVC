using Firma.Data.Data;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirmaContext _context;
        public HomeController(ILogger<HomeController> logger, FirmaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Ten VieBag wysyla wszystkie strony do widoku Odnosniki
            ViewBag.ModelStrony =
                (
                    from strona in _context.Strona //dla kazdej strony z bazy danych context stron 
                    orderby strona.Pozycja //posortowanej wzgledem pozycji
                    select strona //pobieramy strone
                ).ToList();

            //Ten VieBag wysyla wszystkie jachty z BD do widoku PoelcaneJachty
            ViewBag.PolecaneJachty = (
                    from jacht in _context.Jachty
                    orderby jacht.IdJachtu descending 
                    select jacht
                ).Take(3).ToList();//Wyswietl maksymalnie 3 pierwsze jachty

            return View();

        }


        public IActionResult Oferta()
        {
            return View();
        }

        public IActionResult Dostepnosc()
        {
            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }
        public IActionResult Porty()
        {
            var porty = _context.Porty
                .OrderBy(p => p.Nazwa)
                .ToList();
            return View(porty);

        }
        public IActionResult Kategorie()
        {
            ViewBag.ModelKategorie = (
                from k in _context.KategorieJachtow
                orderby k.Nazwa
                select k
            ).ToList();

            return View();
        }

        public IActionResult Flota()
        {
            var jachty = _context.Jachty
                .OrderBy(j => j.Nazwa)
                .ToList();

            return View("Flota", jachty);
        }

        public IActionResult Rezerwacje()
        {
            var rezerwacje = _context.Rezerwacje
                .Include(r => r.Jacht)
                .OrderBy(r => r.DataOd)
                .ToList();

            return View(rezerwacje);
        }

        public IActionResult Galeria()
        {
            var jachty = _context.Jachty
                .OrderBy(j => j.Nazwa)
                .ToList();

            return View(jachty);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
