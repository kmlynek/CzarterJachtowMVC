using Firma.Data.Data;
using Firma.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Firma.Intranet.Controllers
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

        public IActionResult Index()
        {
            // Ustawienie liczb do wyœwietlenia w panelu
            ViewBag.LiczbaStron = _context.Strona.Count();          
            ViewBag.LiczbaZapytan = _context.Zapytania.Count();     
            ViewBag.LiczbaRezerwacji = _context.Rezerwacje.Count(); 
            ViewBag.LiczbaKlientow = _context.Klienci.Count();        

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
