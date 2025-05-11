using Microsoft.EntityFrameworkCore;
using Firma.Data.Data.CMS;
using Firma.Data.Data.Flota;
using Firma.Data.Data.Rezerwacje;
using Firma.Data.Data.Komunikacja;
using Firma.Data.Data.Sklep;

namespace Firma.Data.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        // Flota
        public DbSet<Jacht> Jachty { get; set; } = default!;
        public DbSet<KategoriaJachtu> KategorieJachtow { get; set; } = default!;
        public DbSet<Port> Porty { get; set; } = default!;
        public DbSet<ZdjecieJachtu> ZdjeciaJachtow { get; set; } = default!;

        // CMS
        public DbSet<Strona> Strona { get; set; } = default!;

        // Rezerwacje
        public DbSet<Klient> Klienci { get; set; } = default!;
        public DbSet<Rezerwacja> Rezerwacje { get; set; } = default!;

        // Komunikacja
        public DbSet<Zapytanie> Zapytania { get; set; } = default!;

        //Testowe
        public DbSet<Aktualnosc> Aktualnosc { get; set; } = default!;
        public DbSet<Rodzaj> Rodzaj { get; set; } = default!;
        public DbSet<Towar> Towar { get; set; } = default!;

    }
}
